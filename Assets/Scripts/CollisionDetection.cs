using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("OnCollisionEnter, collided with: " + other.gameObject.name, gameObject);
        _particleSystem.Play();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("OnTriggerEnter, collided with: " + other.gameObject.name, gameObject);
        _particleSystem.Play();
    }
}
