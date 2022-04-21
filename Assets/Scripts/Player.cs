using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator myAnim;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        StartCoroutine(Showtime());
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
    }

    IEnumerator Showtime()
    {
        while (true) //loop infinito
        {
            yield return new WaitForSeconds(1); //espere x segundos para ir a la siguente linea
            Debug.Log(Time.time);
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            myAnim.SetLayerWeight(1, 1);
        }
        else
        {
            myAnim.SetLayerWeight(1, 0);
        }
    }

    /*void FinishRun()
    {
        Debug.Log("Termino de correr");
    }*/

   void Jump()
    {
        if (isGrounded && !myAnim.GetBool("IsJumping"))
        {
            //myAnim.SetBool("IsJumping", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
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

}
