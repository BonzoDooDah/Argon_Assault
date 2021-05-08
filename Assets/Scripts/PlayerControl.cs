using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [Header("General Settings")]
    [Tooltip("Speed at which player ship moves around the screen")]
    [SerializeField] private float controlSpeed = 35f;
    [Tooltip("Maximum horizontal range (+/-)")]
    [SerializeField] private float xRange = 12f;
    [Tooltip("Maximum vertcal range (+/-)")]
    [SerializeField] private float yRange = 7.5f;

    [Header("Movement Settings")]
    [Tooltip("Vertical adjustment of player ship depending on position on screen")]
    [SerializeField] private float pitchFactor = -2f;
    [Tooltip("Vertical adjustment of player ship depending on movement")]
    [SerializeField] private float pitchMovement = -10f;
    [Tooltip("Horizontal adjustment of player ship depending on position on screen")]
    [SerializeField] private float yawFactor = 2f;
    [Tooltip("Horizontal adjustment of player ship depending on movement")]
    [SerializeField] private float rollMovement = -20f;

    [Header("Weapon Prefabs")]
    [Tooltip("Array of GameObjects for the player ship's laser weapons")]
    [SerializeField] private GameObject[] lasers;

    float xThrow = 0f;
    float yThrow = 0f;

    private void Update() {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
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

    private void ProcessFiring() {
        if (Input.GetButton("Fire1")) {
            ActivateLasers(true);
        } else {
            ActivateLasers(false);
        }
    }

    private void ActivateLasers(bool isActive) {
        foreach (GameObject laserItem in lasers) {
            var em = laserItem.GetComponent<ParticleSystem>().emission;
            em.enabled = isActive;
        }
    }
}
