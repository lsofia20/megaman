using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigoes>().TomarDaño(daño);
            Destroy(GameObject);
        }
    }*/
}
