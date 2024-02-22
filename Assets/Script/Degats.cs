using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class death : MonoBehaviour
{
    public int health = 3;
    private Rigidbody2D body;
    private BoxCollider2D col;

    public Image[] hearts;
    public Sprite full_heart;
    public Sprite empty_heart;

    private bool invincible = false;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = empty_heart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = full_heart;
        }
    }
    void Dmg()
    {
        health -= 1;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        body.bodyType = RigidbodyType2D.Static;
        Restart_level();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                health = 0;
                Die();
            }
            if (collision.gameObject.CompareTag("Enemis"))
            {
                Dmg();
            }
        }
    }

    private void Restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}