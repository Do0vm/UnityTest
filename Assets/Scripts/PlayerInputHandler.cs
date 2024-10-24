//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInputHandler : MonoBehaviour
//{
//    PlayerController playerController;

//    // Start is called before the first frame update
//    void Awake()
//    {
//        playerController = GetComponent<PlayerController>();
//    }






//    // Update is called once per frame
//    void Update()
//    {
//        Vector2 inputVector = Vector2.zero;

//        inputVector.x = Input.GetAxis("Horizontal");
//        inputVector.y = Input.GetAxis("Vertical");

//        playerController.SetInputVector(inputVector);


//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        // A/D keys or Left/Right Arrow keys for left-right movement (horizontal)
        inputVector.x = Input.GetAxis("Horizontal");

        // W/S keys or Up/Down Arrow keys for rotation (vertical)
        inputVector.y = Input.GetAxis("Vertical");

        // Send input to the player controller
        playerController.SetInputVector(inputVector);
    }
}
