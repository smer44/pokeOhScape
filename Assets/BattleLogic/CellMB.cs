using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;


public class CellMB : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public UnitMB GetUnitMBFromChildren()
    {
        UnitMB[] unitMBChildren = GetComponentsInChildren<UnitMB>();
        Assert.IsTrue(unitMBChildren.Length <= 1, "Multiple children with UnitMB script detected.");
        //Assert.IsTrue(unitMBChildren.Length == 1, "No children with UnitMB script detected.");

        return unitMBChildren.Length == 0 ? null : unitMBChildren[0];
    }



}
