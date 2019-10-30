using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTargetCollision : MonoBehaviour
{
    public Collider2D target;
    
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), target);
    }

    
}
