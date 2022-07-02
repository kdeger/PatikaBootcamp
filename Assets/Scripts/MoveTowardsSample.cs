using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsSample : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    [SerializeField] float speedCoef;

    Rigidbody _rigidbody;
    Vector3 _distanceToTarget;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // float movementSpeed = speedCoef * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, _targetObject.position, movementSpeed);


        // _distanceToTarget = _targetObject.position - transform.position;
        // _distanceToTarget.Normalize();
        // _rigidbody.AddForce(_distanceToTarget * speedCoef);
    }

    private void LateUpdate()
    {
        var targetPosition = _targetObject.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedCoef * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        // Vector3 _distanceToTarget = _targetObject.position - transform.position;
        // Gizmos.color = Color.red;
        // Gizmos.DrawLine(transform.position, transform.position + _distanceToTarget);

        // Gizmos.color = Color.green;
        // Gizmos.DrawLine(_targetObject.position, transform.position + _distanceToTarget.normalized);
    }
}
