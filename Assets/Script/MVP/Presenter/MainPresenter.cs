using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    private MVP_MainView mainView;

    private static MainPresenter presenter;
    public static MainPresenter Presenter => presenter;

    //1.界面显隐
    public static void ShowMe()
    {
        if (presenter == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            presenter = obj.GetComponent<MainPresenter>();
        }
        presenter.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (presenter != null)
            presenter.gameObject.SetActive(false);
    }

    //2.界面事件监听
    void Start()
    {
        mainView = GetComponent<MVP_MainView>();

        //3.界面的更新

        //mainView.UpdateInfo(PlayerModel.Instance);

        //调用Presenter对象的方法更新View
        UpdateInfo(PlayerModel.Instance);


        mainView.btnRole.onClick.AddListener(() =>
        {
            RolePresenter.ShowMe();
        });

        PlayerModel.Instance.AddListener(UpdateInfo);
    }

    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
        {
            //切断V与M的联系，不再将Model对象传入View的更新方法中
            mainView.txtName.text = data.PlayerName;
            mainView.txtLev.text = "Lv." + data.PlayerLev;
            mainView.txtMoney.text = data.Money.ToString();
            mainView.txtGem.text = data.Gem.ToString();
            mainView.txtPower.text = data.Power.ToString();
        }
           
    }


    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveListener(UpdateInfo);
    }
}
