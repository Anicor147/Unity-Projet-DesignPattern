using Unity.VisualScripting;
using UnityEngine;

public class Enemy : PoolObject
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    override public void Reset()
    {
        this.gameObject.SetActive(false);
    }
    
}
