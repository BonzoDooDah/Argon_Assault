using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    [SerializeField] private float destructDelay = 2f;

    private void Start() {
        Destroy(gameObject, destructDelay);
    }
}
