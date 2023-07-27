using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    private RoleView roleView;

    private static RoleController controller;
    public static RoleController Controller => controller;

    public static void ShowMe()
    {
        if (controller == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            controller = obj.GetComponent<RoleController>();
        }

        controller.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (controller != null)
            controller.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        roleView = GetComponent<RoleView>();

        //第一次更新界面信息
        roleView.UpdateInfo(PlayerModel.Instance);

        roleView.btnClose.onClick.AddListener(() =>
        {
            HideMe();
        });

        roleView.btnLevUp.onClick.AddListener(() =>
        {
            PlayerModel.Instance.LevUp();
            
        });

        PlayerModel.Instance.AddListener(UpdateInfo);

    }

    public void UpdateInfo(PlayerModel data)
    {
        if (roleView != null)
            roleView.UpdateInfo(data);
    }

 
    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveListener(UpdateInfo);
    }

}
