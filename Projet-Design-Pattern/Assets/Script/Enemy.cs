using System;
using UnityEngine;

public class Enemy : PoolObject
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float timer = 5f;
    private float timerInterval = 5f;
    private Collider2D col;

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
    }
}
