using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Синглтон для доступу з інших скриптів
    public Button pickupButton; // Кнопка "Підібрати"

    private ICollectable currentCollectable; // Поточний об'єкт для збору

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