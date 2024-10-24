//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Timeline;

//public class PlayerController : MonoBehaviour
//{

//    [Header("Car Settings")]
//    public float driftFactor = 0.95f;
//    public float accelerationFactor = 30.0f;
//    public float turnFactor = 3.4f;
//    public float maxSpeed = 20;

//    //Local Variables
//    float accelerationInput = 0;
//    float steeringInput = 0;

//    float rotationAngle = 0;
//    float velocityVsUp = 0;

//    // Components
//    Rigidbody2D carRigidbody2D;

//    // Start is called before the first frame update
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
//        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity); // calc how much foward

//        if (velocityVsUp > maxSpeed && accelerationInput > 0) //speed limit
//        {
//            return;
//        }

//        if (velocityVsUp < maxSpeed * 0.5f && accelerationInput < 0) //reverse limit
//        {
//            return;
//        }
//        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0) //limit in any direction
//        {
//            return;
//        }

//        //Drag
//        if (accelerationInput == 0)
//        {
//            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
//        }
//        else carRigidbody2D.drag = 0; //remove drag when stop accel

//        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

//        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);


//    }


//    void ApplySteering()
//    {
//        float minSpeedBeforeALlowTurningFactor = (carRigidbody2D.velocity.magnitude / 1); //change 8 if neccessary
//        minSpeedBeforeALlowTurningFactor = Mathf.Clamp01(carRigidbody2D.velocity.magnitude / 8);


//        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeALlowTurningFactor; // car rotation standing still


//        carRigidbody2D.MoveRotation(rotationAngle);
//    }

//    void KillOrthogonalVelocity()
//    {

//        Vector2 fowardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
//        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

//        carRigidbody2D.velocity = fowardVelocity + rightVelocity * driftFactor;


//    }

//    public void SetInputVector(Vector2 inputVector)
//    {
//        steeringInput = inputVector.x;
//        accelerationInput = inputVector.y;
//    }



//}


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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Car Settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float maxSpeed = 20;
    public float boostMultiplier = 2.0f;  // Multiplier for speed when boosting

    // Local Variables
    float horizontalInput = 0; // For A/D movement on X-axis
    float verticalInput = 0;   // For W/S movement on Y-axis
    bool isBoosting = false;   // Track if the Shift key is being held down

    // Components
    Rigidbody2D carRigidbody2D;

    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CheckBoost();
        ApplyMovement();
        KillOrthogonalVelocity();
    }

    // Check if the Shift key is being pressed to enable speed boost
    void CheckBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }
    }

    // Apply movement force on both X-axis (left/right) and Y-axis (up/down)
    void ApplyMovement()
    {
        // Determine the actual speed limit and acceleration based on whether boosting or not
        float currentMaxSpeed = isBoosting ? maxSpeed * boostMultiplier : maxSpeed;
        float currentAccelerationFactor = isBoosting ? accelerationFactor * boostMultiplier : accelerationFactor;

        // X-axis movement (A/D keys)
        float velocityVsRight = Vector2.Dot(transform.right, carRigidbody2D.velocity);

        if (Mathf.Abs(velocityVsRight) < currentMaxSpeed)
        {
            Vector2 forceX = transform.right * horizontalInput * currentAccelerationFactor;
            carRigidbody2D.AddForce(forceX, ForceMode2D.Force);
        }

        // Y-axis movement (W/S keys)
        float velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        if (Mathf.Abs(velocityVsUp) < currentMaxSpeed)
        {
            Vector2 forceY = transform.up * verticalInput * currentAccelerationFactor;
            carRigidbody2D.AddForce(forceY, ForceMode2D.Force);
        }

        // Apply drag if no input on both axes
        if (horizontalInput == 0 && verticalInput == 0)
        {
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRigidbody2D.drag = 0; // No drag when moving
        }
    }


    // Reduce drift to make the car stick to the lanes
    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        // X-axis movement controlled by A/D (left/right), Y-axis by W/S (up/down)
        horizontalInput = inputVector.x; // A/D controls X-axis movement
        verticalInput = inputVector.y;   // W/S controls Y-axis movement
    }
}



