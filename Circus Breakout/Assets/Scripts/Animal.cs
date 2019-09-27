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
            if (contacts[i].relativeVelocity.y == 0)
            {
                isGround = true;
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
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }

}

