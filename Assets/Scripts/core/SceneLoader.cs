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
        SceneManager.sceneLoaded += OnPHSceneLoaded;
        SceneManager.LoadScene("DemoPH1");
        
   }
     public static void LoadPH2()
     {
          SceneManager.sceneLoaded += OnPHSceneLoaded;
          SceneManager.LoadScene("DemoPH2");
     }
     public static void LoadPH3()
     {
          //SceneManager.sceneLoaded += OnPHSceneLoaded;
          SceneManager.LoadScene("Outro");
     }

     private static void OnPHSceneLoaded(Scene scene, LoadSceneMode mode)
     {
          ProgressManager manager = GameObject.FindObjectOfType<ProgressManager>();
          if (manager != null)
               {
               if (scene.name == "DemoPH2")
                    {
                         manager.StartSecondPhase();  
                    }
               if (scene.name == "DemoPH1")
                    {
                         manager.StartFirstPhase();
                    }
               }
          SceneManager.sceneLoaded -= OnPHSceneLoaded;
     }
}
