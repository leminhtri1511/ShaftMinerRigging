using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseMiner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int initialCollectCapacity = 200;
    [SerializeField] private float goldCollectPerSecond = 50f;

    public int CurrentGold { get; set; }
    public int CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }
    public bool IsTimeToCollect { get; set; }

    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        IsTimeToCollect = true;
        CurrentGold = 0;
        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = goldCollectPerSecond;
    }

    public virtual void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, duration: 10f / moveSpeed).OnComplete((() =>
        {
            if (IsTimeToCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }
        })).Play();
    }

    protected virtual void CollectGold()
    {

    }

    protected virtual IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return null;
    }

    protected virtual void DepositGold()
    {

    }

    public void ChangeGoal()
    {
        IsTimeToCollect = !IsTimeToCollect;
    }

    public void RotateMiner(int direction)
    {
        Vector3 minerMoveForward = new(x: 1, y: 1, z: 1);
        Vector3 minerMoveBackward = new(x: -1, y: 1, z: 1);

        if (direction == 1)
        {
            transform.localScale = minerMoveForward;
        }
        else
        {
            transform.localScale = minerMoveBackward;
        }
    }
}
