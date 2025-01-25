using UnityEngine;

public class UIControls : MonoBehaviour
{
    public PlayerController2D playerController; // Посилання на PlayerController

    // Метод викликається кнопкою "←"
    public void MoveLeft()
    {
        playerController.SetHorizontalInput(-1f);
    }

    // Метод викликається кнопкою "→"
    public void MoveRight()
    {
        playerController.SetHorizontalInput(1f);
    }

    // Метод викликається при відпусканні кнопки
    public void StopMovement()
    {
        playerController.SetHorizontalInput(0f);
    }

    // Метод викликається кнопкою "⬆"
    public void Jump()
    {
        playerController.Jump();
    }
}