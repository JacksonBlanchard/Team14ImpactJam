using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Interactable
{
    public bool renewable = true;
    private float timer;
    private bool eaten = false;

    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
    }

    public override void Interact()
    {
        if(!eaten)
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
            timer = 10f; // default 2 minutes
        }
        else
        {
            timer = 240f; // twice as long as renewable resource
        }
    }
}
