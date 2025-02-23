using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayers;
    [SerializeField] private UnityEvent onClick;
    public Camera cam;
    public int isCont = 0;
    ProgressManager manager;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        manager = GameObject.FindObjectOfType<ProgressManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),
                                                Vector2.zero, float.PositiveInfinity, clickableLayers);
            if (hit && hit.transform == transform)
            {
                if(isCont == 0){
                    onClick.Invoke();
                }else{
                    manager.keep = true;
                    SceneLoader.LoadPH3();
                }
                
            }
        }
    }
}
