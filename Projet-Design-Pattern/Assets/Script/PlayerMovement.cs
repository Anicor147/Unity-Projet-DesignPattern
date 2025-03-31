using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float movement)
    {
        rb.linearVelocity = new Vector2(movement * moveSpeed, 0);
    }
}
