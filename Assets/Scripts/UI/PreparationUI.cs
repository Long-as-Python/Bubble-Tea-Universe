using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PreparationUI : MonoBehaviour
{
    public Transform orderListContainer; // Контейнер для списку замовлень
    public GameObject orderTemplate; // Шаблон для одного замовлення
    public IngredientUIConfig ingredientUIConfig; // Конфігурація інгредієнтів
    public GameObject plusPrefab; // Префаб для плюса між інгредієнтами
    public Button prepareButton;
    public List<Order> orders = new List<Order>(); // Список замовлень
    public UIInventory uiInventory;

    private void Start()
    {
        // Ініціалізація тестових замовлень
        GenerateTestOrders();
        UpdateOrdersUI();
        prepareButton.onClick.AddListener(RemoveAllOrders);
    }

    private void GenerateTestOrders()
    {
    }

    public void UpdateOrdersUI()
    {
        // Очистити попередній список замовлень
        foreach (Transform child in orderListContainer)
        {
            Destroy(child.gameObject);
        }

        // Створити замовлення на основі списку
        foreach (Order order in orders)
        {
            GameObject orderUI = Instantiate(orderTemplate, orderListContainer);
            orderUI.SetActive(true);

            // Ініціалізувати OrderUI
            orderUI.GetComponent<OrderUI>().InitializeOrder(order, GameManager.Instance.playerController.inventory);
        }
    }

    public void AddOrder(Order newOrder)
    {
        orders.Add(newOrder);
        UpdateOrdersUI();
    }

    public void RemoveOrder(Order order)
    {
        orders.Remove(order);
        UpdateOrdersUI();
    }

    public void RemoveAllOrders()
    {
        orders.Clear();
        UpdateOrdersUI();
        uiInventory.ClearInventoryUI();
    }
}


[System.Serializable]
public class Order
{
    public string drinkName; // Назва напою
    public List<IngredientType> ingredients; // Список інгредієнтів
    public Sprite plusSprite; // Спрайт плюса між інгредієнтами

    public Order(string name, List<IngredientType> requiredIngredients, Sprite plus)
    {
        drinkName = name;
        ingredients = requiredIngredients;
        plusSprite = plus;
    }
}