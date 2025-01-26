using System;
using UnityEngine;

public class KitchenTable : MonoBehaviour
{
    public PreparationUI preparationUI; // UI для приготування

    private void Start()
    {
        preparationUI = GameManager.Instance.preparationUI;
        GameManager.Instance.kitchenTable = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowPreparationButton(this); // Показуємо кнопку "Готувати"
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            preparationUI.gameObject.SetActive(false);
            UIManager.Instance.HidePreparationButton(); // Ховаємо кнопку
        }
    }

    public void OpenPreparationUI()
    {
        preparationUI.gameObject.SetActive(true); // Відкриваємо інтерфейс приготування
    }
}