using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitrous : MonoBehaviour
{
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
            UIFillNOS.Add(80);
        }
    }

}
