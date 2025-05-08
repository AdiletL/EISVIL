using System;

[Flags]
public enum UnitType
{
    Nothing = 0,
    Everything = ~0,
    Sphere = 1 << 1,
    Cube = 1 << 2,
}

public interface IUnitController : IDeathatable
{
    public static Action<IUnitController> OnDeath;
    
    public UnitType UnitTypeID { get; }
}
