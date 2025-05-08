using System;
using UnityEngine;

public class CubeController : UnitController
{
    public override UnitType UnitTypeID { get; } = UnitType.Cube;

    private IMovement movement;
    
    public override void Start()
    {
        base.Start();
        movement = new CubeMovement(gameObject, 4, transform.forward);
    }

    private void Update()
    {
        movement.ExecuteMovement();
    }
}
