//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    [Header("Car Settings")]
//    public float driftFactor = 0.95f;
//    public float accelerationFactor = 30.0f;
//    public float turnFactor = 3.4f;
//    public float maxSpeed = 20;

//    // Local Variables
//    float accelerationInput = 0;
//    float steeringInput = 0;

//    float rotationAngle = 0;
//    float velocityVsRight = 0; // Changed from "VsUp" to "VsRight" for horizontal movement

//    // Components
//    Rigidbody2D carRigidbody2D;

//    void Awake()
//    {
//        carRigidbody2D = GetComponent<Rigidbody2D>();
//    }

//    void FixedUpdate()
//    {
//        ApplyEngineForce();
//        KillOrthogonalVelocity();
//        ApplySteering();
//    }

//    void ApplyEngineForce()
//    {
//        // Now calculating velocity along the right vector instead of up
//        velocityVsRight = Vector2.Dot(transform.right, carRigidbody2D.velocity);

//        // Speed limits for horizontal movement
//        if (velocityVsRight > maxSpeed && accelerationInput > 0) // speed limit
//        {
//            return;
//        }

//        if (velocityVsRight < -maxSpeed && accelerationInput < 0) // reverse limit
//        {
//            return;
//        }

//        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0) // limit in any direction
//        {
//            return;
//        }

//        // Drag when there's no acceleration input
//        if (accelerationInput == 0)
//        {
//            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
//        }
//        else
//        {
//            carRigidbody2D.drag = 0; // remove drag when accelerating
//        }

//        // Now applying force along the right (horizontal) axis instead of up
//        Vector2 engineForceVector = transform.right * accelerationInput * accelerationFactor;
//        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
//    }

//    void ApplySteering()
//    {
//        // The steering is now controlled by vertical input (W/S)
//        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 1);
//        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(carRigidbody2D.velocity.magnitude / 8);

//        // Rotate around the z-axis based on W/S input (steeringInput now controls rotation)
//        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
//        carRigidbody2D.MoveRotation(rotationAngle);
//    }

//    void KillOrthogonalVelocity()
//    {
//        // Now we need to kill velocity perpendicular to right direction (horizontal movement)
//        Vector2 forwardVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);
//        Vector2 rightVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);

//        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
//    }

//    public void SetInputVector(Vector2 inputVector)
//    {
//        // Reversed controls: X is now acceleration (left-right), and Y is steering (rotation)
//        accelerationInput = inputVector.x; // Left-right movement on the x-axis
//        steeringInput = inputVector.y; // Rotation (W/S input) on the y-axis
//    }
//}
