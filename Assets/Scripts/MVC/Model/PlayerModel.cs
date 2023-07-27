using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    //作为唯一的数据，要不自身为单例模式，要不存在于单例模式对象中
    private static PlayerModel instance;
    public static PlayerModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerModel();
                instance.InitInfo();
            }
            return instance;
        }
    }
    private PlayerModel() { }

    private string playerName;
    private int playerLev;
    private int money;
    private int gem;
    private int power;
    private int hp;
    private int atk;
    private int def;
    private int crit;
    private int miss;
    private int luck;

    public string PlayerName => playerName;
    public int PlayerLev => playerLev;
    public int Money => money;
    public int Gem => gem;
    public int Power => power;
    public int Hp => hp;
    public int Atk => atk;
    public int Def => def;
    public int Crit => crit;
    public int Miss => miss;
    public int Luck => luck;


    /// <summary>
    /// 通知外部更新的事件
    /// </summary>
    private event Action<PlayerModel> updateEvent;


    public void InitInfo()
    {
        playerName = PlayerPrefs.GetString("PlayerName","风见壬");
        playerLev = PlayerPrefs.GetInt("PlayerLev", 1);
        money = PlayerPrefs.GetInt("PlayerMoney", 9999);
        gem = PlayerPrefs.GetInt("PlayerGem", 8888);
        power = PlayerPrefs.GetInt("PlayerPower", 6666);
        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        def = PlayerPrefs.GetInt("PlayerDef", 8);
        crit = PlayerPrefs.GetInt("PlayerCrit", 5);
        miss = PlayerPrefs.GetInt("PlayerMiss", 4);
        luck = PlayerPrefs.GetInt("PlayerLuck", 6);
    }


    public void LevUp()
    {
        playerLev += 1;
        //money += playerLev;
        //gem += playerLev;
        //power += playerLev;
        hp += playerLev;
        atk += playerLev;
        def += playerLev;
        crit += playerLev;
        miss += playerLev;
        luck += playerLev;

        SaveDada();

        UpdateInfo();
    }

    public void SaveDada()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerLev", playerLev);
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.SetInt("PlayerGem", gem);
        PlayerPrefs.SetInt("PlayerPower", power);
        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrit", crit);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLuck", luck);
    }

    public void AddListener(Action<PlayerModel> action)
    {
        updateEvent += action;
    }

    public void RemoveListener(Action<PlayerModel> action)
    {
        updateEvent -= action;
    }

    /// <summary>
    /// 通知外部界面更新数据
    /// </summary>
    public void UpdateInfo()
    {
        updateEvent?.Invoke(this);
    }

}
