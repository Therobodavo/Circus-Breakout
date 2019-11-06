using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchIgnore : MonoBehaviour, ICanvasRaycastFilter
{
    public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {

        return false;
    }
}