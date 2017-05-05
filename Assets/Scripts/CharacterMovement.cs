using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector2 Acceleration;
    public float TopSpeed;
    public float DragAmplifier;
    public float JumpAmplifier;
    public float GravityAmplifier;
    public bool IsGrounded;

    private void Awake()
    {
        Events.PlayerGrounded.AddListener(Grounded);
        Events.ResetPlayerMovement.AddListener(ResetMovement);
    }

    void Grounded()
    {
        IsGrounded = !IsGrounded;
    }

    Vector2 CalculateDragForce()
    {
        return -Acceleration * DragAmplifier;
    }

    Vector2 MovementForce()
    {
        float hAxis = Input.GetAxis("Horizontal");

        return new Vector2(hAxis, 0);
    }

    Vector2 JumpForce()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            return new Vector2(0, 1) * JumpAmplifier;
        }
        return Vector2.zero;
    }

    Vector2 Gravityforce()
    {
        return new Vector2(0, -9.81f) * GravityAmplifier;
    }

    private void ResetMovement(Vector3 newPosition)
    {
        IsGrounded = false;
        Acceleration = Vector2.zero;
        transform.position = newPosition;
    }

    private void Update()
    {
        Acceleration += CalculateDragForce() + MovementForce() + JumpForce() + Gravityforce() * (Time.deltaTime * TopSpeed);
        if(Acceleration.magnitude > TopSpeed)
        {
            Acceleration = Acceleration.normalized * TopSpeed;
        }
        GetComponent<Rigidbody2D>().velocity = Acceleration;   
    }
}
