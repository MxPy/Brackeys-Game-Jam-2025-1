using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using Unity.Collections;
using UnityEngine;
furrry
public class Item{
      public Item(uint key, string name)
    {
        this.key = key;
        this.name = name;
    }
    public uint key;
    public string name;
    public bool acquired = false;
    
    // Item references
    public static List<Item> ITEMS = new()
    {
        new(0, "cat"),
        new(1, "keys")
    };
}
public class ProgressManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(Item.ITEMS[0].acquired);
        // Item.ITEMS[0].acquired = true;
        // Debug.Log(Item.ITEMS[0].acquired);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
