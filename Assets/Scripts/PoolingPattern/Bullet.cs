using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<Bullet> Pool;
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke(nameof(Release), 3f);
    }

    private void Release()
    {
        Pool.Release(this);
    }
}
