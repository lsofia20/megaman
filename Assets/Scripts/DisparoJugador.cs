using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform ShotController;
    [SerializeField] private GameObject bala;
    [SerializeField] private float FireRate;
   
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Instantiate(bala, ShotController.position, ShotController.rotation);
    }
}
