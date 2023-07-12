using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    private void Start()
    {
        settingsMenu.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ChoosePlayer");
    }
    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void HideSettings()
    {
        settingsMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
