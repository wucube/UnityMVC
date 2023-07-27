using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnClose;
    public Button btnLevUp;

    private static RolePanel rolePanel;


    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(HideMe);

        btnLevUp.onClick.AddListener(LevUp);
    }

    /// <summary>
    /// 角色升级
    /// </summary>
    public void LevUp()
    {
        int lev = PlayerPrefs.GetInt("PlayerLev", 1);
        int hp = PlayerPrefs.GetInt("PlayerHp", 100);
        int atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        int def = PlayerPrefs.GetInt("PlayerDef", 8);
        int crit = PlayerPrefs.GetInt("PlayerCrit", 5);
        int miss = PlayerPrefs.GetInt("PlayerMiss", 4);
        int luck = PlayerPrefs.GetInt("PlayerLuck", 3);

        //自定义数据的升级规划
        lev += 1;
        hp += lev;
        atk += lev;
        def += lev;
        crit += lev;
        miss += lev;
        luck += lev;

        //将新数据存储到本地
        PlayerPrefs.SetInt("PlayerLev", lev);
        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrit", crit);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLuck", luck);


        rolePanel.UpdeInfo();

        MainPanel.MainPanel0.UpdateInfo();

    }

    public void UpdeInfo()
    {
        txtLev.text = "Lv." + PlayerPrefs.GetInt("PlayerLev", 1);
        txtHp.text = PlayerPrefs.GetInt("PlayerHp", 100).ToString();
        txtAtk.text = PlayerPrefs.GetInt("PlayerAtk", 10).ToString();
        txtDef.text = PlayerPrefs.GetInt("PlayerDef", 8).ToString();
        txtCrit.text = PlayerPrefs.GetInt("PlayerCrit", 5).ToString();
        txtMiss.text = PlayerPrefs.GetInt("PlayerMiss", 4).ToString();
        txtLuck.text = PlayerPrefs.GetInt("PlayerLuck", 3).ToString();
    }

    public static void ShowMe()
    {
        if (rolePanel == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            rolePanel = obj.GetComponent<RolePanel>();
        }

        rolePanel.gameObject.SetActive(true);

        rolePanel.UpdeInfo();

    }

    public static void HideMe()
    {
        if (rolePanel != null)
        {
            rolePanel.gameObject.SetActive(false);
        }
    }

}
