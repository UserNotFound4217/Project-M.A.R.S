using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitAplication : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC");
            Application.Quit();
        }
    }
}
