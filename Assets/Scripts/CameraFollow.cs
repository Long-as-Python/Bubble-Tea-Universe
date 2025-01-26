using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Гравець
    public float smoothSpeed = 0.125f; // Швидкість плавного слідування
    public Vector3 offset; // Відступ камери від гравця
    public float lookAheadDistance = 2f; // Дистанція випередження камери в напрямку руху

    private Vector3 velocity = Vector3.zero;
    private float horizontalInput = 0f; // Напрямок руху

    void LateUpdate()
    {
        // Отримуємо напрямок руху гравця
        Vector3 lookAhead = Vector3.right * horizontalInput * lookAheadDistance;

        // Визначаємо бажану позицію камери
        Vector3 desiredPosition = player.position + offset + lookAhead;

        // Згладжуємо рух камери
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        smoothedPosition.z = transform.position.z; // Фіксуємо Z-позицію для 2D
        transform.position = smoothedPosition;
    }
    
    public void SetHorizontalInput(float input)
    {
        horizontalInput = input;
    }

}