using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 10f;
    public GameObject player; // must assign in inspector
    bool hasInteracted = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public virtual void Interact()
    {
        // overwrite by inhereted interactable object
        Debug.Log("Interacting with " + transform.name);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

