using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with has the tag "Obstacle"
        if (collision.gameObject.tag == "Obstacle")
        {
            // Try to get the Health component from the object collided with
            var healthComponent = collision.gameObject.GetComponent<Health>();
            if (healthComponent != null)
            {
                // Deduct 10 health points from the object
                healthComponent.TakeDamage(10);
            }
        }
    }
}
