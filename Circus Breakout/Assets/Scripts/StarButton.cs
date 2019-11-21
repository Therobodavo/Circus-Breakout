using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarButton : MonoBehaviour
{
    public int index;
    public bool isElephantOnly = false;

    public float buttonDownDistance;

    public float pressSpeed = 0.1f;
    public float upSpeed = 0.1f;

    private bool isTriggered;
    private Vector3 initialButtonPosition;
    private Vector3 targetButtonPosition;

    void Update()
    {
        
        if (isTriggered)
        {
            transform.position = Vector3.Lerp(transform.position, targetButtonPosition, pressSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered)
        {
            return;
        }
        if ((collision.tag.Equals("Mouse") && !isElephantOnly) || collision.tag.Equals("Elephant") || collision.tag.Equals("TriggerItem"))
        {
            isTriggered = true;
            if (DataManager.instance != null)
            {
                DataManager.instance.stars[index] = true;
                DataManager.instance.UpdateStars();
            }
        }
    }
}
