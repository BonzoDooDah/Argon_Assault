using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [SerializeField] private float controlSpeed = 35f;
    [SerializeField] private float xRange = 12f;
    [SerializeField] private float yRange = 7.5f;

    [SerializeField] private float pitchFactor = -2f;
    [SerializeField] private float pitchMovement = -10f;
    [SerializeField] private float yawFactor = 2f;
    [SerializeField] private float rollMovement = -20f;

    float xThrow = 0f;
    float yThrow = 0f;

    private void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange),
            Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange),
            transform.localPosition.z
            );
    }

    private void ProcessRotation() {
        float positionalPitch = transform.localPosition.y * pitchFactor;
        float controlPitch = yThrow * pitchMovement;

        float pitch = positionalPitch + controlPitch;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = xThrow * rollMovement;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
