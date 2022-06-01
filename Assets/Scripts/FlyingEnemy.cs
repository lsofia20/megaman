using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    Animator myAnim;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip clip;
    AIPath myPath;
    float vida = 7;

    // Start is called before the first frame update
    void Start()
    {
        myPath = GetComponent<AIPath>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
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

    public void TomarDaño(float daño)
    {
        vida = vida - daño;
        Debug.Log("La vida que queda es: " + vida);
        if (vida <= 0)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            myAnim.SetTrigger("death");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Megaman")
        {
            myPath.isStopped = true;
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
