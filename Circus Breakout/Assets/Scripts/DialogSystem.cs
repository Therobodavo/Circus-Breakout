using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;

    public bool isPlayWhenStart = true;
    public float playInterval;
    public int waves;
    public List<int> dialogsCountInWaves = new List<int>();
    public List<GameObject> dialogs = new List<GameObject>();

    private int currentWave;
    private int currentDialogInWave;
    private int currentDialog;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        currentWave = -1;
        currentDialogInWave = 0;
        currentDialog = 0;
        foreach(var i in dialogs)
        {
            i.SetActive(false);
        }
        if (isPlayWhenStart)
        {
            PlayNextWave();
        }
    }

    
    void Update()
    {
        
    }

    public void PlayNextWave()
    {
        if(currentWave == waves)
        {
            return;
        }
        currentWave++;
        currentDialogInWave = 0;
        PlayDialog();
    }

    void PlayDialog()
    {
        if(currentWave == waves && currentDialog - 1 >= 0)
        {
            dialogs[currentDialog - 1].SetActive(false);
        }
        else if(currentDialogInWave < dialogsCountInWaves[currentWave])
        {
            dialogs[currentDialog].SetActive(true);
            if(currentDialog >= 1)
            {
                dialogs[currentDialog - 1].SetActive(false);
            }
            currentDialog++;
            currentDialogInWave++;
            Invoke("PlayDialog", playInterval);
        }
        else if(currentDialogInWave == dialogsCountInWaves[currentWave])
        {
            dialogs[currentDialog - 1].SetActive(false);
        }
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }
}
