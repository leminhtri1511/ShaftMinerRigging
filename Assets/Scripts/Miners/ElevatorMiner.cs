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
        if (!_currentDeposit.CanCollectGold() && _currentDeposit != null)
        {
            _currentShaftIndex = -1;

            Vector3 elevatorDepositPos = new Vector3(
                transform.position.x,
                elevator.DepositLocation.position.y
            );
            MoveMiner(elevatorDepositPos);

            return;
        }

        int amountToCollect = _currentDeposit.CollectGold(miner: this);
        Debug.Log($"amountToCollect: {amountToCollect}" );
        float collectTime = amountToCollect / CollectPerSecond;
        StartCoroutine(
            routine: IECollect(amountToCollect, collectTime)
        );
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        _currentDeposit.RemoveGold(collectGold);

        yield return new WaitForSeconds(collectTime);

        _currentShaftIndex = -1;
        ChangeGoal();

        Vector3 elevatorDepositPos = new Vector3(
            transform.position.x,
            elevator.DepositLocation.position.y
        );
        MoveMiner(elevatorDepositPos);
    }
}
