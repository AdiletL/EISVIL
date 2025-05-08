using UnityEngine;

public class SphereController : UnitController
{
    public override UnitType UnitTypeID { get; } = UnitType.Sphere;
    
    private IMovement movement;
    
    public override void Start()
    {
        base.Start();
        movement = new SphereMovement(gameObject, 5f, transform.forward);
    }

    private void Update()
    {
        movement.ExecuteMovement();
    }
}
