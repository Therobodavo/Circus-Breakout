using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Animal
{
    [HideInInspector]public bool isOnElephant = false;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        

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
            if (GameManager.instance.isElephantReach)
            {
                GameManager.instance.Win();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("WinTrigger"))
        {
            GameManager.instance.isMouseReach = false;
        }
    }

}
