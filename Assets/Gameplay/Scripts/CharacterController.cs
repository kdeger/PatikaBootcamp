using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class CharacterManager
{
    protected abstract void Attack();
    public abstract void TakeDamage(int damage);
}


public abstract class CharacterController : MonoBehaviour
{
    private void Update()
    {
        Tick();
    }

    public abstract void Tick();

    public virtual void Move(Vector3 movementInput)
    {
        transform.position += movementInput;
    }
}

public class CharacterNavMeshMovementController : CharacterController
{
    NavMeshAgent _navMeshAgent;
    public override void Tick()
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
public class CharacterTransformMovementController : CharacterController
{
    public override void Tick()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Move(new Vector3(horizontal, 0, vertical));
    }
}
