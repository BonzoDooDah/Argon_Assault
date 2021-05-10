using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int numberOfHits = 3;
    [SerializeField] private int scorePerHit = 5;
    [SerializeField] private GameObject hitPrefab = null;
    [SerializeField] private GameObject explosionPrefab = null;
    private GameObject parentGameObject = null;

    private ScoreBoard _scoreBoard = null;

    private void Start() {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
        parentGameObject = GameObject.FindWithTag("CreatedAtRuntime");
    }

    private void AddRigidbody() {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (!rb) {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (numberOfHits < 1) ProcessDestruction();
    }

    private void ProcessHit() {
        if (hitPrefab) {
            GameObject obj = Instantiate(hitPrefab, transform.position, Quaternion.identity);
            if (parentGameObject) obj.transform.parent = parentGameObject.transform;
        }
        numberOfHits--;
        _scoreBoard.IncreaseScore(scorePerHit);
    }

    private void ProcessDestruction() {
        if (explosionPrefab) {
            GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (parentGameObject) obj.transform.parent = parentGameObject.transform;
        }
        Destroy(gameObject);
    }
}
