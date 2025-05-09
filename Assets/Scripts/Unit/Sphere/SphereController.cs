using UnityEngine;

public class SphereController : UnitController
{
    public override UnitType UnitTypeID { get; } = UnitType.Sphere;
    
    private IMovable movable;
    
    public override void Start()
    {
        base.Start();
        movable = new SphereMovable(gameObject, 5f, transform.forward);
    }

    private void Update()
    {
        movable.ExecuteMovement();
    }
}
