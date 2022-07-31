using System;
using UnityEngine;
using NSubstitute;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public IMover Mover;
    public IPlayerInput PlayerInput = new PlayerInput();
    public int Health { get; private set; } = 100;

    public bool IsDoubleBoosterActive { get; } = true;

    void Start()
    {
        Mover = new TransformMover(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Mover = new TransformMover(this);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Mover = new NavMeshMover(this);

        Mover.Tick();
    }

    public void Heal(int healingAmount)
    {
        if (healingAmount < 0)
            return;

        Health += healingAmount;
    }

    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0)
            return;

        Health -= damageAmount;
    }
}
