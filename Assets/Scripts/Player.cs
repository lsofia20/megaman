using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator myAnim;
    bool isGrounded;
    float nextFire = 0;
    float animationLayerCooldown = 0;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject FlyingEnemy;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, 
                                             LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 1.2f, Color.red);
        isGrounded = ray.collider != null;
        Jump();
        Fire();
        /*if(transform.position == FlyingEnemy.transform.position)
        {
            myAnim.SetBool("isDying", true);
            StartCoroutine(GameOver());
        }*/
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(1);
        //yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
        
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Time.time > nextFire)
        {
            AudioSource.PlayClipAtPoint(clip2, transform.position);
            GameObject myBullet = Instantiate(bullet, transform.position, transform.rotation);
            myBullet.GetComponent<Bala>().Shoot(transform.localScale.x, bulletSpeed);

            myAnim.SetLayerWeight(1,1);
            nextFire = Time.time + fireRate;
            animationLayerCooldown = nextFire + 0.2f;
        }
        else if(Time.time > animationLayerCooldown)
        {
            myAnim.SetLayerWeight(1,0);
        }
        /*if (Input.GetKey(KeyCode.Z))
        {
            myAnim.SetLayerWeight(1, 1);
        }
        else
        {
            myAnim.SetLayerWeight(1, 0);
        }*/
    }

    public void Death()
    {
        myAnim.SetBool("isDying", true);
        StartCoroutine(GameOver());
    }

    void FinishingRun()
    {
        Debug.Log("Termina animación de correr");
    }

   void Jump()
    {
        if (isGrounded && !myAnim.GetBool("IsJumping"))
        {
            //myAnim.SetBool("IsJumping", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioSource.PlayClipAtPoint(clip3, transform.position);
                myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                myAnim.SetBool("IsJumping", true);
            }
        }

        if(myBody.velocity.y != 0 && !isGrounded)
            myAnim.SetBool("IsJumping", true);
        else
            myAnim.SetBool("IsJumping", false);

        /*if(myAnim.GetBool("IsJumping") == false)
        {
            if(!isGrounded)
                myAnim.SetBool("IsFalling", true);
            else
                myAnim.SetBool("IsFalling", false);
        }*/
    }


    private void FixedUpdate()
    {
        float dirH = Input.GetAxis("Horizontal");

        if (dirH != 0) 
        {
            myAnim.SetBool("IsRunning", true);
            if (dirH < 0)
                transform.localScale = new Vector2(-1, 1);
            else
                transform.localScale = new Vector2(1, 1);
        }
        else
            myAnim.SetBool("IsRunning", false);

        myBody.velocity = new Vector2(dirH * speed, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Flying enemy")
        {
            Death();
        }
    }
}
