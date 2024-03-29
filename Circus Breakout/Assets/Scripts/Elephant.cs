﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : Animal
{

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("WinTrigger"))
        {
            GameManager.instance.isElephantReach = true;
            GameManager.instance.elephantBackground.color = new Color(GameManager.instance.elephantBackground.color.r, GameManager.instance.elephantBackground.color.g, GameManager.instance.elephantBackground.color.b, 1.0f);
            if (GameManager.instance.isMouseReach)
            {
                GameManager.instance.Win();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("WinTrigger"))
        {
            GameManager.instance.isElephantReach = false;
            GameManager.instance.elephantBackground.color = new Color(GameManager.instance.elephantBackground.color.r, GameManager.instance.elephantBackground.color.g, GameManager.instance.elephantBackground.color.b, 0);
        }
    }
}
