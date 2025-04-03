using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    public Shaft CurrentShaft { get; set; }

    private int miningAnimationParameter = Animator.StringToHash("Mining");
    private int walkingAnimationParameter = Animator.StringToHash("Walking");

    public override void MoveMiner(Vector3 newPosition)
    {
        base.MoveMiner(newPosition);
        _animator.SetTrigger(walkingAnimationParameter);
    }

    protected override void CollectGold()
    {
        float collectTime = CollectCapacity / CollectPerSecond;

        _animator.SetTrigger(miningAnimationParameter);
        StartCoroutine(routine: IECollect(CollectCapacity, collectTime));
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        Vector3 depositLocation = CurrentShaft.DepositLocation.position;
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ChangeGoal();
        RotateMiner(-1);
        MoveMiner(depositLocation);
    }

    protected override void DepositGold()
    {
        Vector3 miningLocation = CurrentShaft.MiningLocation.position;
        
        CurrentShaft.CurrentDeposit.DepositGold(CurrentGold);

        CurrentGold = 0;
        ChangeGoal();
        RotateMiner(direction: 1);
        MoveMiner(miningLocation);
    }

}
