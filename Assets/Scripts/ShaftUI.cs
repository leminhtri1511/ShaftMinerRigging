using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentGoldTMP;

    private Shaft _shaft;

    private void Start()
    {
        _shaft = GetComponent<Shaft>();
    }

    private void Update()
    {
        currentGoldTMP.text = _shaft.CurrentDeposit.CurrentGold.ToString();
    }

}
