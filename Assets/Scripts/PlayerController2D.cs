using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public MapController mapController;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private bool isJumping = false;

    public List<string> inventory = new List<string>(); // Список зібраних інгредієнтів
    public TMPro.TextMeshProUGUI inventoryText;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Гравець дивиться вправо
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Гравець дивиться вліво
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.A))
        {
            mapController.SetMoveSpeed(-30f); // Рух ліворуч
        }

        if (Input.GetKey(KeyCode.D))
        {
            mapController.SetMoveSpeed(30f); // Рух праворуч
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            mapController.StopSegments(); // Зупиняємо рух
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    public void CollectIngredient(string ingredient)
    {
        inventory.Add(ingredient);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        inventoryText.text = $"Інвентар:\n{string.Join("\n", inventory)}";
    }
}