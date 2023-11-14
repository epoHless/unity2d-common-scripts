using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In order to use this class you MUST inherit from it and specify the type of MonoBehaviour you want to pool.
/// When calling the Get() function remember to cache it into a variable: "var obj = Get()" and to enable the GameObject.
/// You are also responsible of turning the GameObject off with the gameObject.SetActive(false) method in order to release it into the pool again.
/// Check BulletPooler for a use case.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ObjectPooler<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private PooledObject<T> PooledObject;
    [SerializeField] private Transform parent; //the parent the pooled object will be attached to

    private List<T> pool;

    protected virtual void Awake()
    {
        pool = new List<T>();
        Initialize(PooledObject.Quantity);
    }

    public T Get() //call this method to get an object from the pool as a reference
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i];
            }
        }
        
        if(PooledObject.ShouldExpand)
        {
            Initialize(10);
            return pool[^10];
        }

        return null;
    }
    
    protected void Initialize(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var obj = Instantiate(PooledObject.Object, parent);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }
}
