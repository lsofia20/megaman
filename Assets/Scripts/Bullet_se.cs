using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_se : MonoBehaviour
{
    Animator myAnim;
    float dir;
    float speed;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(new Vector2(speed * dir, 0) * Time.deltaTime);
        }
        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Player"));
        if(col != null)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(float _dir, float _speed)
    {
        dir = _dir;
        speed = _speed;
        isMoving = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            other.GetComponent<Player>().Death();
            //Destroy(gameObject);
        }   
    }
}
