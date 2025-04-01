using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
    public int CurrentGold { get; set; }

    public void DepositGold(int amount)
    {
        CurrentGold += amount;
    }

    public void RemoveGold(int amount)
    {
        CurrentGold -= amount;
    }
}
