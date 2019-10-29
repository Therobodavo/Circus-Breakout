using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFunction : MonoBehaviour
{

    private int targetLayer;

    public void DisableCollider(int layer, Animal target)
    {
        targetLayer = layer;
        GetComponent<PlatformEffector2D>().colliderMask &= ~(1 << layer);
        //target.disableList.Add(this);
        Invoke("EnableCollider", 0.5f);
    }

    public void EnableCollider()
    {
        GetComponent<PlatformEffector2D>().colliderMask ^= 1 << targetLayer;
    }

    

}
