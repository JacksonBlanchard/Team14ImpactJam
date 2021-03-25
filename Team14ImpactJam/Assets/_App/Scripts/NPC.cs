using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactable
{
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        canvas.GetComponentInChildren<Text>().text = "you interacted with me";
        canvas.SetActive(true);
    }
}
