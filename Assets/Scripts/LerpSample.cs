using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSample : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Transform _targetObject;
    float startTime = 0f;
    [SerializeField] float speedCoef;
    float journeyLength = 0f;
    public Transform TestTransform { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        journeyLength = Vector3.Distance(startingPosition, _targetObject.position);
        GetComponent<AnimationCurveDemo>().OnAnimationFinished += TriggerParticle;
    }

    // Update is called once per frame
    void Update()
    {



        float distanceCovered = (Time.time - startTime) * speedCoef;

        float journeyFraction = distanceCovered / journeyLength;
         
        transform.position = Vector3.Lerp(startingPosition, _targetObject.position, journeyFraction);
        //transform.position = Vector3.Slerp(startingPosition, _targetObject.position, journeyFraction);
        transform.RotateAround(_targetObject.position, Vector3.up, speedCoef * Time.deltaTime);
    }

    private void TriggerParticle(GameObject gameObject)
    {

    }
}
