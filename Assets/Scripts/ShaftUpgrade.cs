using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftUpgrade : BaseUpgrade
{
    protected override void RunUpgrade()
    {
        if (_shaft != null)
        {
            Debug.Log("This is working");
        }
    }
}
