using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] segmentPrefabs; // Префаби сегментів
    public Transform planetCenter; // Центр планети
    public float radius = 10f; // Радіус кола
    public Camera mainCamera; // Камера для перевірки видимості
    public float moveSpeed = 0f; // Поточна швидкість руху сегментів
    public int bufferSegments = 2; // Кількість активних сегментів з кожного боку

    private List<MapSegment> allSegments = new List<MapSegment>(); // Усі сегменти (активні + неактивні)

    void Start()
    {
        InitializeSegments(); // Створення сегментів
        PositionSegments(); // Розташування сегментів
    }

    void Update()
    {
        if (moveSpeed != 0f)
        {
            UpdateSegmentPositions(); // Рух сегментів
        }

        UpdateSegmentVisibility(); // Оновлення видимості
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void StopSegments()
    {
        moveSpeed = 0f;
    }

    private void InitializeSegments()
    {
        foreach (GameObject prefab in segmentPrefabs)
        {
            GameObject segmentInstance = Instantiate(prefab, transform); // Створюємо сегмент із префабу
            MapSegment segment = segmentInstance.GetComponent<MapSegment>();
            allSegments.Add(segment);
            segment.gameObject.SetActive(false); // Усі сегменти спочатку дезактивовані
        }
    }

    private void PositionSegments()
    {
        float angleStep = 360f / allSegments.Count;
        float currentAngle = 0f;

        foreach (MapSegment segment in allSegments)
        {
            Vector3 position = GetPositionOnCircle(currentAngle);
            segment.transform.position = position;
            segment.transform.rotation = Quaternion.Euler(0, 0, currentAngle - 90f); // Поворот від центру
            currentAngle += angleStep;
        }
    }
    
    private void UpdateSegmentPositions()
    {
        foreach (MapSegment segment in allSegments)
        {
            Vector3 currentPosition = segment.transform.position;
            float angle = Mathf.Atan2(currentPosition.y - planetCenter.position.y, currentPosition.x - planetCenter.position.x) * Mathf.Rad2Deg;

            angle += moveSpeed * Time.deltaTime;

            Vector3 newPosition = GetPositionOnCircle(angle);
            segment.transform.position = newPosition;
            segment.transform.rotation = Quaternion.Euler(0, 0, angle - 90f); // Поворот від центру
        }
    }
    
    private void UpdateSegmentVisibility()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        foreach (MapSegment segment in allSegments)
        {
            float distanceFromCamera = Vector3.Distance(segment.transform.position, cameraPosition);
            float segmentAngle = Mathf.Atan2(segment.transform.position.y - planetCenter.position.y, segment.transform.position.x - planetCenter.position.x) * Mathf.Rad2Deg;

            // Включаємо сегменти, якщо вони в зоні видимості + буфер
            if (IsWithinBuffer(segmentAngle))
            {
                if (!segment.gameObject.activeSelf)
                {
                    segment.gameObject.SetActive(true);
                }
            }
            else
            {
                if (segment.gameObject.activeSelf)
                {
                    segment.gameObject.SetActive(false);
                }
            }
        }
    }

    private bool IsWithinBuffer(float segmentAngle)
    {
        float cameraAngle = Mathf.Atan2(mainCamera.transform.position.y - planetCenter.position.y, mainCamera.transform.position.x - planetCenter.position.x) * Mathf.Rad2Deg;

        float minAngle = cameraAngle - bufferSegments * (360f / allSegments.Count);
        float maxAngle = cameraAngle + bufferSegments * (360f / allSegments.Count);

        // Перевіряємо, чи знаходиться сегмент у буферній зоні
        return segmentAngle >= minAngle && segmentAngle <= maxAngle;
    }

    private Vector3 GetPositionOnCircle(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float x = planetCenter.position.x + radius * Mathf.Cos(radian);
        float y = planetCenter.position.y + radius * Mathf.Sin(radian);
        return new Vector3(x, y, 0f);
    }
}
