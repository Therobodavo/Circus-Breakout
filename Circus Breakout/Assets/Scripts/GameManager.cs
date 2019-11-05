using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Animal> animals = new List<Animal>();

    public Animation elephantIconAnimation;
    public Canvas elephantIconCanvas;
    public Animation mouseIconAnimation;
    public Canvas mouseIconCanvas;
    public Button pauseButton;


    public GameObject pausePanel;
    public Button resumeButton;
    public Button menuButton;
    public Button restartButton;
    public Button exitButton;

    public GameObject winPanel;
    public Button winMenuButton;
    public Button winRestartButton;
    public Button winExitButton;


    [HideInInspector] public int stars = 0;
    [HideInInspector] public bool isElephantReach;
    [HideInInspector] public bool isMouseReach;

    private int currentAnimal = 1;//0 = Elephant, 1 = Mouse
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        animals[0].isUnderControl = false;
        animals[1].isUnderControl = true;

        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(BackToMenu);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
        winMenuButton.onClick.AddListener(BackToMenu);
        winRestartButton.onClick.AddListener(RestartGame);
        winExitButton.onClick.AddListener(ExitGame);
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        ChangeIconsSortingOrder();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            SwitchAnimal();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void SwitchAnimal()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if(currentAnimal == 0)
        {
            currentAnimal = 1;
            animals[1].isUnderControl = true;
            if (animals[0].animalAnimator != null)
            {
                animals[0].animalAnimator.SetBool("isMoving", false);
            }
            animals[0].isUnderControl = false;
        }
        else
        {
            currentAnimal = 0;
            animals[0].isUnderControl = true;
            if(animals[1].animalAnimator != null)
            {
                animals[1].animalAnimator.SetBool("isMoving", false);
            }
            animals[1].isUnderControl = false;
        }
        elephantIconAnimation.Play();
        mouseIconAnimation.Play();
        Invoke("ChangeIconsSortingOrder", 0.5f);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void ChangeIconsSortingOrder()
    {
        if (currentAnimal == 0)
        {
            elephantIconCanvas.sortingOrder = 2;
            mouseIconCanvas.sortingOrder = 1;
        }
        else
        {
            elephantIconCanvas.sortingOrder = 1;
            mouseIconCanvas.sortingOrder = 2;
        }
    }

    public void Win()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        pauseButton.gameObject.SetActive(true);
    }
}
