using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
    [SerializeField] private float levelReloadDelay = 1f;

    private void OnTriggerEnter(Collider other) {
        // disable player controls
        GetComponent<PlayerControl>().enabled = false;

        // wait 1 second and reload level
        StartCoroutine(ReloadLevel(levelReloadDelay));
    }

    private IEnumerator ReloadLevel(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
