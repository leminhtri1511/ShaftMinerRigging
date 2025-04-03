using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager : Singleton<ShaftManager>
{
    [SerializeField] private Shaft shaftPrefab;
    [SerializeField] private float newShaftYPosition;
    [SerializeField] private int newShaftCost = 500;

    [Header("Shaft")]
    [SerializeField] private List<Shaft> shafts;

    public List<Shaft> Shafts => shafts;

    public int NewShaftCost => newShaftCost;

    public List<Shaft> ShaftList => shafts;

    public void AddShaft()
    {
        Transform lastShaft = shafts[0].transform;

        Shaft newShaft = Instantiate(shaftPrefab, lastShaft.position, Quaternion.identity);
        newShaft.transform.localPosition = new Vector3(
            lastShaft.position.x,
            lastShaft.position.y - newShaftYPosition,
            lastShaft.position.z
        );

        shafts.Add(newShaft);
    }
}
