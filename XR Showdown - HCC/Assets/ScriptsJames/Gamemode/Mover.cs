using UnityEngine;

public class Mover : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        rb.velocity = transform.right * speed;
    }
}
