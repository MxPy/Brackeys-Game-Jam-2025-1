using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    //We will keep track of all scenes here
   public static void LoadMenu(){
        SceneManager.LoadScene("Menu");
   }
   public static void LoadPH1(){
        SceneManager.LoadScene("DemoPH1");
   }
   public static void LoadPH2(){
        SceneManager.LoadScene("DemoPH2");
   }
}
