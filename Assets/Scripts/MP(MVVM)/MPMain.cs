using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UIManager.GetInstance().ShowPanel<MP_MainPanel>("MainPanel");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            UIManager.GetInstance().HidePanel("MainPanel");
        }
    }
}
