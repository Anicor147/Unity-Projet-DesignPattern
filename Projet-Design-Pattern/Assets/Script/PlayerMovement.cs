using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject shield;
    private int shieldCharge = 2;

    private void Start()
    {
        shield.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float movement)
    {
        rb.linearVelocity = new Vector2(movement * moveSpeed, 0);
    }

    public void OnShield()
    {
        if (shieldCharge > 0 && !shield.activeInHierarchy)
        {
            shield.SetActive(true);
            shieldCharge--;
            
            EventManager.Instance.TriggerOnShield(shieldCharge);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) shield.SetActive(false);
    }
    
}
