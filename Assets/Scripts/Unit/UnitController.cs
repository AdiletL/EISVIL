using System;
using UnityEngine;

[Flags]
public enum UnitType
{
    Nothing = 0,
    Everything = ~0,
    Sphere = 1 << 1,
    Cube = 1 << 2,
}

public abstract class UnitController : MonoBehaviour, IKillable
{
    public static Action<UnitController> OnDeath;
    public abstract UnitType UnitTypeID { get; }

    public virtual void Start()
    {
        
    }

    public virtual void ExecuteDeath()
    {
        OnDeath?.Invoke(this);
        Destroy(gameObject);
    }
}
 