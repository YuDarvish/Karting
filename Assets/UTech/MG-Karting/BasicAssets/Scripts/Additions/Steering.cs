using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering
{
    public float angular;
    public Vector3 linear;
    
    public Steering()
    {
        angular = 0f;
        this.linear = new Vector3();
    }
}
