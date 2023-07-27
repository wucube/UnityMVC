using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_MainPanel : BasePanel
{
    //1. 找控制 —— 已由基类完成
    //2. 逻辑更新
    //3. 数据更新

    // Start is called before the first frame update
    void Start()
    {
        UpdateInfo(PlayerModel.Instance);

        PlayerModel.Instance.AddListener(UpdateInfo);
    }


    void OnDestroy()
    {
        PlayerModel.Instance.RemoveListener(UpdateInfo);
    }



    protected override void OnClick(string btnName)
    {
        base.OnClick(btnName);

        switch (btnName)
        {
            case "btnRole":

                UIManager.GetInstance().ShowPanel<MP_RolePanel>("RolePanel");

                break;
        }
    }


    private void UpdateInfo(PlayerModel data)
    {
        GetControl<Text>("txtName").text = data.PlayerName;
        GetControl<Text>("txtLev").text = "Lv." + data.PlayerLev;
        GetControl<Text>("txtMoney").text = data.Money.ToString();
        GetControl<Text>("txtGem").text = data.Gem.ToString();
        GetControl<Text>("txtPower").text = data.Power.ToString();
    }


}
