using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMcam : MonoBehaviour
{
    public GameObject[] fEnemy;
    public GameObject[] sEnemy;
    [SerializeField] GameObject textoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Texto flotante(Clone)"));
        Destroy(GameObject.Find("Texto flotante(Clone)"));
        fEnemy = GameObject.FindGameObjectsWithTag("Enemigo");
        float numFEn = fEnemy.Length;

        sEnemy = GameObject.FindGameObjectsWithTag("EnemigoEst");
        float numSEn = sEnemy.Length;
        float tEnemies = numFEn + numSEn;
        if (textoPrefab)
            MostrarTexto(tEnemies);
        //calcularEnemigos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void calcularEnemigos()
    {
        Destroy(GameObject.Find("Texto flotante(Clone)"));
        Destroy(GameObject.Find("Texto flotante(Clone)"));
        fEnemy = GameObject.FindGameObjectsWithTag("Enemigo");
        float numFEn = fEnemy.Length;

        sEnemy = GameObject.FindGameObjectsWithTag("EnemigoEst");
        float numSEn = sEnemy.Length;
        float tEnemies = numFEn + numSEn;
        if (textoPrefab)
            MostrarTexto(tEnemies);
    }

    public void MostrarTexto(float enemies)
    {
        GameObject texto = Instantiate(textoPrefab);
        texto.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y+20);
        texto.transform.SetParent(this.transform);
        TextMesh comp = texto.GetComponent<TextMesh>();
        comp.text = "Enemigos en escena: "+enemies;

    }
}
