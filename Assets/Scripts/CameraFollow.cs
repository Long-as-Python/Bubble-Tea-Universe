using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ціль (гравець)
    public float smoothSpeed = 0.125f; // Швидкість плавного слідування
    public Vector3 offset; // Відступ камери

    void LateUpdate()
    {
        // Розрахунок нової позиції камери
        Vector3 desiredPosition = target.position + offset;

        // Плавний перехід до бажаної позиції
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Фіксуємо Z-позицію для 2D
        smoothedPosition.z = transform.position.z;

        // Застосовуємо нову позицію
        transform.position = smoothedPosition;
    }
}