using UnityEngine;

/// <summary>
/// The BulletPooler will spawn bullets and shoot them every fireRate time, setting their direction.
/// </summary>
public class BulletPooler : ObjectPooler<Bullet>
{
    [SerializeField] private float fireRate = 0.3f;
    private float currentTime = 0f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= fireRate)
        {
            var bullet = Get();
            
            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);
            bullet.Shoot(Vector3.right);

            currentTime = 0f;
        }
    }
}

