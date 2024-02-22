using UnityEngine;

public class EnemieScript : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int desPoint = 0;

    private SpriteRenderer spriteRenderer; // Ajout de la référence au SpriteRenderer

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
        spriteRenderer = GetComponent<SpriteRenderer>(); // Récupération du composant SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            desPoint = (desPoint + 1) % waypoints.Length;
            target = waypoints[desPoint];

            // Inverser horizontalement l'ennemi lors du changement de direction
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}