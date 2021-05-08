using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"{other.gameObject.name} was triggered with {gameObject.name}");
    }
}
