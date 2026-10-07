using UnityEngine;
using System.Collections;

public class FoxDistance : MonoBehaviour
{
    public GameObject fox;
    public FoxMovement foxMovement;

    public float visibilityDistance = 1.0f;
    public float jumpDistance = 0.3f;
    public float jumpHeight = 0.1f;
    public float jumpDuration = 0.6f;

    private Transform cameraTransform;
    private bool hasJumped = false;
    private bool isJumping = false;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(
            cameraTransform.position,
            fox.transform.position
        );

        
        // Hide fox mit SetActive(false) and pause movement outside 1 metre
        if (distance > visibilityDistance)
        {
            foxMovement.SetDistancePause(true); //sets pausedByDistance to true, but movementActivated stays also true
            fox.SetActive(false); //hides fox
        }
        else
        {
            fox.SetActive(true);
            foxMovement.SetDistancePause(false);
        }

        // Jump when entering the 30 cm radius and we are not jumping already
        if (distance <= jumpDistance && !hasJumped && !isJumping)
        {
            StartCoroutine(Jump());
            hasJumped = true;
        }

        // make jump possible again after leaving the 30 cm radius
        if (distance > jumpDistance)
        {
            hasJumped = false;
        }
    }

    IEnumerator Jump()
    {
        // We are jumping now, no other jump can start from now on
        isJumping = true;

        //Vector3 startPosition = fox.transform.position;
        //Vector3 topPosition = startPosition + Vector3.up * jumpHeight;

        float halfDuration = jumpDuration / 2f;
        float elapsed = 0f;
        float previousOffset = 0f;

        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;

            float currentOffset = Mathf.Lerp(
               0f,
               jumpHeight,
               elapsed / halfDuration
           );

            float movementThisFrame =
                currentOffset - previousOffset;

            // Move along global Y
            fox.transform.position +=
                Vector3.up * movementThisFrame;

            previousOffset = currentOffset; // new end

            yield return null;
        }

        elapsed = 0f; // we have made it to the half point because we got out of first while, so now lets do the 2nd half but start at 0 again

        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;

            float currentOffset = Mathf.Lerp(
               jumpHeight,
               0f,
               elapsed / halfDuration
           );

            float movementThisFrame =
                currentOffset - previousOffset;

            // Move along Y
            fox.transform.position +=
                Vector3.up * movementThisFrame;

            previousOffset = currentOffset;


            yield return null;
        }
        isJumping = false;
    }
}