using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Core References")]
    public UIManager uiManager; // Посилання на UIManager
    public PreparationUI preparationUI; // Інтерфейс приготування
    public PlayerController2D playerController; // Гравець
    public KitchenTable kitchenTable; // Кухонний стіл

    private void Awake()
    {
        // Ініціалізація синглтона
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenPreparationUI()
    {
        preparationUI.gameObject.SetActive(true);
    }

    public void ClosePreparationUI()
    {
        preparationUI.gameObject.SetActive(false);
    }

    public UIManager GetUIManager()
    {
        return uiManager;
    }

    public PlayerController2D GetPlayerController()
    {
        return playerController;
    }

    public KitchenTable GetKitchenTable()
    {
        return kitchenTable;
    }
}