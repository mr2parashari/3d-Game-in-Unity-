using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject settingPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
    public void ShowOptions()
    {
        if (optionPanel != null)
            optionPanel.SetActive(true);
    }
    public void ShowSettings()
    {
        if (settingPanel != null)
            settingPanel.SetActive(true);
    }
    public void HidePanels()
    {
        if (optionPanel != null)
            optionPanel.SetActive(false);
        if (settingPanel != null)
            settingPanel.SetActive(false);
    }
}
