using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
    [SerializeField] private float levelReloadDelay = 1f;
    [SerializeField] private GameObject meshes = null;
    [SerializeField] private ParticleSystem explosion = null;

    private void OnTriggerEnter(Collider other) {
        // disable player controls
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        // hide meshes and start explosion
        if (meshes) Destroy(meshes);
        if (explosion) explosion.Play();

        // wait 1 second and reload level
        StartCoroutine(ReloadLevel(levelReloadDelay));
    }

    private IEnumerator ReloadLevel(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
