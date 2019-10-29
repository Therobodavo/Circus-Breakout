using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTargetCollision : MonoBehaviour
{
    public Collider2D targetCollider;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), targetCollider);
    }

}
