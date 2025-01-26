using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientUIConfig", menuName = "Configs/Ingredient UI Config")]
public class IngredientUIConfig : ScriptableObject
{
    public List<IngredientUIElement> ingredientElements;

    [System.Serializable]
    public class IngredientUIElement
    {
        public IngredientType ingredientType; // Тип інгредієнта
        public GameObject ingredientPrefab; // Префаб для UI
    }

    public GameObject GetPrefab(IngredientType type)
    {
        foreach (var element in ingredientElements)
        {
            if (element.ingredientType == type)
                return element.ingredientPrefab;
        }
        return null; // Якщо немає префаба для цього типу
    }
}