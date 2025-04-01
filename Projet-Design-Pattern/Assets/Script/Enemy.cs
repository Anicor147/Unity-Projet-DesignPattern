using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : PoolObject
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float timer = 6f;
    private float timerInterval = 6f;
    private Collider2D col;
    [SerializeField] SpriteRenderer sr2;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>(); 
       col = GetComponentInChildren<Collider2D>();
    }
   
  void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer >= 5)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
           else if (timer <= 4) 
            {
                rb.constraints = RigidbodyConstraints2D.None;
                
                 sr2.gameObject.SetActive(false);
                
               Debug.Log("should pop"); 
            }
            if (timer <= 0)
            {
                timer = timerInterval;
                Reset();
            }
        }
    }

    override public void Reset()
    {
        Debug.Log("Should Reset");
        this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
         rb.linearVelocity = Vector2.down * (speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        col.isTrigger = false;
        sr2.gameObject.SetActive(true);
    }
}
