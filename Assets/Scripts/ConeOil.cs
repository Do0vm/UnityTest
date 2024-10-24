using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOil : MonoBehaviour
{
    // Start is called before the first frame update
    public UIFillNOS UIFillNOS;
    void Start()
    {
        // Find the UIManager in the scene
        UIFillNOS = FindObjectOfType<UIFillNOS>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIFillNOS.Deduct(10);
        }


    }
}
