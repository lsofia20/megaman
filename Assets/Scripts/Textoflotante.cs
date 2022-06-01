using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textoflotante : MonoBehaviour
{
    [SerializeField] GameObject CMcam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y);
    }
}
