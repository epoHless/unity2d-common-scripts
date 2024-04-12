using UnityEngine;

[System.Serializable]
public struct PooledObject<T> where T : Component
{
    public T Object;
    public int Quantity;
    public bool ShouldExpand;
}
