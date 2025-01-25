using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 300f;
    public Transform planetCenter;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float uiHorizontalInput = 0f;
    private float keyboardHorizontalInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        keyboardHorizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float combinedInput = keyboardHorizontalInput + uiHorizontalInput;

        Vector2 toPlanetCenter = (planetCenter.position - transform.position).normalized;
        Vector2 tangent = new Vector2(-toPlanetCenter.y, toPlanetCenter.x);

        Vector2 moveDirection = tangent * combinedInput * moveSpeed;

        rb.linearVelocity = moveDirection + new Vector2(0, rb.linearVelocity.y);

        float angle = Mathf.Atan2(toPlanetCenter.y, toPlanetCenter.x) * Mathf.Rad2Deg;

        // Додаємо компенсацію, щоб вирівнювання працювало правильно
        angle -= 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    public void SetHorizontalInput(float input)
    {
        uiHorizontalInput = input;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Vector2 jumpDirection = transform.up;
            rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            isGrounded = false;
        }
    }
}