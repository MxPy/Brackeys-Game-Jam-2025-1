using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private LayerMask movableLayers;
    [SerializeField] private bool isMoveRestrictedToScreen = false;
    
    [Header("Screen Margins")]
    [SerializeField] private float leftMargin = 0f;
    [SerializeField] private float rightMargin = 0f;
    [SerializeField] private float topMargin = 0f;
    [SerializeField] private float bottomMargin = 0f;

    private Transform dragging = null;
    private Vector3 offset;
    private Vector3 extents;
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),
                                                Vector2.zero, float.PositiveInfinity, movableLayers);
            if (hit)
            {
                dragging = hit.transform;
                offset = dragging.position - cam.ScreenToWorldPoint(Input.mousePosition);
                extents = dragging.GetComponent<SpriteRenderer>().sprite.bounds.extents;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }

        if (dragging != null)
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
            
            if (isMoveRestrictedToScreen)
            {
                Vector3 topRight = cam.ViewportToWorldPoint(Vector3.one);
                Vector3 bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);

                // Uwzględniamy marginesy przy ograniczaniu pozycji
                float minX = bottomLeft.x + extents.x + leftMargin;
                float maxX = topRight.x - extents.x - rightMargin;
                float minY = bottomLeft.y + extents.y + bottomMargin;
                float maxY = topRight.y - extents.y - topMargin;

                pos.x = Mathf.Clamp(pos.x, minX, maxX);
                pos.y = Mathf.Clamp(pos.y, minY, maxY);
            }

            dragging.position = pos;
        }
    }
}