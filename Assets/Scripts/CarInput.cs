using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInput : MonoBehaviour
{
    
    //----------------------------Calls the CarController's script---------------------------//
    CarController carController;

    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    //---------------------Inputs for the cars movement-----------------------//
    public void OnDrive(InputAction.CallbackContext context)
    {
        Vector2 inputFromKey = context.ReadValue<Vector2>();
        carController.SetInputVector(inputFromKey);
    }

}
