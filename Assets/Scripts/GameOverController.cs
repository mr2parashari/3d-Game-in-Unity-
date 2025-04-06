using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject settingPanel;
    public void ResumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited");
    }
    public void ShowSettings()
    {
        if (settingPanel != null)
            settingPanel.SetActive(true);
    }
    public void HideSettings()
    {
        if (settingPanel != null)
            settingPanel.SetActive(false);
    }
}
