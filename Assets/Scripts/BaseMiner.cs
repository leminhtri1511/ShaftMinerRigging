using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseMiner : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 5f;
    private int initialCollectCapacity = 200;
    private float goldCollectPerSecond = 50f;

    public void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, duration: 10f / moveSpeed);
    }

}
