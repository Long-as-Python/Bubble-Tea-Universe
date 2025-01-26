using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    //public TMP_Text orderNameText; // Текст для назви замовлення
    public Transform ingredientListContainer; // Контейнер для інгредієнтів
    public IngredientUIConfig ingredientUIConfig; // Конфігурація інгредієнтів
    public GameObject plusPrefab; // Префаб для плюса
    public Button prepareButton; // Кнопка "Prepare"

    private Order order;

    public void InitializeOrder(Order order, List<IngredientType> playerInventory)
    {
        this.order = order;

        // Встановити назву замовлення
        //orderNameText.text = order.drinkName;

        // Очистити попередній список інгредієнтів
        foreach (Transform child in ingredientListContainer)
        {
            Destroy(child.gameObject);
        }

        // Додати інгредієнти до списку
        for (int i = 0; i < order.ingredients.Count; i++)
        {
            IngredientType ingredient = order.ingredients[i];

            // Додати інгредієнт
            GameObject ingredientUI = Instantiate(ingredientUIConfig.GetPrefab(ingredient), ingredientListContainer);
            ingredientUI.SetActive(true);

            // Якщо це не останній інгредієнт, додати плюс
            if (i < order.ingredients.Count - 1)
            {
                GameObject plusUI = Instantiate(plusPrefab, ingredientListContainer);
                plusUI.SetActive(true);
            }
        }

        // Активувати/деактивувати кнопку "Prepare"
        prepareButton.interactable = CanPrepare(playerInventory);
        prepareButton.onClick.RemoveAllListeners();
        prepareButton.onClick.AddListener(() => PrepareOrder());
    }

    private bool CanPrepare(List<IngredientType> playerInventory)
    {
        foreach (IngredientType ingredient in order.ingredients)
        {
            if (!playerInventory.Contains(ingredient))
            {
                return false;
            }
        }

        return true;
    }

    private void PrepareOrder()
    {
        Debug.Log($"Order prepared: {order.drinkName}");
        //GameManager.Instance.playerController.ClearIngredients(order.ingredients);
        GameManager.Instance.preparationUI.RemoveOrder(order);
    }
}