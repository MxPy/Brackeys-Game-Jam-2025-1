using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitElement : MonoBehaviour
{

    public GameObject diode;
    string itemName = "";
    public string desiredName;
    public int decisionId;
    ProgressManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<ProgressManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(itemName == ""){
            itemName = other.name;
            diode.SetActive(true);
            if (itemName == desiredName){
                manager.PH2Decisions[decisionId].pass = ! manager.PH2Decisions[decisionId].pass;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name == itemName){
            itemName = "";
            diode.SetActive(false);
            if (other.name == desiredName){
                manager.PH2Decisions[decisionId].pass = ! manager.PH2Decisions[decisionId].pass;
            }
        }
        
    }
}
