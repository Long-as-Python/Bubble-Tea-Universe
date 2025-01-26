using UnityEngine;

public class Ingredient : MonoBehaviour, ICollectable
{
    public IngredientType ingredientType; // Тип інгредієнта

    public void Collect()
    {
        PlayerController2D player = FindObjectOfType<PlayerController2D>();
        player.CollectIngredient(ingredientType);
        Destroy(gameObject); // Видаляємо інгредієнт після збору
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowPickupButton(this); // Показуємо кнопку "Підібрати"
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.HidePickupButton(); // Ховаємо кнопку
        }
    }
}