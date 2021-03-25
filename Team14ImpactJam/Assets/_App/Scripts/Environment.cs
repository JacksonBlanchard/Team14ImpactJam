using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public int health;
    private int maxHealth = 100;

    private Color healthyColor = Color.white;
    private Color deadColor = new Color(35f/255, 23f/255, 9f/255); // dark brown color
    private Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        currentColor = healthyColor;
    }

    // Update is called once per frame
    void Update()
    {
        // THIS IS TEST CODE USED TO MAKE SURE THIS SCRIPT WORKS
        if (Input.GetKeyDown(KeyCode.G))
        {
            DecreaseHealth(10);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            IncreaseHealth(10);
        }
    }

    /// <summary>
    /// Decrease the health of the environment
    /// </summary>
    /// <param name="decrease">the amount to decrease</param>
    public void DecreaseHealth(int decrease)
    {
        if(health > decrease)
        {
            health -= decrease;
        }
        else
        {
            health = 0;
        }

        RecolorEnvironment();
    }

    /// <summary>
    /// Increase the health of the environment
    /// </summary>
    /// <param name="increase">the amount to increase</param>
    public void IncreaseHealth(int increase)
    {
        if((maxHealth - health) > increase)
        {
            health += increase;
        }
        else
        {
            health = maxHealth;
        }

        RecolorEnvironment();
    }

    /// <summary>
    /// Recolor the environment based on its health
    /// </summary>
    private void RecolorEnvironment()
    {
        // update the currentColor based on the current health of the environment
        currentColor = Color.Lerp(healthyColor, deadColor, health / maxHealth);

        // update the color of all objects in the environment
        foreach(Transform child in transform)
        {
            child.GetComponent<Renderer>().material.color = currentColor;
        }
    }
}
