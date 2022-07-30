using UnityEngine;
using UnityEngine.AI;

public class NavMeshMover : IMover
{
    private Player _player;
    private NavMeshAgent _navMeshAgent;
    public NavMeshMover(Player player)
    {
        _player = player;
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();
    }
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
