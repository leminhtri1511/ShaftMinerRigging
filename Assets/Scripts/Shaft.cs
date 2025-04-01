using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private ShaftMiner minerPrefab;
    [SerializeField] private Deposit depositPrefab;

    [Header("Location")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private Transform depositInstantiationPos;


    public Transform MiningLocation => miningLocation;
    public Transform DepositLocation => depositLocation;
    public List<ShaftMiner> Miners => _miners;
    public Deposit CurrentDeposit { get; set; }

    private GameObject _minersContainer;
    private List<ShaftMiner> _miners;

    private void Start()
    {
        _miners = new List<ShaftMiner>();
        _minersContainer = new GameObject("Miners");
        CreateMiner();
        CreateDeposit();
    }

    private void CreateMiner()
    {
        Vector3 miningPosition = miningLocation.position;
        ShaftMiner newMiner = Instantiate(minerPrefab, depositLocation.position, Quaternion.identity);
        newMiner.CurrentShaft = this;
        newMiner.transform.SetParent(_minersContainer.transform);
        newMiner.MoveMiner(miningPosition);

        // Add new Miner
        _miners.Add(newMiner);
    }

    private void CreateDeposit()
    {
        CurrentDeposit = Instantiate(depositPrefab, depositInstantiationPos.position, Quaternion.identity);
        CurrentDeposit.transform.SetParent(depositInstantiationPos);
    }
}
