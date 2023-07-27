using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller 处理业务逻辑
/// </summary>
public class MainController : MonoBehaviour
{
    private MainView mainView;

    private static MainController controller;
    public static MainController Controller => controller;

    //1.界面显隐
    public static void ShowMe()
    {
        if (controller == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            controller = obj.GetComponent<MainController>();
        }
        controller.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (controller != null)
            controller.gameObject.SetActive(false);
    }

    //2.界面事件监听
    void Start()
    {
        mainView = GetComponent<MainView>();

        //3.界面的更新
        mainView.UpdateInfo(PlayerModel.Instance); 

        mainView.btnRole.onClick.AddListener(() =>
        {
            RoleController.ShowMe();
        });

        PlayerModel.Instance.AddListener(UpdateInfo);
    }

    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
            mainView.UpdateInfo(data);
    }

    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveListener(UpdateInfo);
    }
}
