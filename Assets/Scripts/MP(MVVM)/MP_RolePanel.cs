using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_RolePanel : BasePanel
{
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
            case "btnClose":
                UIManager.GetInstance().HidePanel("RolePanel");
                break;

            case "btnLevUp":
                PlayerModel.Instance.LevUp();
                break;
        }
    }


    private void UpdateInfo(PlayerModel data)
    {
        GetControl<Text>("txtLev").text = "Lv." + data.PlayerLev;
        GetControl<Text>("txtHp").text = data.Hp.ToString();
        GetControl<Text>("txtAtk").text = data.Atk.ToString();
        GetControl<Text>("txtDef").text = data.Def.ToString();
        GetControl<Text>("txtCrit").text = data.Crit.ToString();
        GetControl<Text>("txtMiss").text = data.Miss.ToString();
        GetControl<Text>("txtLuck").text = data.Luck.ToString();
    }
}
