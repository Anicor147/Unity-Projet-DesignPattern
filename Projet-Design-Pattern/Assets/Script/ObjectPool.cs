using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]private List<PoolObject> objectPool;
    private int objectPoolIndex;

    private void Awake()
    {
        objectPool = GetComponentsInChildren<PoolObject>(true).ToList();
    }

    internal PoolObject GetObject()
    {
        objectPoolIndex %= objectPool.Count;
        var next = objectPool[objectPoolIndex++];
         next.Reset();
        return next;
    }
}
