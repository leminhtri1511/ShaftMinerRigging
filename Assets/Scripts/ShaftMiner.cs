using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [SerializeField] private Transform shaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MoveMiner(shaftMiningLocation.position);
            Debug.Log("Go To Mining");
        }

        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     MoveMiner(shaftDepositLocation.position);
        //     Debug.Log("Go Back");
        // }
    }

    protected override void CollectGold()
    {
        float collectTime = CollectCapacity / CollectPerSecond;
        StartCoroutine(routine: IECollect(CollectCapacity, collectTime));
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ChangeGoal();
        MoveMiner(shaftDepositLocation.position);
    }

    protected override void DepositGold()
    {
        CurrentGold = 0;
        ChangeGoal();
        MoveMiner(shaftMiningLocation.position);
    }

}
