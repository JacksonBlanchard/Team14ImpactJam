using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactable
{
    public GameObject canvas;
    public string dialogue;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        canvas.GetComponentInChildren<Text>().text = dialogue;
        canvas.SetActive(true);
    }

    public void DeactivateUI()
    {
        canvas.SetActive(false);
    }
}
