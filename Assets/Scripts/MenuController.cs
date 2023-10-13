using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public DualMonitor dualMonitor;

    private void Start()
    {
        //menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.active == true)
            {
                menu.SetActive(false);
            }
            else if(menu.active == false)
            {
                menu.SetActive(true);
            }  
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}
