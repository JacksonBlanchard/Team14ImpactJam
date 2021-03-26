using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public float health;
    private float maxHealth = 100;

    private Color healthyColor = Color.green;
    //private Color deadColor = Color.black;
    private Color deadColor = new Color(101f/255, 67f/255, 33f/255); // dark brown color
    private Color currentColor;

    [Range(0, 1)] public float t;

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
        currentColor = Color.Lerp(deadColor, healthyColor, health / maxHealth);

        // update the color of all objects in the environment
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Renderer>() == null)
            {
                foreach (Transform child2 in child)
                {
                    RecolorObject(child2);
                }
            }
            else
            {
                RecolorObject(child);
            }
        }
    }

    private void RecolorObject(Transform obj)
    {
        Material[] materials = obj.GetComponent<Renderer>().materials;
        foreach(Material mat in materials)
        {
            mat.color = Color.Lerp(deadColor, mat.color, health / maxHealth);
        }
    }
}
