using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public GameObject door;
    public bool isElephantOnly = false;
    public bool isOneTime = true;
    public float upDistance;
    public float buttonDownDistance;
    public float openSpeed = 0.05f;
    public float closeSpeed = 0.05f;
    public float pressSpeed = 0.1f;
    public float upSpeed = 0.1f;

    private bool isTriggered;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Vector3 initialButtonPosition;
    private Vector3 targetButtonPosition;

    void Start()
    {
        initialPosition = door.transform.position;
        targetPosition = door.transform.position + new Vector3(0, upDistance, 0);
        initialButtonPosition = transform.position;
        targetButtonPosition = transform.position - new Vector3(0, buttonDownDistance, 0);
    }

    void Update()
    {
        if (isTriggered)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, openSpeed);
            transform.position = Vector3.Lerp(transform.position, targetButtonPosition, pressSpeed);
        }
        if (!isTriggered && !isOneTime)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, initialPosition, closeSpeed);
            transform.position = Vector3.Lerp(transform.position, initialButtonPosition, upSpeed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag.Equals("Mouse") && !isElephantOnly) || collision.tag.Equals("Elephant") || collision.tag.Equals("TriggerItem"))
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag.Equals("Mouse") && !isElephantOnly) || collision.tag.Equals("Elephant") || collision.tag.Equals("TriggerItem"))
        {
            isTriggered = false;
        }
    }

}
