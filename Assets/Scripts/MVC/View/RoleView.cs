using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleView : MonoBehaviour
{
    //1.找控件

    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnLevUp;
    public Button btnClose;

    //2.提供面板更新的相关方法给外部调用

    public void UpdateInfo(PlayerModel data)
    {
        txtLev.text = "Lv." + data.PlayerLev;
        txtHp.text = data.Hp.ToString();
        txtAtk.text = data.Atk.ToString();
        txtDef.text = data.Def.ToString();
        txtCrit.text = data.Crit.ToString();
        txtMiss.text = data.Miss.ToString();
        txtLuck.text = data.Luck.ToString();
    }

}
