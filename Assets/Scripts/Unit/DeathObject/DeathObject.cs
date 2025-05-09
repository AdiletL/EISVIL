using System;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IKillable killable))
        {
            killable.ExecuteDeath();
        }
    }
}
