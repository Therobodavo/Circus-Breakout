using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;

    public GameObject animalSprite;

    public Animator animalAnimator;

    [HideInInspector]public bool isUnderControl;

    protected bool isGround;
    protected bool isMovingRight;

    protected virtual void Start()
    {
        isGround = true;
        isMovingRight = true;
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
        if(animalAnimator != null && this.tag.Equals("Mouse"))
        {
            animalAnimator.SetBool("isInAir", !isGround);
        }
        if (isUnderControl)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGround == true)
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
        //transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime, 0, 0);
       
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (isMovingRight && animalSprite != null)
            {
                isMovingRight = false;
                animalSprite.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            if (!isMovingRight && animalSprite != null)
            {
                isMovingRight = true;
                animalSprite.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if(animalAnimator != null)
        {
            if(Input.GetAxis("Horizontal") != 0)
            {
                animalAnimator.SetBool("isMoving", true);
            }
            else
            {
                animalAnimator.SetBool("isMoving", false);
            }
        }
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

