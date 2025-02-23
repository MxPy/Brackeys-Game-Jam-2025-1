using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    public List<GameObject> times = new();
    public int desiredTime = 1;
    public int actualTime = 1;
    ProgressManager manager;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        manager = GameObject.FindObjectOfType<ProgressManager>();
        if (actualTime == manager.whichTime){
            manager.PH2Decisions[3].pass = true;
        }else{
            manager.PH2Decisions[3].pass = false;
        }
    }
    public void Next(){
        if(actualTime+1 < times.Count){
            actualTime++;
            times[actualTime].SetActive(true);
            if (actualTime == manager.whichTime){
                manager.PH2Decisions[3].pass = true;
            }else{
                manager.PH2Decisions[3].pass = false;
            }
        }
    }
    public void Prev(){
        if(actualTime-1 >= 0){
            times[actualTime].SetActive(false);
            actualTime--;
            if (actualTime == manager.whichTime){
                manager.PH2Decisions[3].pass = true;
            }else{
                manager.PH2Decisions[3].pass = false;
            }
        }
    }
}
