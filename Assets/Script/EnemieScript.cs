
using UnityEngine;

public class EnemieScript : MonoBehaviour

{
    public float speed;
    public Transform[] waypoints;
    // cible dans la quelle l ennemie va se deplacer cible --> waypoints  si point atteind changement du target en point B puis qaund le point b trget changera pour point A  ...
    private Transform target;
   // Point de destination 
    private int desPoint = 0;




    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        //on prend la position de la cible et on la soustrait au point d arrivé
        Vector3 direction = target.position - transform.position;
        //Translate = methode de deplacement dans unity / normalized = mettre la magnitude du vector sur 1/ Space.World = perso se deplace par rapport au monde
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //permet d avoir la distance entre 2 objet
        // Si le perso est tres proche de sa destination:
        if (Vector3.Distance(transform.position,target.position)<0.3f)
        {
            // changement target 
            //% waypoints.Length = point 
            desPoint = (desPoint + 1) % waypoints.Length;
            target = waypoints[desPoint];
        }
    }
}
