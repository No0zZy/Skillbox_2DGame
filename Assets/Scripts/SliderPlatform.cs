using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SliderPlatform : MonoBehaviour
{
    [SerializeField] private float delaySwitchSpeed;
    private SliderJoint2D joint;

    private Rigidbody2D rb;

    private void Awake()
    {
        joint = GetComponent<SliderJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTER TRIGGER");

        if (other.transform.parent == transform.parent)
        {
            joint.useMotor = false;
            rb.velocity = Vector2.zero;
            StartCoroutine(DelaySwitchSpeed(delaySwitchSpeed));
        }
    }

    private IEnumerator DelaySwitchSpeed(float delay)
    {
        yield return new WaitForSeconds(delay);

        float speed = joint.motor.motorSpeed;

        JointMotor2D mtr = new JointMotor2D();
        mtr.motorSpeed = -speed;
        mtr.maxMotorTorque = 1000f;

        joint.motor = mtr;

        joint.useMotor = true;
    }
}
