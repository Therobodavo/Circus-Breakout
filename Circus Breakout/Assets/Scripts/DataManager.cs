using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public List<bool> stars = new List<bool>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(transform.gameObject);
    }

    void Start()
    {
    }

    
    void Update()
    {
        
    }

    public void ResetData()
    {
        for(int i = 0; i < stars.Count; i++)
        {
            stars[i] = false;
        }
    }
}
