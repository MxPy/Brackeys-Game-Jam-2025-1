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
      public Item(uint key, string name)
    {
        this.key = key;
        this.name = name;
    }
    public uint key;
    public string name;
    public bool acquired = false;
    public int x;
    public int y;
    public GameObject PH2Obj;


    
    
    public GameObject CreateObject()
    {
        Debug.Log($"dddddd object {name} at position {x}, {y}");
        if (PH2Obj != null)
        {
            Debug.Log($"Creating object {name} at position {x}, {y}");
            UnityEngine.Vector3 position = new UnityEngine.Vector3(x, y, 0);
            GameObject obj = GameObject.Instantiate(PH2Obj, position, UnityEngine.Quaternion.identity);
            obj.name = name;
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
        new(0, "cat"),
        new(1, "keys")
    };
    public VariableTimer timer;
    public float timeToEndPH1 = 120;
    // Start is called before the first frame update
    public TextMeshProUGUI timerText;
    public int phaseActive = 0;
    public void StartFirstPhase(){
        
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
        new("door1", false),
        new("door2", false),
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
    }
}
