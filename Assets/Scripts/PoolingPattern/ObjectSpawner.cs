using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public int randomNumber = 0;
    private ObjectPool _objectPool;

    private void Start() {
        _objectPool = gameObject.AddComponent<ObjectPool>();
    }
    private void OnGUI()
    {
        if (GUILayout.Button("Spawn"))
        {
            _objectPool.Spawn();
        }
    }
}
