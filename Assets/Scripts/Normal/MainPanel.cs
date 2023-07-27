using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public Text txtName;
    public Text txtLev;

    public Text txtMoney;
    public Text txtGem;
    public Text txtPower;

    public Button btnRole;

    private static MainPanel mainPanel;

    public static MainPanel MainPanel0 => mainPanel;

    // Start is called before the first frame update
    void Start()
    {
        btnRole.onClick.AddListener(() =>
        {
            RolePanel.ShowMe();
        });

        UpdateInfo();
    }

    /// <summary>
    /// 更新面板信息
    /// </summary>

    public void UpdateInfo()
    {
        txtName.text = PlayerPrefs.GetString("PlayerName", "风见壬");
        txtLev.text = "LV." + PlayerPrefs.GetInt("PlayerLev", 1);
        txtMoney.text = PlayerPrefs.GetInt("Money", 999).ToString();
        txtGem.text = PlayerPrefs.GetInt("Gem", 888).ToString();
        txtPower.text = PlayerPrefs.GetInt("Power", 10).ToString();
    }

    public static void ShowMe()
    {
        if(mainPanel == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);

            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            mainPanel = obj.GetComponent<MainPanel>();
        }

        mainPanel.gameObject.SetActive(true);
        mainPanel.UpdateInfo();
    }

    public static void HideMe()
    {
        if (mainPanel != null)
        {
            mainPanel.gameObject.SetActive(false);
        }
    }


}
