using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPooler<T> : MonoBehaviour where T : Component
{
    [field: SerializeField] public PooledObject<T> PooledObject { get; set; }
    [SerializeField] private Transform parent; 

    private List<T> pool;

    protected virtual void Awake()
    {
        pool = new List<T>();
        Initialize();
    }

    public T Get() 
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
            Initialize();
            return pool[^PooledObject.Quantity];
        }

        return null;
    }
    
    public void Initialize()
    {
        for (int i = 0; i < PooledObject.Quantity; i++)
        {
            var obj = Instantiate(PooledObject.Object, parent ?? transform);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }
}