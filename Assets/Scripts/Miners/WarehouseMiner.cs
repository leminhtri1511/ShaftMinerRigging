using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseMiner : BaseMiner
{
    public Deposit ElevatorDeposit { get; set; }
    public Transform ElevatorDepositLocation { get; set; }
    public Transform WarehouseLocation { get; set; }

    private readonly int _walkingNoGold = Animator.StringToHash("WalkingNoGold");
    private readonly int _walkingWithGold = Animator.StringToHash("WalkingWithGold");

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RotateMiner(direction: -1);

            Vector2 fixedPos = new Vector2(
                ElevatorDepositLocation.position.x,
                transform.position.y
            );

            MoveMiner(fixedPos);
        }
    }

    public override void MoveMiner(Vector3 newPosition)
    {
        base.MoveMiner(newPosition);
        _animator.SetBool(_walkingNoGold, true);
    }

    protected override void CollectGold()
    {
        if (ElevatorDeposit.CurrentGold <= 0)
        {
            RotateMiner(direction: 1);
            ChangeGoal();

            MoveMiner(
                new Vector2(
                    WarehouseLocation.position.x,
                    transform.position.y
                )
            );

            return;
        }

        _animator.SetBool(_walkingNoGold, false);
        _animator.SetBool(_walkingWithGold, true);

        int currentGold = ElevatorDeposit.CollectGold(miner: this);
        float collectTime = CollectCapacity / CollectPerSecond;

        StartCoroutine(
            routine: IECollect(currentGold, collectTime)
        );
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ElevatorDeposit.RemoveGold(collectGold);

        RotateMiner(direction: 1);
        ChangeGoal();

        MoveMiner(
            new Vector2(
                WarehouseLocation.position.x,
                    transform.position.y
            )
        );
    }
}
