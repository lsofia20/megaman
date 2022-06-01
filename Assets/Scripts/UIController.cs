using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour
{
    Button startGameBtn;
    Label msgText;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement r = GetComponent<UIDocument>().rootVisualElement;
        startGameBtn = r.Q<Button>("start-btn");
        msgText = r.Q<Label>("msg");

        startGameBtn.clicked += LoadScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        UIDocument r = GetComponent<UIDocument>();
        r.enabled = false;

        //SceneManager.LoadScene("SampleScene");

    }

}
