using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public Vector2 Force = Vector2.zero;
    private Collider2D Mouse;

    private void OnTriggerStay2D(Collider collision)
    {
        if(collision.tag.Equals("Mouse"))
        //Rigidbody2D body = object.attachedRigidbody;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
