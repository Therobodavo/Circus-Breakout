using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Animal
{
    [HideInInspector] public bool isOnElephant = false;
    Collider2D elephant;
    Rigidbody2D rb;


    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        elephant = GameManager.instance.animals[0].GetComponent<Collider2D>();
    }
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (inWindZone)
        {

            if (elephant.bounds.ClosestPoint())
            {
                rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
            }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Elephant"))
        {
            isOnElephant = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Elephant"))
        {
            isOnElephant = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("WinTrigger"))
        {
            GameManager.instance.isMouseReach = true;
            GameManager.instance.mouseBackground.color = new Color(GameManager.instance.mouseBackground.color.r, GameManager.instance.mouseBackground.color.g, GameManager.instance.mouseBackground.color.b, 1.0f);
            if (GameManager.instance.isElephantReach)
            {
                GameManager.instance.Win();
            }
        }
        if (collision.tag.Equals("Rope"))
        {
            Vector2 point = collision.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
            GameObject go = Instantiate(emptyPointPrefab, point, transform.rotation);
            go.transform.SetParent(collision.transform);
            ropePoint = go;
            rope = collision.gameObject;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.GetComponent<Collider2D>());
            isOnRope = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WindArea")
        {
            Debug.Log("1111");
            windZone = collision.gameObject;
            inWindZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("WinTrigger"))
        {
            GameManager.instance.isMouseReach = false;
            GameManager.instance.mouseBackground.color = new Color(GameManager.instance.mouseBackground.color.r, GameManager.instance.mouseBackground.color.g, GameManager.instance.mouseBackground.color.b, 0);
        }

        if (collision.gameObject.tag == "WindArea")
        {
            Debug.Log("1111");
            inWindZone = false;
        }
    }

}
