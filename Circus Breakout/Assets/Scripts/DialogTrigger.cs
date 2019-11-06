using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public int waveIndex;
    public bool isElephantOnly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag.Equals("Mouse") && !isElephantOnly) || collision.tag.Equals("Elephant"))
        {
            if(waveIndex - 1 >= DialogSystem.instance.GetCurrentWave())
            {
                DialogSystem.instance.PlayNextWave();
            }
        }
    }
}
