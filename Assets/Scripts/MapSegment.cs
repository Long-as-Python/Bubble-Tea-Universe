using UnityEngine;

public class MapSegment : MonoBehaviour
{
    public float GetWidth()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        return collider.size.x * transform.localScale.x;
    }
}