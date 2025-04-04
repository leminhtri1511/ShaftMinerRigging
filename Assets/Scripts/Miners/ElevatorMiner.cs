using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMiner : BaseMiner
{
    [SerializeField] private Elevator elevator;

    private int _currentShaftIndex = -1;
    private Deposit _currentDeposit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            MoveToNextLocation();
        }
    }

    public void MoveToNextLocation()
    {
        _currentShaftIndex++;

        Shaft currentShaft = ShaftManager.Instance.Shafts[_currentShaftIndex];
        Vector2 nextPos = currentShaft.DepositLocation.position;
        Vector2 fixedPos = new Vector2(transform.position.x, nextPos.y);

        _currentDeposit = currentShaft.CurrentDeposit;
        MoveMiner(fixedPos);
    }

    protected override void CollectGold()
    {
        if (!_currentDeposit.CanCollectGold()
                && _currentDeposit != null
                && _currentShaftIndex == ShaftManager.Instance.Shafts.Count - 1)
        {
            _currentShaftIndex = -1;
            ChangeGoal();

            Vector3 elevatorDepositPos = new Vector3(
                transform.position.x,
                elevator.DepositLocation.position.y
            );

            MoveMiner(elevatorDepositPos);
            return;
        }

        int amountToCollect = _currentDeposit.CollectGold(miner: this);
        float collectTime = amountToCollect / CollectPerSecond;

        StartCoroutine(
            routine: IECollect(amountToCollect, collectTime)
        );
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);

        if (CurrentGold > 0 && CurrentGold < CollectCapacity)
        {
            CurrentGold += collectGold;
        }
        else
        {
            CurrentGold = collectGold;
        }

        _currentDeposit.RemoveGold(collectGold);

        yield return new WaitForSeconds(0.6f);

        if (CurrentGold == CollectCapacity ||
            _currentShaftIndex == ShaftManager.Instance.Shafts.Count - 1)
        {
            _currentShaftIndex = -1;
            ChangeGoal();

            Vector3 elevatorDepositPos = new Vector3(
                transform.position.x,
                elevator.DepositLocation.position.y
            );

            MoveMiner(elevatorDepositPos);
        }
        else
        {
            MoveToNextLocation();
        }
    }

    protected override void DepositGold()
    {
        if (CurrentGold <= 0)
        {
            _currentShaftIndex = -1;
            ChangeGoal();
            MoveToNextLocation();

            return;
        }

        float depositTime = CurrentGold / CollectPerSecond;

        StartCoroutine(
            routine: IEDeposit(CurrentGold, depositTime)
        );
    }

    protected override IEnumerator IEDeposit(int goldCollected, float depositTime)
    {
        yield return new WaitForSeconds(depositTime);

        elevator.ElevatorDeposit.DepositGold(CurrentGold);

        CurrentGold = 0;
        _currentShaftIndex = -1;

        ChangeGoal();
        MoveToNextLocation();
    }
}
