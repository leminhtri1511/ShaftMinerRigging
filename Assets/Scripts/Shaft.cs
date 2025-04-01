using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private ShaftMiner minerPrefab;

    [Header("Location")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;

    public Transform MiningLocation => miningLocation;
    public Transform DepositLocation => depositLocation;

    private void Start()
    {
        CreateMiner();
    }

    private void CreateMiner()
    {
        Vector3 miningPosition = miningLocation.position;
        ShaftMiner newMiner = Instantiate(minerPrefab, depositLocation.position, Quaternion.identity);
        newMiner.CurrentShaft = this;

        newMiner.MoveMiner(miningPosition);
    }
}
