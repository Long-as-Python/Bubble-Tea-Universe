using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Синглтон для доступу з інших скриптів
    public Button pickupButton; // Кнопка "Підібрати"
    private ICollectable currentCollectable; // Поточний об'єкт для збору
    public Button preparationButton;
    private KitchenTable currentTable;

    public void ShowPreparationButton(KitchenTable table)
    {
        currentTable = table;
        preparationButton.gameObject.SetActive(true);
    }

    public void HidePreparationButton()
    {
        currentTable = null;
        preparationButton.gameObject.SetActive(false);
    }

    public void OnPreparationButtonPressed()
    {
        currentTable?.OpenPreparationUI();
        HidePreparationButton();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pickupButton.onClick.AddListener(OnPickupButtonPressed);
        preparationButton.onClick.AddListener(OnPreparationButtonPressed);
    }

    public void ShowPickupButton(ICollectable collectable)
    {
        currentCollectable = collectable;
        pickupButton.gameObject.SetActive(true);
    }

    public void HidePickupButton()
    {
        currentCollectable = null;
        pickupButton.gameObject.SetActive(false);
    }

    public void OnPickupButtonPressed()
    {
        if (currentCollectable != null)
        {
            currentCollectable.Collect(); // Викликаємо метод Collect для об'єкта
            HidePickupButton();
        }
    }
}