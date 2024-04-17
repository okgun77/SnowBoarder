using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;

    private bool hasCrashed = false;

    // private PlayerController playerController;

    private void Start()
    {
        // playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            // playerController.DisableControls();
            GetComponent<PlayerController>().DisableControls();
            Invoke("ReloadScene", delayTime);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
