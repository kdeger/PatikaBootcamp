using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsSample : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    [SerializeField] float speedCoef;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = speedCoef * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetObject.position, movementSpeed);
    }
}
