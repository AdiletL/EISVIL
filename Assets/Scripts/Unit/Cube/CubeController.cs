using System;
using UnityEngine;

public class CubeController : UnitController
{
    public override UnitType UnitTypeID { get; } = UnitType.Cube;

    private IMovable movable;
    
    public override void Start()
    {
        base.Start();
        movable = new CubeMovable(gameObject, 4, transform.forward);
    }

    private void Update()
    {
        movable.ExecuteMovement();
    }
}
