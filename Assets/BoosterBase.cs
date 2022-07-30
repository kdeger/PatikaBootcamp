using System;
using UnityEngine;

public abstract class BoosterBase : MonoBehaviour
{
    public static event Action<BoosterBase, Collider> OnBoosterCollided;

    public virtual void BoosterCollided(Collider other)
    {
        OnBoosterCollided?.Invoke(this, other);
    }

    public abstract void OnBoosterActivated(Player player);
    public virtual void OnTriggerEnter(Collider other)
    {
        BoosterCollided(other);
    }
}
