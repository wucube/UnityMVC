using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVP_RoleView : MonoBehaviour
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
    // 更新方法选写，但参数不能与Model类有联系
}
