using UnityEngine;

public class UIControls : MonoBehaviour
{
    public MapController mapController;
    public PlayerController2D playerController2D;

    public void MoveLeft()
    {
        playerController2D.SetHorizontalInput(-1f);
        mapController.SetMoveSpeed(-30f); // Рух вліво
        playerController2D.SetAnimationSpeed(1f); // Запускаємо анімацію
        playerController2D.SetFlipDirection(true); // Фліпаємо спрайт вліво
    }

    public void MoveRight()
    {
        playerController2D.SetHorizontalInput(1f);
        mapController.SetMoveSpeed(30f); // Рух вправо
        playerController2D.SetAnimationSpeed(1f); // Запускаємо анімацію
        playerController2D.SetFlipDirection(false); // Фліпаємо спрайт вправо
    }
 
    public void StopMovement()
    {
        playerController2D.SetHorizontalInput(0f);
        mapController.StopSegments(); // Зупиняємо рух
        playerController2D.SetAnimationSpeed(0f); // Зупиняємо анімацію
    }

    public void Jump()
    {
        playerController2D.Jump();
    }
}