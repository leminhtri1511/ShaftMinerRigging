using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [SerializeField] private Transform shaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    private Animator _animator;
    private int miningAnimationParameter = Animator.StringToHash("Mining");
    private int walkingAnimationParameter = Animator.StringToHash("Walking");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ChangeGoal();
        RotateMiner(-1);
        MoveMiner(shaftDepositLocation.position);
    }

    protected override void DepositGold()
    {
        CurrentGold = 0;
        ChangeGoal();
        RotateMiner(1);
        MoveMiner(shaftMiningLocation.position);
    }

}
