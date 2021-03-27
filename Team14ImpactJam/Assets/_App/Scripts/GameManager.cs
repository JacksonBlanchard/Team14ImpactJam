using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject menuCamera;
    public GameObject menuUI;
    public GameObject dotCrosshair;

    // Start is called before the first frame update
    void Start()
    {
        ActivateMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ActivateMenu(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuCamera.activeSelf)
            {
                Application.Quit();
            }
            else
            {
                ActivateMenu(true);
            }
        }
    }

    public void ActivateMenu(bool activate)
    {
        player.SetActive(!activate);
        dotCrosshair.SetActive(!activate);
        menuCamera.SetActive(activate);
        menuUI.SetActive(activate);
    }
}
