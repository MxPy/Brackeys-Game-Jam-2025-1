using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayers;
    [SerializeField] private UnityEvent onClick;
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),
                                                Vector2.zero, float.PositiveInfinity, clickableLayers);
            if (hit && hit.transform == transform)
            {
                onClick.Invoke();
            }
        }
    }
}
