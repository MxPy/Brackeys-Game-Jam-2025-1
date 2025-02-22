using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    public List<GameObject> times = new();
    public int desiredTime = 1;
    int actualTime = 1;

    public void Next(){
        if(actualTime+1 < times.Count){
            actualTime++;
            times[actualTime].SetActive(true);
        }
    }
    public void Prev(){
        if(actualTime-1 >= 0){
            times[actualTime].SetActive(false);
            actualTime--;
            
        }
    }
}
