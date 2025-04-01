using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUpgrade : MonoBehaviour
{
    [Header("Upgrades")]
    [SerializeField] private float collectCapacityMultiplier = 2f;
    [SerializeField] private float collectPerSecondMultiplier = 2f;
    [SerializeField] private float moveSpeedMultiplier = 1.5f;

    [Header("Cost")]
    [SerializeField] private float initialUpgradeCost = 200f;
    [SerializeField] private float upgradeCostMultiplier = 2f;

    public int CurrentLevel { get; set; }
    public float UpgradeCost { get; set; }

    protected Shaft _shaft;

    private void Start()
    {
        _shaft = GetComponent<Shaft>();

        CurrentLevel = 1;
        UpgradeCost = initialUpgradeCost;
    }

    public virtual void Upgrade(int upgradeAmount)
    {
        if (upgradeAmount > 0)
        {
            for (int i = 0; i < upgradeAmount; i++)
            {
                UpgradeSuccess();
                UpdateUpgradeValues();
                RunUpgrade();
            }
        }
    }

    protected virtual void UpgradeSuccess()
    {
        // Remove Gold
    }

    protected virtual void UpdateUpgradeValues()
    {
        // Update Values
    }

    protected virtual void RunUpgrade()
    {
        // Upgrade Logic
    }
}
