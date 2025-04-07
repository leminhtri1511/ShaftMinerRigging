using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : Singleton<GoldManager>
{
    [SerializeField] private int testGold = 0;

    public int CurrentGold { get; set; }

    private readonly string GOLD_KEY = "GoldKey";

    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        LoadGold();
    }

    private void LoadGold()
    {
        CurrentGold = PlayerPrefs.GetInt(GOLD_KEY, testGold);
    }

    public void AddGold(int amount)
    {
        CurrentGold += amount;
        PlayerPrefs.SetInt(GOLD_KEY, CurrentGold);
        PlayerPrefs.Save();
    }

    public void RemoveGold(int amount)
    {
        CurrentGold -= amount;
        PlayerPrefs.SetInt(GOLD_KEY, CurrentGold);
        PlayerPrefs.Save();
    }

}
