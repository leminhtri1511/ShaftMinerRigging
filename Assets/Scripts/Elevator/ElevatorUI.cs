using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElevatorUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI elevatorDepositGold;

    private Elevator _elevator;

    // Start is called before the first frame update
    void Start()
    {
        _elevator = GetComponent<Elevator>();
    }

    // Update is called once per frame
    void Update()
    {
        elevatorDepositGold.text = _elevator.ElevatorDeposit.CurrentGold.ToString();
    }
}
