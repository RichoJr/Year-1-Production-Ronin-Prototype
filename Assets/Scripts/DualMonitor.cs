using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DualMonitor : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public Camera playerCam1;
    public Camera playerCam2;
    int camAmount;
    // Start is called before the first frame update
    void Start()
    {
        cameras.Add(playerCam1);
        cameras.Add(playerCam2);

        if (Display.displays.Length > 1)
        {
            DualSetUp();
            StartCoroutine(CloseWindow());
        }
        else
        {
            SplitScreen();
        }
    }

    public void DualSetUp()
    {
        Display.displays[1].Activate();
    }

    public void SplitScreen()
    {
        camAmount = cameras.Count;
        for (int i = 0; i < camAmount; i++)
        {
            cameras[i].enabled = true;
            cameras[i].gameObject.SetActive(true);
            cameras[i].targetDisplay = 0;

            float x = (float)i / camAmount;
            float y = 0;
            float width = (float)1 / camAmount;
            float height = 1;

            cameras[i].rect = new Rect(x, y, width, height);
        }
    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(2f);
        Display.displays[1] = Display.displays[0];
        //Application.Quit();
    }
}
