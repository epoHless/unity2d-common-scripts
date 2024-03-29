using System;
using epoHless;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// The BulletPooler will spawn bullets and shoot them every fireRate time, setting their direction.
/// </summary>
public class BulletPooler : ObjectPooler<Bullet>
{
    [SerializeField] private float fireRate = 0.3f;

    private void Start()
    {
        fireRate = Random.Range(0.1f, 2f);
        TimerManager.Create(Fire, fireRate, true);
    }

    private void Fire()
    {
        var bullet = Get();
        
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        bullet.Shoot(Vector3.right);

    }
}

