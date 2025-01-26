using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public GameObject ingredientTemplate; // Шаблон тексту для інгредієнтів
    public Transform inventoryList; // Контейнер для списку інгредієнтів

    private Dictionary<IngredientType, GameObject> ingredientUIItems = new Dictionary<IngredientType, GameObject>();

    public void UpdateInventory(List<IngredientType> inventory)
    {
        foreach (IngredientType ingredient in inventory)
        {
            if (!ingredientUIItems.ContainsKey(ingredient))
            {
                GameObject newItem = Instantiate(ingredientTemplate, inventoryList);
                newItem.GetComponent<TMP_Text>().text = ingredient.ToString(); // Виводимо тип інгредієнта
                newItem.SetActive(true); // Увімкнути, якщо шаблон був вимкнений
                ingredientUIItems[ingredient] = newItem;
            }
        }
    }

    public void ClearInventoryUI()
    {
        foreach (var item in ingredientUIItems.Values)
        {
            Destroy(item);
        }
        ingredientUIItems.Clear();
    }
}