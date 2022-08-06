using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int _defaultPoolCapacity;
    [SerializeField] int _maxPoolSize;
    public IObjectPool<Bullet> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease, OnBulletDestroy, true, _defaultPoolCapacity, _maxPoolSize);
            }
            return _pool;
        }
    }

    private IObjectPool<Bullet> _pool;

    private Bullet CreateBullet()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bullet.AddComponent<Bullet>();
        Bullet instantiatedBullet = bullet.GetComponent<Bullet>();
        instantiatedBullet.Pool = Pool;
        return instantiatedBullet;
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    public void Spawn()
    {
        Bullet bullet = Pool.Get();
        // bullet.transform.position = transform.position;
        // bullet.transform.rotation = transform.rotation;
    }
}
