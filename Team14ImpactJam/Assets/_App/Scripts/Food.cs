﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Interactable
{
    public float amountOfFood;
    public bool renewable = true;
    private float timer;
    private bool eaten = false;
    private bool isAnimal;

    // Start is called before the first frame update
    void Start()
    {
        SetTimer();
        isAnimal = (GetComponent<Animal>() != null);
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
        if(!eaten && !isAnimal)
        {
            Eat(true);
        }
        else if(isAnimal && hasInteracted)
        {
            Eat(true);
        }
    }

    private void Eat(bool eat)
    {
        eaten = eat;
        GetComponent<Renderer>().enabled = !eat;
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
