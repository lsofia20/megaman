using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    float dir;
    float speed;
    float da�o = 0;
    bool isMoving = false;
    Animator myAnim;

    private void Start()
    {
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        //transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        if (isMoving)
        {
            transform.Translate(new Vector2(speed * dir, 0) * Time.deltaTime);
        }

        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.23f, LayerMask.GetMask("Ground"));
        Collider2D col2 = Physics2D.OverlapCircle(transform.position, 0.23f, LayerMask.GetMask("Enemy"));

        if (col != null || col2 != null)
        {
            isMoving = false;
            myAnim.SetTrigger("death");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.23f);
    }

    public void Shoot(float _dir, float _speed)
    {
        dir = _dir;
        speed = _speed;
        isMoving = true;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemigoEst"))
        {
            da�o += 1;
            other.GetComponent<Enemigoes>().TomarDa�o(da�o);
            //Destroy(gameObject);
        } else if (other.CompareTag("Enemigo"))
        {
            da�o += 1;
            other.GetComponent<FlyingEnemy>().TomarDa�o(da�o);
            //Destroy(gameObject);
        }
    }

}
