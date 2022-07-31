using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BoosterController : Singleton<BoosterController>, IObserver
{
    Queue<IObserver> _queueMode = new Queue<IObserver>();
    [SerializeField] bool _canApplyBooster;
    private ISubject _boosterBase;

    public System.Action<int> OnBoosterActivated;

    public delegate int BoosterActivatedDelegate(int value);
    public BoosterActivatedDelegate BoosterActivated;
    private void Start()
    {
        _boosterBase  = new HealthBooster();  
        _boosterBase.Attach(this); 
        BoosterBase.OnBoosterCollided += InstantiateNewBooster;

        OnBoosterActivated += OnBoosterActivatedEvent;
        BoosterActivated += BoosterActivatedEvent;
    }

    void OnBoosterActivatedEvent(int health)
    {
        Debug.Log("Health: " + health);
    }

    int BoosterActivatedEvent(int value)
    {
        Debug.Log("BoosterActivatedEvent: " + value);
        return value;
    }

    private void OnDestroy()
    {
        _boosterBase.Detach(this); 
        BoosterBase.OnBoosterCollided -= InstantiateNewBooster;
    }

    private void InstantiateNewBooster(BoosterBase booster, Collider collider)
    {
        if (!_canApplyBooster)
            return;
        if (collider.GetComponent<Player>() == null)
            return;

        var player = collider.gameObject.GetComponent<Player>();
        booster.OnBoosterActivated(player);

        GameObject newBooster = Instantiate(booster.gameObject, new Vector3(Random.Range(-180f, 55f), 5, Random.Range(-33f, 215f)), Quaternion.identity);
        Destroy(booster.gameObject);

        int health = BoosterActivated.Invoke(player.Health);
    }

    public void OnNotify()
    {
        throw new System.NotImplementedException();
    }
}
