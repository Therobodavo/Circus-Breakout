using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;

    [HideInInspector]public bool isUnderControl;

    protected bool isGround;

    protected virtual void Start()
    {
        isGround = true;
    }

    protected virtual void Update()
    {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        GetComponent<Rigidbody2D>().GetContacts(contacts);
        isGround = false;
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].relativeVelocity.y <= 0.01f)
            {
                if(contacts.Count > 1)
                {
                    int count = 0;
                    for (int j = 0; j < contacts.Count; j++)
                    {
                        if (contacts[j].point.y < transform.position.y)
                        {
                            count++;
                        }
                    }
                    if (count >= 2)
                    {
                        isGround = true;
                    }
                }
                else
                {
                    isGround = true;
                }
                break;
            }
        }
        if (isUnderControl)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
            {
                Jump();
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        if (isUnderControl)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime, 0, 0);
    }

    private void Jump()
    {
        if(GetComponent<Rigidbody2D>().velocity.y > 0.5f)
        {
            return;
        }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }

}

