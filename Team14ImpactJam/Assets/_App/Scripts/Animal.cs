using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : Interactable
{
    // npc variables
    public GameObject canvas;
    public string dialogue;
    // food variables
    public float amountOfFood;
    public bool renewable = true;
    private float timer;
    private bool eaten = false;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateUI();
        SetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(eaten)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SetTimer();
                Eat(false);
                hasInteracted = false;
            }
        }
    }

    public override void Interact()
    {
        if(!hasInteracted)
        {
            canvas.GetComponentInChildren<Text>().text = dialogue;
            canvas.SetActive(true);
        }
        else
        {
            if(!eaten)
            {
                Eat(true);
            }
            DeactivateUI();
            hasInteracted = false;
        }
    }

    public void DeactivateUI()
    {
        canvas.SetActive(false);
    }

    private void Eat(bool eat)
    {
        eaten = eat;
        GetComponent<Renderer>().enabled = !eat;
        GameObject.FindObjectOfType<Environment>().DecreaseHealth((int)(amountOfFood / 5));
    }

    private void SetTimer()
    {
        if(renewable)
        {
            timer = 120f; // default 2 minutes
        }
        else
        {
            timer = 240f; // twice as long as renewable resource
        }
    }
}
