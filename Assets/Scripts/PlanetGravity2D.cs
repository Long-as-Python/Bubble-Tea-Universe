using UnityEngine;

public class PlanetGravity2D : MonoBehaviour
{
    public Transform planetCenter;
    public float gravityForce = 9.8f;

    public void ApplyGravity(Rigidbody2D objectRb)
    {
        Vector2 planetPosition = new Vector2(planetCenter.position.x, planetCenter.position.y);
        Vector2 objectPosition = new Vector2(objectRb.position.x, objectRb.position.y);
        Vector2 directionToCenter = (planetPosition - objectPosition).normalized;

        objectRb.AddForce(directionToCenter * gravityForce);
    }

}