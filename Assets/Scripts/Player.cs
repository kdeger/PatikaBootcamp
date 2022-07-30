using UnityEngine;

public class Player : MonoBehaviour
{
    private IMover _mover;
    private IPlayerInput _playerInput;
    public int Health{ get; private set; } = 100;

    void Start()
    {
        _playerInput = new PlayerInput();
        _mover = new TransformMover(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _mover = new TransformMover(this);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _mover = new NavMeshMover(this);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _playerInput = new PlayerInput();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            _playerInput = new StaticInput();

        _mover.Tick();
    }

    public void AddHealth(int amount)
    {
        Health += amount;
    }
}
