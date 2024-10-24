using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFillNOS : MonoBehaviour
{
    public int maxValue;
    public Image fill;

    private int currentValue;


    public float deductInterval = 0.5f; // Time in seconds between deductions
    private float timeSinceLastDeduct = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = maxValue;
        fill.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Prioritize Shift + D check first
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            // Check if enough time has passed since the last deduction
            if (timeSinceLastDeduct >= deductInterval)
            {
                Deduct(5); // Call the Deduct function for boost
                timeSinceLastDeduct = 0f; // Reset the timer after deducting
            }
        }
        // Regular D key check
        else if (Input.GetKey(KeyCode.D))
        {
            // Check if enough time has passed since the last deduction
            if (timeSinceLastDeduct >= deductInterval)
            {
                Deduct(1); // Call the Deduct function
                timeSinceLastDeduct = 0f; // Reset the timer after deducting
            }
        }

        // Increment the timer by the time passed since the last frame
        timeSinceLastDeduct += Time.deltaTime;


        if (currentValue <= 0)
        {
            SceneManager.LoadScene("YouDied"); // Load the "You Died" scene
        }

    }


    public void Add(int i )
    {
        currentValue += i;
        if(currentValue > maxValue )
        {
            currentValue = maxValue;
        }

        fill.fillAmount = (float)currentValue/maxValue;
    }

    public void Deduct(int i)
    {
        currentValue -= i;
        if (currentValue <0)
        {
            currentValue = 0;
        }

        fill.fillAmount = (float)currentValue / maxValue;

    }

    
}
