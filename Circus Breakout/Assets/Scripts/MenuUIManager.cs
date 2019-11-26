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

    public GameObject worldPanel;
    public List<GameObject> levelPanels = new List<GameObject>();
    public List<Button> levelBackButtons = new List<Button>();

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
        foreach(var i in levelBackButtons)
        {
            i.onClick.AddListener(BackToWorld);
        }
        BackToMenu();
    }
    
    private void OpenLevelPanel()
    {
        StarManager.instance.UpdateStars();
        worldPanel.SetActive(true);
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
        worldPanel.SetActive(false);
        settingPanel.SetActive(false);
        helpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void BackToWorld()
    {
        worldPanel.SetActive(true);
        foreach(var i in levelPanels)
        {
            i.SetActive(false);
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void OpenLevel(int index)
    {
        levelPanels[index - 1].SetActive(true);
    }
}
