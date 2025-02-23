using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using TMPro;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class Item{
      public Item(uint key, string name, string id)
    {
        this.key = key;
        this.name = name;
        this.id = id;
    }
    public uint key;
    public string name;
    public bool acquired = false;
    public float x;
    public float y;
    public GameObject PH2Obj;
    public string id;

    
    
    public GameObject CreateObject()
    {
        Debug.Log($"dddddd object {name} at position {x}, {y}");
        if (PH2Obj != null)
        {
            Debug.Log($"Creating object {id} at position {x}, {y}");
            UnityEngine.Vector3 position = new UnityEngine.Vector3(x, y, 0);
            GameObject obj = GameObject.Instantiate(PH2Obj, position, UnityEngine.Quaternion.identity);
            obj.name = id;
            return obj;
        }
        Debug.LogWarning($"PH2Obj prefab is not assigned for item: {name}");
        return null;
    }

}
[Serializable]
public class Decision{
    public Decision(string name, bool pass){
        this.name = name;
        this.pass = pass;
        
    }
    public string name;
    public bool pass;
    
}

public class ProgressManager : MonoBehaviour
{
    public List<Item> items = new(){
        new(0, "silent alarm", "alarm1"),
        new(1, "laser alarm", "alarm2"),
        new(2, "cameras", "alarm3"),
        new(3, "small key", "key1"),
        new(4, "big key", "key2"),
        new(5, "red note","note1"),
        new(6, "blue note","note2"),
        new(7, "yellow note","note3"),
    };
    public Dictionary<string, int> items_map = new(){
        {"alarm1", 0},
        {"alarm2", 1},
        {"alarm3", 2},
        {"key1", 3},
        {"key2", 4},
        {"note1", 5},
        {"note2", 6},
        {"note3", 7},
    };

    public VariableTimer timer;
    public float timeToEndPH1 = 120;
    // Start is called before the first frame update
    public TextMeshProUGUI timerText;
    public int phaseActive = 0;

    public int whichSec = 0;
    public int whichKey = 0;
    public int whichTime = 0;
    public int whichNote = 0;
    public GameObject dialogWindow;
    public TextMeshProUGUI dialogtext;
    bool allDecisionsPass = true;
    public bool keep = false;
    public void showDialog(string key){
        dialogWindow.SetActive(true);
        Debug.Log(key);
        if(key == "alarm1"){
            dialogtext.text = "Looks like a silent alarm";
        }
        if(key == "alarm2"){
            dialogtext.text = "Looks like a laser alarm";
        }
        if(key == "alarm3"){
            dialogtext.text = "Looks like a camera system";
        }
        if(key == "keyM" && whichKey == 0){
            dialogtext.text = "Remember we use the small key this week!";
        }
        else if(key == "keyM" && whichKey == 1){
            dialogtext.text = "Remember we use the big key this week!";
        }
        if(key == "key1"){
            dialogtext.text = "You found a small key";
        }
        if(key == "key2"){
            dialogtext.text = "You found a big key";
        }
        if(key == "note1"){
            dialogtext.text = "You found a red note";
        }
        if(key == "note2"){
            dialogtext.text = "You found a blue note";
        }
        if(key == "note3"){
            dialogtext.text = "You found a yellow note";
        }
        if(key == "noteM" && whichNote == 0){
            dialogtext.text = "I remember that you wrote the safe code on the red note";
        }
        else if(key == "noteM" && whichNote == 1){
            dialogtext.text = "I remember that you wrote the safe code on the blue note";
        }
        else if(key == "noteM" && whichNote == 2){
            dialogtext.text = "I remember that you wrote the safe code on the yellow note";
        }
        if(key == "secM" && whichSec == 0){
            dialogtext.text = "Oh! The cameras and laser alarm are broken again...";
        }
        else if(key == "secM" && whichSec == 1){
            dialogtext.text = "Oh! The cameras and silent alarm are broken again...";
        }
        else if(key == "secM" && whichSec == 2){
            dialogtext.text = "Oh! The silent alarm and laser alarm are broken again...";
        }
        if(key == "timeM" && whichTime == 0){
            dialogtext.text = "I'll be late for my shift tomorrow at 6:15";
        }
        else if(key == "timeM" && whichTime == 1){
            dialogtext.text = "I'll be late for my shift tomorrow at 7:30";
        }
        else if(key == "timeM" && whichTime == 2){
            dialogtext.text = "I'll be late for my shift tomorrow at 8:45";
        }
        else if(key == "idk"){
            dialogtext.text = "Nice weather today";
        }



        int itemm = -1;
        if(items_map.TryGetValue(key, out itemm)){
            items[itemm].acquired = true;
        }
        
    }

    public void hideDialog(){
        if(dialogWindow){
            dialogWindow.SetActive(false);
        }
        
    }

    public void StartFirstPhase(){
        whichSec = UnityEngine.Random.Range(0,3);
        
        whichKey = UnityEngine.Random.Range(0, 2);
        
        whichTime = UnityEngine.Random.Range(0, 3);

        whichNote = UnityEngine.Random.Range(0, 3);
    }
    public void StartSecondPhase(){
        foreach (var item in items)
        {
            if (item.acquired){
                item.CreateObject();
            }
        } 
    }

    public List<Decision> PH2Decisions = new(){
        new("alarm", false),
        new("key", false),
        new("note", false),
        new("time", false),
    };

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }

    void Start()
    {
        // Debug.Log(Item.ITEMS[0].acquired);
        // Item.ITEMS[0].acquired = true;
        // Debug.Log(Item.ITEMS[0].acquired);
        timer.StartTimer(timeToEndPH1);

    }

    // Update is called once per frame
    void Update()
    {
        if (phaseActive == 0)
        {
            timerText.text = timer.timeLeft;
            if(timer.finished){
                phaseActive = 1;
                SceneLoader.LoadPH2();
            }
        }
        if (phaseActive == 1)
        {
            // allDecisionsPass = true;
            // // Sprawdź wszystkie decyzje w tablicy
            // foreach (var decision in PH2Decisions)
            // {
            //     if (!decision.pass)
            //     {
            //         allDecisionsPass = false;
            //         break;
            //     }
            // }
            
            // // Jeśli wszystkie decyzje są pass, załaduj następną fazę
            // if (allDecisionsPass)
            // {
            //     SceneLoader.LoadPH3();
            // }
        }
    }
}
