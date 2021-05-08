using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int points = 100;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform parent;

    private ScoreBoard _scoreBoard;

    private void Start() {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other) {
        _scoreBoard.IncreaseScore(points);

        GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        obj.transform.parent = parent;

        Destroy(gameObject);
    }
}
