using System;
using UnityEngine;

public abstract class UnitController : MonoBehaviour, IUnitController
{
    public static Action<IUnitController> OnDeath;
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
 