using UnityEngine;

public class UIControls : MonoBehaviour
{
    public MapController mapController;
    public PlayerController2D playerController2D;

    public void MoveLeft()
    {
        mapController.SetMoveSpeed(-30f); // Рух вліво
        playerController2D.SetAnimationSpeed(1f); // Запускаємо анімацію
        playerController2D.SetFlipDirection(true); // Фліпаємо спрайт вліво
    }

    public void MoveRight()
    {
        mapController.SetMoveSpeed(30f); // Рух вправо
        playerController2D.SetAnimationSpeed(1f); // Запускаємо анімацію
        playerController2D.SetFlipDirection(false); // Фліпаємо спрайт вправо
    }

    public void StopMovement()
    {
        mapController.StopSegments(); // Зупиняємо рух
        playerController2D.SetAnimationSpeed(0f); // Зупиняємо анімацію
    }

    public void Jump()
    {
        playerController2D.Jump();
    }
}