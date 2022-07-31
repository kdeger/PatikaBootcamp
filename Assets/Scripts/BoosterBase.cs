using System;
using System.Collections;
using UnityEngine;

public abstract class BoosterBase : MonoBehaviour, ISubject
{
    public static event Action<BoosterBase, Collider> OnBoosterCollided;
    public static event Action OnSubjectCompletedAction;

    ArrayList _observers = new ArrayList();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        OnSubjectCompletedAction += observer.OnNotify;
    }

    public virtual void BoosterCollided(Collider other)
    {
        OnBoosterCollided?.Invoke(this, other);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        OnSubjectCompletedAction -= observer.OnNotify;
    }

    public void Notify()
    {
        foreach (IObserver item in _observers)
        {
            item.OnNotify();
        }

        OnSubjectCompletedAction?.Invoke();
    }

    public abstract void OnBoosterActivated(Player player);


    public virtual void OnTriggerEnter(Collider other)
    {
        BoosterCollided(other);
    }
}

public interface IObserver
{
    void OnNotify();

}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
