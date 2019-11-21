using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCloseDoor : MonoBehaviour
{
    [HideInInspector]
    public int contacts;

    private void Start()
    {
        contacts = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Elephant")|| collision.gameObject.tag.Equals("Mouse") || collision.gameObject.tag.Equals("TriggerItem"))
        {
            //Debug.Log("1:"+(transform.position.y - collision.gameObject.transform.position.y).ToString());
            //Debug.Log(transform.localScale.y * GetComponent<BoxCollider2D>().size.y + collision.gameObject.transform.localScale.y * collision.gameObject.GetComponent<BoxCollider2D>().size.y);
            if ((transform.position.y - collision.gameObject.transform.position.y) - 0.5f * (transform.localScale.y * GetComponent<BoxCollider2D>().size.y + collision.gameObject.transform.localScale.y * collision.gameObject.GetComponent<BoxCollider2D>().size.y) > -1.0f) 
            {
                
                contacts++;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Elephant") || collision.gameObject.tag.Equals("Mouse") || collision.gameObject.tag.Equals("TriggerItem"))
        {
            if ((transform.position.y - collision.gameObject.transform.position.y) - 0.5f * (transform.localScale.y * GetComponent<BoxCollider2D>().size.y + collision.gameObject.transform.localScale.y * collision.gameObject.GetComponent<BoxCollider2D>().size.y) > -1.0f)
            {

                contacts--;
            }
        }
    }
}
