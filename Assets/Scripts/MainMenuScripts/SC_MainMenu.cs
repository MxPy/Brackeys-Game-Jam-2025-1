using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlayMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void StartButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("DemoPH1");
    }

    public void HowToPlayButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        HowToPlayMenu.SetActive(false);
    }

    public void ExitButton()
    {
        // Quit Game
        Application.Quit();
    }
}