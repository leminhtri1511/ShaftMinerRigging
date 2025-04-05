using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject warehouseMinerPrefab;

    [Header("Prefab")]
    [SerializeField] private Deposit elevatorDeposit;
    [SerializeField] private Transform elevatorLocation;
    [SerializeField] private Transform warehouseDepositLocation;

    [SerializeField] private List<WarehouseMiner> miners;

    // Start is called before the first frame update
    private void Start()
    {
        miners = new List<WarehouseMiner>();
        AddMiner();
    }

    public void AddMiner()
    {
        GameObject newMiner = Instantiate(
            warehouseMinerPrefab,
            warehouseDepositLocation.position,
            Quaternion.identity
        );

        WarehouseMiner miner = newMiner.GetComponent<WarehouseMiner>();
        miner.ElevatorDeposit = elevatorDeposit;
        miner.ElevatorDepositLocation = elevatorLocation;
        miner.WarehouseLocation = warehouseDepositLocation;

        miners.Add(miner);
    }
}
