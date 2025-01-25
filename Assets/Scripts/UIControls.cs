using UnityEngine;

public class UIControls : MonoBehaviour
{
    public MapController mapController;
    public PlayerController2D playerController2D;

    public void MoveLeft()
    {
        mapController.SetMoveSpeed(-30f); // Рух вліво
    }

    public void MoveRight()
    {
        mapController.SetMoveSpeed(30f); // Рух вправо
    }

    public void StopMovement()
    {
        mapController.StopSegments(); // Зупиняємо рух
    }

    public void Jump()
    {
        playerController2D.Jump();
    }
}