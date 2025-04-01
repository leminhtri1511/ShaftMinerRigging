using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentGoldTMP;
    [SerializeField] private TextMeshProUGUI currentLevelTMP;

    private Shaft _shaft;
    private ShaftUpgrade _shaftUpgrade;

    private void Start()
    {
        _shaftUpgrade = GetComponent<ShaftUpgrade>();
        _shaft = GetComponent<Shaft>();
    }

    private void Update()
    {
        currentGoldTMP.text = _shaft.CurrentDeposit.CurrentGold.ToString();
    }

    private void UpgradeShaft(BaseUpgrade upgrade, int currentLevel)
    {
        if (upgrade == _shaftUpgrade)
        {
            currentLevelTMP.text = $"Lv. {currentLevel}";
        }
    }

    private void OnEnable()
    {
        ShaftUpgrade.OnUpgrade += UpgradeShaft;
    }

    private void OnDisable()
    {
        ShaftUpgrade.OnUpgrade -= UpgradeShaft;
    }

}
