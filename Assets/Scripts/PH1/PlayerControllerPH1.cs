using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPH1 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D body;
    public Vector2 movement;
    //public Animator animator;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //SceneLoader.LoadPH2();
    }
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero){
            //animator.SetFloat("Horizontal", movement.x);
            //animator.SetFloat("Vertical", movement.y);
        }
        //animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate(){
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }
}
