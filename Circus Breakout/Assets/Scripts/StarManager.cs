using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;

    public List<Image> starsObjects1 = new List<Image>();
    public List<Image> starsObjects2 = new List<Image>();
    public List<Image> starsObjects3 = new List<Image>();
    public Sprite starOutline;
    public Sprite starFilled;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        UpdateStars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStars()
    {
        foreach (var i in starsObjects1)
        {
            if (i != null)
            {
                i.sprite = starOutline;
            }
        }
        foreach (var i in starsObjects2)
        {
            if (i != null)
            {
                i.sprite = starOutline;
            }
        }
        foreach (var i in starsObjects3)
        {
            if (i != null)
            {
                i.sprite = starOutline;
            }
        }
        for (int i = 0; i < DataManager.instance.stars.Count; i++)
        {
            if (DataManager.instance.stars[i])
            {
                if (starsObjects1[i] != null)
                {
                    starsObjects1[i].sprite = starFilled;
                }
                if (starsObjects2[i] != null)
                {
                    starsObjects2[i].sprite = starFilled;
                }
                if (starsObjects3[i] != null)
                {
                    starsObjects3[i].sprite = starFilled;
                }
            }
        }
    }
}
