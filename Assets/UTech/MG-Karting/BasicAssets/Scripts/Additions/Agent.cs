using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxAccel;
    public float maxRotation;
    public float maxAngularAccel;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        steering = new Steering();
    }

    public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        velocity.y = 0f;
        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;

        if (orientation < 0f)
            orientation += 360f;
        else if (orientation > 360f)
            orientation -= 360f;

        transform.Translate(displacement, Space.World);
        transform.rotation = Quaternion.LookRotation(displacement);
    }

    public virtual void LateUpdate()
    {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }

        if (Mathf.Approximately(steering.angular, 0f))
        {
            rotation = 0f;
        }

        if (Mathf.Approximately(steering.linear.sqrMagnitude, 0f))
        {
            velocity = Vector3.zero;
        }

        steering = new Steering();
    }

    
}
