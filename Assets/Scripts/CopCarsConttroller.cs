using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("AI Settings")]
    public float accelerationFactor = 20.0f;  // Acceleration speed
    public float maxSpeed = 15.0f;            // Max speed for the AI
    public float laneSwitchDelay = 2.0f;      // Delay between lane switches
    public float laneSwitchChance = 0.3f;     // Chance AI will switch lanes during delay

    public float[] lanePositions;             // Predefined y-positions for lanes
    private int currentLane;                  // Current lane AI is in
    private float targetLaneYPosition;        // Target y-position for lane switching

    private bool isSwitchingLanes = false;    // Whether AI is currently switching lanes
    private Rigidbody2D carRigidbody2D;       // Rigidbody2D for movement

    // Start is called before the first frame update
    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
        currentLane = Random.Range(0, lanePositions.Length);  // Start AI in a random lane
        targetLaneYPosition = lanePositions[currentLane];     // Set the initial lane
        StartCoroutine(LaneSwitchRoutine());                  // Begin AI lane switching
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplyLaneSwitch();
    }

    void ApplyEngineForce()
    {
        // Ensure the AI moves forward constantly but with acceleration control
        if (carRigidbody2D.velocity.x < maxSpeed)
        {
            Vector2 engineForceVector = new Vector2(accelerationFactor, 0);
            carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
        }
    }

    void ApplyLaneSwitch()
    {
        // If the AI is switching lanes, smoothly move it to the target lane's y-position
        if (isSwitchingLanes)
        {
            float newYPosition = Mathf.Lerp(transform.position.y, targetLaneYPosition, Time.fixedDeltaTime * 5);
            carRigidbody2D.MovePosition(new Vector2(transform.position.x, newYPosition));

            // Stop lane switching once the AI reaches the target lane
            if (Mathf.Abs(transform.position.y - targetLaneYPosition) < 0.1f)
            {
                transform.position = new Vector2(transform.position.x, targetLaneYPosition); // Snap to lane
                isSwitchingLanes = false;
            }
        }
    }

    IEnumerator LaneSwitchRoutine()
    {
        while (true)
        {
            // Wait for the laneSwitchDelay before potentially switching lanes
            yield return new WaitForSeconds(laneSwitchDelay);

            // Randomly decide whether to switch lanes based on the laneSwitchChance
            if (Random.value < laneSwitchChance)
            {
                // Randomly choose a new lane (different from the current one)
                int newLane = Random.Range(0, lanePositions.Length);
                while (newLane == currentLane) // Ensure AI switches to a different lane
                {
                    newLane = Random.Range(0, lanePositions.Length);
                }

                // Update lane and start switching
                currentLane = newLane;
                targetLaneYPosition = lanePositions[currentLane];
                isSwitchingLanes = true;
            }
        }
    }
}
