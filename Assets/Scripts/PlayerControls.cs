using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //[SerializeField] GameObject playerRig;
    //[SerializeField] Vector3 distanceFromBoatToPlayerRig;

    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 20f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        //distanceFromBoatToPlayerRig = transform.position - playerRig.transform.position;
        //playerRig.transform.position = transform.position + distanceFromBoatToPlayerRig;

        //ProcessBoatTranslation();
        //ProcessBoatRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = /*transform.localPosition.x */ xThrow * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = 0f;
        yThrow = 0f;

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        //float clampedXPos = 0;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        //float clampedYPos = Mathf.Clamp(rawYPos, -yRange / 2, yRange);
        float clampedYPos = 0;

        float zOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawZPos = transform.localPosition.z + zOffset;
        //float clampedZPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        //transform.localPosition = new Vector3(rawXPos, clampedYPos, rawZPos);
    }

    void ProcessBoatRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = /*transform.localPosition.x */ xThrow * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessBoatTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.position.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        //float clampedXPos = 0;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.position.y + yOffset;
        //float clampedYPos = Mathf.Clamp(rawYPos, -yRange / 2, yRange);
        float clampedYPos = 0;

        float zOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawZPos = transform.position.z + zOffset;
        //float clampedZPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        transform.localPosition = new Vector3(rawXPos, clampedYPos, rawZPos);
    }
}
