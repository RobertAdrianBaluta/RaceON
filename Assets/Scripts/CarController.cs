using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CarController : MonoBehaviour
{
    //------------------Adjustable variables--------------------///
    [Header("Car properties")]
    [SerializeField] public float speed = 3f;
    [SerializeField] public float rotate = 3.5f;
    [SerializeField] public float drift = 0.95f;

    //------------------Local Variables--------------------///
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float accelerateFactor = 1;
    float targetAccelerateFactor = 5;
    float slowDownTime = 1;

    //------------------------Car----------------------------//
    public Rigidbody2D CarBody;
    void Awake()
    {
        CarBody = GetComponent<Rigidbody2D>();  
    }

    //---------------------List of all the functions that changes the Car's propreties-----------------------------///
    private void FixedUpdate()
    {
        CarForce();
        Steering();
        KillOrthogonalVelocity();
    }

    //--------------------Speed up Power-----------------//

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speed")
        {       
            accelerateFactor = targetAccelerateFactor;
            StartCoroutine(SlowDownAfterAcceleration());
        }
    }

    IEnumerator SlowDownAfterAcceleration()
    {
        //Speed up with gradualy decreasing speed afterwards
        float startAcceleratorFactor = accelerateFactor;
        float timePassed = 0;
        while (accelerateFactor > 1) {
            timePassed += Time.deltaTime;
            accelerateFactor = Mathf.Lerp(startAcceleratorFactor, 1, timePassed/slowDownTime);
            yield return new WaitForEndOfFrame();
        }
        accelerateFactor = 1;
    }

    //-----------------The Car's force based on Input---------------------///
    void CarForce()
    {
        //slow down after acceleration button has been released
        if (accelerationInput == 0)
        {
            CarBody.drag = Mathf.Lerp(CarBody.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else CarBody.drag = 0;
        
        //
        Vector2 engineForceVector = transform.up * accelerationInput * speed * accelerateFactor;
        CarBody.AddForce(engineForceVector, ForceMode2D.Force );
    }

    //-------------------The steering rotation based on Input-------------------///
    void Steering()
    {
        //limit the cars ability to turn when moving slowly
        float SpeedForRotate = (CarBody.velocity.magnitude / 4);
        SpeedForRotate = Mathf.Clamp01(SpeedForRotate);
        rotationAngle -= steeringInput * rotate * SpeedForRotate;

        CarBody.MoveRotation(rotationAngle);
    }

    //-------------------Orthogonak velocity-------------------///
    void KillOrthogonalVelocity()
    {
        //a calculation that kills the orthogonal velocity in order for better drifting
        Vector2 forwardVelocity = transform.up * Vector2.Dot(CarBody.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(CarBody.velocity, transform.right);

        CarBody.velocity = forwardVelocity + rightVelocity * drift;
    }

    //-------------------Inputs-------------------///
    public void SetInputVector(Vector2 inputVector)
    {
        //Calls the input from the CarInput script
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

}
