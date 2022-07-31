using UnityEngine;
using UnityEngine.AI;

public class NavMeshMover : IMover, IMousePositionToWorldPosition
{
    private Player _player;
    private NavMeshAgent _navMeshAgent;
    private IPlayerInput _playerInput;
    public NavMeshMover(Player player)
    {
        _player = player;
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();
        _playerInput = _player.PlayerInput;
    }

    public Vector3 MousePositionToWorldPosition(Vector3 mousePosition)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(_playerInput.MousePosition), out RaycastHit hit))
            {
                return hit.point;
            }
        }
        return Vector3.zero;
    }

    public void Tick()
    {
        _navMeshAgent.SetDestination(MousePositionToWorldPosition(_playerInput.MousePosition));
    }


}
