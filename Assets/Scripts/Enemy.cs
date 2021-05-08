using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int numberOfHits = 3;
    [SerializeField] private int scorePerHit = 5;
    [SerializeField] private GameObject hitPrefab = null;
    [SerializeField] private GameObject explosionPrefab = null;
    [SerializeField] private Transform parent = null;

    private ScoreBoard _scoreBoard = null;

    private void Start() {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (numberOfHits < 1) ProcessDestruction();
    }

    private void ProcessHit() {
        if (hitPrefab) {
            GameObject obj = Instantiate(hitPrefab, transform.position, Quaternion.identity);
            if (parent) obj.transform.parent = parent;
        }
        numberOfHits--;
        _scoreBoard.IncreaseScore(scorePerHit);
    }

    private void ProcessDestruction() {
        if (explosionPrefab) {
            GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (parent) obj.transform.parent = parent;
        }
        Destroy(gameObject);
    }
}
