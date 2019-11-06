using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager instance;

    public GameObject mainPanel;
    public Button playButton;
    public Button settingButton;
    public Button helpButton;
    public Button exitButton;

    public GameObject levelPanel;

    public GameObject settingPanel;

    public GameObject helpPanel;

    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        playButton.onClick.AddListener(OpenLevelPanel);
        settingButton.onClick.AddListener(OpenSettingPanel);
        helpButton.onClick.AddListener(OpenHelpPanel);
        exitButton.onClick.AddListener(ExitGame);
        BackToMenu();
    }
    
    private void OpenLevelPanel()
    {
        levelPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    private void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    private void OpenHelpPanel()
    {
        helpPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void BackToMenu()
    {
        levelPanel.SetActive(false);
        settingPanel.SetActive(false);
        helpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
