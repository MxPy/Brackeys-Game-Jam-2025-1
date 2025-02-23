using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FitElement : MonoBehaviour
{

    public GameObject diode;
    string itemName = "";
    public string desiredType;
    public string desiredName;
    public int decisionId;
    public GameObject actv;
    public TextMeshProUGUI name;
    ProgressManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<ProgressManager>();
        if(manager.whichKey == 0 && desiredType == "key"){
            desiredName = "key1";
            Debug.Log("sdfdsfsddfs");
        }
        if(manager.whichKey == 1 && desiredType == "key"){
            desiredName = "key2";
        }
        if(manager.whichNote == 0 && desiredType == "note"){
            desiredName = "note1";
        }
        if(manager.whichNote == 1 && desiredType == "note"){
            desiredName = "note2";
        }
        if(manager.whichNote == 2 && desiredType == "note"){
            desiredName = "note3";
        }
        if(manager.whichSec == 0 && desiredType == "alarm"){
            desiredName = "alarm1";
        }
        if(manager.whichSec == 1 && desiredType == "alarm"){
            desiredName = "alarm2";
        }
        if(manager.whichSec == 2 && desiredType == "alarm"){
            desiredName = "alarm3";
        }
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
            Debug.Log(itemName);
            Debug.Log(desiredName);
            if (itemName == desiredName){
                
                manager.PH2Decisions[decisionId].pass = ! manager.PH2Decisions[decisionId].pass;
            }
            actv.SetActive(true);
            int itemm = -1;
            if(manager.items_map.TryGetValue(itemName, out itemm)){
                name.text = manager.items[itemm].name;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name == itemName){
            itemName = "";
            if(diode) diode.SetActive(false);
            if(actv) actv.SetActive(false);
            if (other.name == desiredName && !manager.keep){
                manager.PH2Decisions[decisionId].pass = ! manager.PH2Decisions[decisionId].pass;
            }
        }
        
    }
}
