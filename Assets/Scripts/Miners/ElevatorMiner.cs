using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMiner : BaseMiner
{
    private int _currentShaftIndex = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
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

        MoveMiner(fixedPos);
    }

}
