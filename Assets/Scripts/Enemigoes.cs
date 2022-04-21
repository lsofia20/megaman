using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigoes : MonoBehaviour
{
    Animator myAnim;
    [SerializeField] private float vida;
    [SerializeField] private GameObject efectoMuerte;

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if(vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        //Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        myAnim.SetBool("isDying", true);
        Destroy(gameObject);
    }
}
