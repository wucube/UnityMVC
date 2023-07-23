using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePresenter : MonoBehaviour
{
    private MVP_RoleView roleView;

    private static RolePresenter presenter;
    public static RolePresenter Presenter => presenter;

    public static void ShowMe()
    {
        if (presenter == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            presenter = obj.GetComponent<RolePresenter>();
        }

        presenter.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (presenter != null)
            presenter.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        roleView = GetComponent<MVP_RoleView>();

        //roleView.UpdateInfo(PlayerModel.Instance);

        //调用Presenter的方法更新View
        UpdateInfo(PlayerModel.Instance);

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
        {
            //View 与 Model 没有耦合
            roleView.txtLev.text = "Lv." + data.PlayerLev;
            roleView.txtHp.text = data.Hp.ToString();
            roleView.txtAtk.text = data.Atk.ToString();
            roleView.txtCrit.text = data.Crit.ToString();
            roleView.txtDef.text = data.Def.ToString();
            roleView.txtLuck.text = data.Luck.ToString();
            roleView.txtMiss.text = data.Miss.ToString();
        }
            
    }


    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveListener(UpdateInfo);
    }
}
