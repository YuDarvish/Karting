using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public GameObject target;
    protected Agent agent;

    //facing objects
    

    public float MapToRange (float rotation)
    {
        rotation %= 360f;

        if (Mathf.Abs(rotation) > 180f)
        {
            if (rotation < 0f)
                rotation += 360f;
            else
                rotation -= 360f;
        }

        return rotation;
    }

    public virtual void Awake()
    {
        agent = gameObject.GetComponent<Agent>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        agent.SetSteering(GetSteering());
    }

    public virtual Steering GetSteering()
    {
        return new Steering ();
    }
}
