using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    public GameObject fox;
    public GameObject foxMover;

    // Movement speed in metres per second
    public float movementSpeed = 0.015f;

    // Rotation speed in degrees per second
    public float rotationSpeed = 180f;

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 currentTarget;

    private bool movementActivated = false;
    private bool pausedByDistance = false;
    private bool isRotating = false;

    private Quaternion targetRotation;


    void Start()
    {
        // Save the current position of the fox as point A (0,0,-0.2)
        pointA = foxMover.transform.localPosition;

        // Point B is on the opposite side of the plane.
        // Keep X and Y, only change Z from -0.2 to +0.2.
        pointB = new Vector3(
            pointA.x,
            pointA.y,
            0.2f
        );

        // The fox starts at A, so its first destination is B
        currentTarget = pointB;
    }


    void Update()
    {
        CheckTouch();

        // Movement has not been activated by touch
        if (!movementActivated)
            return;

        // Movement is temporarily paused because
        // the camera is more than 1 metre away
        if (pausedByDistance)
            return;

        // Either rotate or move
        if (isRotating)
        {
            RotateFox();
        }
        else
        {
            MoveFox();
        }
    }


    void CheckTouch()
    {
        // No touch on the screen
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        // Only react once when the finger touches the screen = beginning
        if (touch.phase != TouchPhase.Began)
            return;

        // Create a ray from the camera through the touched position
        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the fox or one of its children was touched
            if (hit.transform == fox.transform ||
                hit.transform.IsChildOf(fox.transform))
            {
                // Start or stop the movement
                movementActivated = !movementActivated;
            }
        }
    }


    void MoveFox()
    {
        // Move the fox towards the current target
        foxMover.transform.localPosition = Vector3.MoveTowards(
            foxMover.transform.localPosition,
            currentTarget,
            movementSpeed * Time.deltaTime
        );

        // Check if the fox has reached its destination
        if (Vector3.Distance(
            foxMover.transform.localPosition,
            currentTarget) < 0.001f)
        {
            // Define a rotation of 180 degrees
            targetRotation =
                foxMover.transform.localRotation *
                Quaternion.Euler(0f, 180f, 0f);

            isRotating = true;
        }
    }


    void RotateFox()
    {
        // Slowly rotate the fox towards the target rotation
        foxMover.transform.localRotation = Quaternion.RotateTowards(
            foxMover.transform.localRotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        // Check if the 180 degree rotation is finished
        if (Quaternion.Angle(
            foxMover.transform.localRotation,
            targetRotation) < 0.1f)
        {
            foxMover.transform.localRotation = targetRotation;

            // Change the destination
            if (currentTarget == pointB)
            {
                currentTarget = pointA;
            }
            else
            {
                currentTarget = pointB;
            }

            isRotating = false;
        }
    }


    // Called by FoxDistance
    public void SetDistancePause(bool pause)
    {
        pausedByDistance = pause;
    }
}