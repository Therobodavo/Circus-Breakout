using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlatform : MonoBehaviour
{
    public List<Transform> path = new List<Transform>();
    public float speed;
    public float duration;

    public int index;
    public bool isWaiting;

    void Start()
    {
        if (path.Count > 0)
        {
            transform.position = path[0].position;
            index = 0;
            isWaiting = false;
        }
    }

    
    void Update()
    {
        if (path.Count > 0)
        {
            if(Vector3.Distance(transform.position, path[index].position) < 0.01f && !isWaiting)
            {
                isWaiting = true;
                Invoke("IncreaseIndex", duration);
            }
            if(index < path.Count)
            {
                transform.position = Vector3.Lerp(transform.position, path[index].position, speed);
            }
        }
    }

    private void IncreaseIndex()
    {
        if (index < path.Count - 1)
        {
            index++;
        }
        else if (index == path.Count - 1)
        {
            index = 0;
        }
        isWaiting = false;
    }
}
