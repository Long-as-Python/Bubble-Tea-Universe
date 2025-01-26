using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public MapController mapController;
    [SerializeField] private bool isJumping = false;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public List<IngredientType> inventory = new List<IngredientType>(); // Список зібраних інгредієнтів
    public UIInventory uiInventory;

    public CameraFollow cameraFollow;
    private float horizontalInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.A))
        {
            SetHorizontalInput(-1f);

            mapController.SetMoveSpeed(-30f); // Рух ліворуч
            SetAnimationSpeed(1f);
            SetFlipDirection(true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            SetHorizontalInput(1f);

            mapController.SetMoveSpeed(30f); // Рух праворуч
            SetAnimationSpeed(1f);
            SetFlipDirection(false);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            SetHorizontalInput(0f);
            SetAnimationSpeed(0f);
            mapController.StopSegments(); // Зупиняємо рух
        }
    }

    public void SetHorizontalInput(float input)
    {
        horizontalInput = input;
        cameraFollow.SetHorizontalInput(horizontalInput);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void SetAnimationSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void SetFlipDirection(bool isFlipped)
    {
        spriteRenderer.flipX = isFlipped;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void CollectIngredient(IngredientType ingredient)
    {
        inventory.Add(ingredient);
        uiInventory.UpdateInventory(inventory); // Оновлюємо UI
    }

    public bool CheckRecipe(Order order, List<IngredientType> selectedIngredients)
    {
        if (order.ingredients.Count != selectedIngredients.Count) return false;

        for (int i = 0; i < order.ingredients.Count; i++)
        {
            if (order.ingredients[i] != selectedIngredients[i])
            {
                return false;
            }
        }

        return true;
    }
}