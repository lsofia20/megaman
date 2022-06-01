using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigoes : MonoBehaviour
{
    Animator myAnim;
    float nextFire = 0;
    float animationLayerCooldown = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] AudioClip clip;
    float vida = 7;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.left, 10f,
                                             LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, Vector2.left * 10f, Color.red);
        if(ray.collider != null)
        {
            Fire();
        }

        //Collider2D col = Physics2D.OverlapBox(transform.position, new Vector2(2.6f, 2.3f), LayerMask.GetMask("Bullet"));
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

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector2(2.6f, 2.3f));
    }*/

    void Fire()
    {
        if (Time.time > nextFire)
        {
            GameObject myBullet = Instantiate(bullet, transform.position, transform.rotation);
            myBullet.GetComponent<Bullet_se>().Shoot(-transform.localScale.x, bulletSpeed);

            //myAnim.SetLayerWeight(1, 1);
            nextFire = Time.time + fireRate;
            animationLayerCooldown = nextFire + 0.2f;
        }
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
