using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;

    [HideInInspector]public bool isUnderControl;
    [HideInInspector]public List<FallFunction> disableList = new List<FallFunction>();

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
            if(Input.GetKeyDown(KeyCode.S) && isGround == true && contacts[0].collider.gameObject.GetComponent<FallFunction>())
            {
                if (this.GetType().Name.Equals("Elephant"))
                {
                    contacts[0].collider.gameObject.GetComponent<FallFunction>().DisableCollider(8, this);
                }
                else
                {
                    contacts[0].collider.gameObject.GetComponent<FallFunction>().DisableCollider(9, this);
                }
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
        //EnablePlatformList();
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        //EnablePlatformList();
    }

    private void EnablePlatformList()
    {
        foreach(var t in disableList)
        {
            t.EnableCollider();
        }
        disableList.Clear();
    }
}

