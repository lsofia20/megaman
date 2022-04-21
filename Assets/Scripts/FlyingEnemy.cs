using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    AIPath myPath;
    // Start is called before the first frame update
    void Start()
    {
        myPath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        //Opcion 1 - vector2.distance
        /*float distancia = Vector2.Distance(transform.position, player.transform.position);
        if (distancia < 8)
        {
            //Debug.Log("Persiguiendo");
        }
        Debug.DrawRay(transform.position, player.transform.position, Color.red);*/

        //Opcion 2 - overlapcircle
        Collider2D col = Physics2D.OverlapCircle(transform.position, 8f, LayerMask.GetMask("Player"));
        if (col != null)
            myPath.isStopped = false;
        else
            myPath.isStopped = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }
}
