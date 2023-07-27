using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVP_MainView : MonoBehaviour
{
    //1.找控件
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtGem;
    public Text txtPower;

    public Button btnRole;
    public Button btnSkill;


    /*2.提供面板更新的相关方法给外部调用
     * 界面信息更新方法可选写，参数不能与Model类有联系
     */

    //public void UpdateInfo(string name, string lev,string money, string gem, string power)
    //{
    //    txtName.text = name;
    //    txtLev.text = "Lv." + lev;
    //    txtMoney.text = money;
    //    txtGem.text = gem;
    //    txtPower.text = power;
    //}
}
