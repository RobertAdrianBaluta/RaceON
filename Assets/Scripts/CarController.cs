using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CarController : MonoBehaviour
{
    [Header("Car properties")]
    [SerializeField] public float speed = 30.0f;
   // [SerializeField] public float maxspeed = 30.0f;
    [SerializeField] public float rotate = 3.5f;
    [SerializeField] public float drift = 0.95f;
    //   float velocityvsUp = 0f;


    //local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;


    public Rigidbody2D CarBody;

   
    void Awake()
    {
        CarBody = GetComponent<Rigidbody2D>();  
    }

    private void FixedUpdate()
    {
        CarForce();
        Steering();
        KillOrthogonalVelocity();
    }

    void CarForce()
    {
        if (accelerationInput == 0)
        {
            CarBody.drag = Mathf.Lerp(CarBody.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else CarBody.drag = 0;
        //create a force for the car
        Vector2 engineForceVector = transform.up * accelerationInput * speed;
        //apply force that pushes the car forward
        CarBody.AddForce(engineForceVector, ForceMode2D.Force );
    }

    void Steering()
    {
        //limit the cars ability to turn when moving slowly
        float SpeedForRotate = (CarBody.velocity.magnitude / 4);
        SpeedForRotate = Mathf.Clamp01(SpeedForRotate);
        //Update the rotation angle based on input
        rotationAngle -= steeringInput * rotate * SpeedForRotate;

        //Apply steering by totationg the car object
        CarBody.MoveRotation(rotationAngle);
    }
    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(CarBody.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(CarBody.velocity, transform.right);

        CarBody.velocity = forwardVelocity + rightVelocity * drift;

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }



}
