
/*
 * 通常采用的显隐UI与更新UI数据的写法，未应用MVC思想
 * 一个面板脚本中包含更新该面板数据、动态显隐该面板的方法，也包含面板上的相关数据
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMain : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainPanel.ShowMe();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            MainPanel.HideMe();
        }
    }
}
