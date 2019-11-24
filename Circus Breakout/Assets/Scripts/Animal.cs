using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;

    public GameObject animalSprite;

    public GameObject emptyPointPrefab;

    public GameObject windZone;

    public Animator animalAnimator;

    [HideInInspector] public bool isUnderControl;
    [HideInInspector] public bool isOnRope = false;
    [HideInInspector] public bool inWindZone = false;

    //Collider2D elephant;
    //Rigidbody2D rb;
    protected GameObject ropePoint;
    protected GameObject rope;

    protected bool isGround;
    protected bool isMovingRight;

    protected virtual void Start()
    {
        isGround = true;
        isMovingRight = true;
        //rb = GetComponent<Rigidbody2D>();
        //elephant = GameManager.instance.animals[0].GetComponent<Collider2D>();
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
        if (isOnRope)
        {

            transform.position = ropePoint.transform.position;
        }
        if (animalAnimator != null && this.tag.Equals("Mouse"))
        {
            animalAnimator.SetBool("isInAir", !isGround);
        }
        if (isUnderControl)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (isGround == true || isOnRope))
            {
                Jump();
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        if (isUnderControl && !isOnRope)
        {
            Move();
        }
        if(isUnderControl && isOnRope)
        {
            WaveRope();
        }



    }

    private void WaveRope()
    {
        rope.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal") * 0.2f, 0));
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
        if (isOnRope)
        {
            isOnRope = false;
            Invoke("RecoverRope", 0.3f);
            Destroy(ropePoint);
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        
    }

    private void RecoverRope()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), rope.GetComponent<Collider2D>(), false);
        rope = null;
    }

}

