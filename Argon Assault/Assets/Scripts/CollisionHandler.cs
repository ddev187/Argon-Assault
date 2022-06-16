using System.Reflection.Emit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;

    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] MeshRenderer[] shipMeshRenderers;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void DisableLasersAfterCrash()
    {
        var playerControlsScript = gameObject.GetComponent<PlayerControls>();
        playerControlsScript.SetLasersActive(false);
    }

    void StartCrashSequence()
    {
        DisableLasersAfterCrash();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        
        if(!explosionVFX.isPlaying)
        {
            explosionVFX.Play();
        }
        foreach(MeshRenderer meshRenderer in shipMeshRenderers)
        {
            meshRenderer.enabled = false;
        }
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
