using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }

    // Serialize Field makes it editable in unity
    [SerializeField]
    protected float currentVelocity = 3;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void MoveAgentMethod(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            // Vector2 Dot lets us know if both vectors are in the same direction, or if they're in opposite directions from -1 to 1
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
            { 
                // Set Velocity to 0 when switching directions, to prevent instant movement in the opposite direction
                currentVelocity = 0; 
            }
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
       if(movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        } 
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        rigidbody2d.velocity = currentVelocity * movementDirection.normalized;
    }
}
