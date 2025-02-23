using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPH1 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D body;
    public Vector2 movement;
    public GameObject dialog;
    public string objName = "";
    ProgressManager manager;
    //public Animator animator;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //SceneLoader.LoadPH2();
        manager = GameObject.FindObjectOfType<ProgressManager>();
    }
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero){
            //animator.SetFloat("Horizontal", movement.x);
            //animator.SetFloat("Vertical", movement.y);
        }
        //animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.F) && dialog.activeSelf)
        {
            manager.showDialog(objName);
        }

    }

    void FixedUpdate(){
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        dialog.SetActive(true);
        objName = other.name;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(dialog.activeSelf == false){
            dialog.SetActive(true);
            objName = other.name;
        }
        
    }
    void OnTriggerExit2D(Collider2D other){
        dialog.SetActive(false);
        manager.hideDialog();
    }
}
