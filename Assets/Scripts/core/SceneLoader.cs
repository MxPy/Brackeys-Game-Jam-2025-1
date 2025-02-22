using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    //We will keep track of all scenes here
   public static void LoadMenu(){
        SceneManager.LoadScene("Menu");
        ProgressManager manager = GameObject.FindObjectOfType<ProgressManager>();
        Destroy(manager.gameObject);
   }
   public static void LoadPH1(){
        SceneManager.LoadScene("DemoPH1");
   }
     public static void LoadPH2()
     {
          SceneManager.sceneLoaded += OnPH2SceneLoaded;
          SceneManager.LoadScene("DemoPH2");
     }

     private static void OnPH2SceneLoaded(Scene scene, LoadSceneMode mode)
     {
          if (scene.name == "DemoPH2")
          {
               ProgressManager manager = GameObject.FindObjectOfType<ProgressManager>();
               if (manager != null)
               {
                    manager.StartSecondPhase();
               }
               // Odłączamy zdarzenie, żeby nie wywoływało się przy kolejnych zmianach sceny
               SceneManager.sceneLoaded -= OnPH2SceneLoaded;
          }
     }
}
