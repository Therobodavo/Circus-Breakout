using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector2 direction = Vector2.zero;
    public bool inWindZone;
    public bool isEleinWind;
    Rigidbody2D mouseRb;
    Transform mousPos;
    Transform elePos;
    BoxCollider2D elephant;
    public GameObject windZone;



    // Start is called before the first frame update
    void Start()
    {
        //mouseRb = GameManager.instance.animals[1].GetComponent<Rigidbody2D>();
        //elephant = GameManager.instance.animals[0].GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(isTriggered)
        {
            //if(Elephant.bounds)
            
        }
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {

            if (elephant == null)
            {
                elephant = GameManager.instance.animals[0].GetComponent<BoxCollider2D>();
            }
            if (elePos == null)
            {
                elePos = GameManager.instance.animals[0].GetComponent<Transform>();
            }
            if (mouseRb == null)
            {
                mouseRb = GameManager.instance.animals[1].GetComponent<Rigidbody2D>();
            }
            if (mousPos == null)
            {
                mousPos = GameManager.instance.animals[1].GetComponent<Transform>();
            }


            if (!(elephant.bounds.ClosestPoint(mousPos.position).x < elephant.bounds.max.x && elephant.bounds.ClosestPoint(mousPos.position).x > elephant.bounds.min.x&&isEleinWind))
            {

                //if (!isUnder)
                {
                    mouseRb.AddForce(direction * strength);
                } 

                
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mouse")
        {
            windZone = collision.gameObject;
            inWindZone = true;
        }

        if (collision.gameObject.tag == "Elephant")
        {

            
             Debug.Log("1111");
             isEleinWind = true;
            

        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Mouse")
        {
            
            inWindZone = false;
        }

        if (collision.gameObject.tag == "Elephant")
        {
                Debug.Log("2222");
                isEleinWind = false;
        }
    }
}
