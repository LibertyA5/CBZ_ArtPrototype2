using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticleSpawner : MonoBehaviour
{
    // Reference to your particle system prefab
    public GameObject SnowParticlesPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // Check if a specific object was hit (optional)
        // if(collision.gameObject.CompareTag("YourTargetTag"))
        // {
        // Instantiate the particle prefab at the point of collision
        Instantiate(SnowParticlesPrefab, collision.contacts[0].point, Quaternion.identity);

        // Optional: Destroy the particle effect after it finishes (add a script to the prefab to destroy itself after a few seconds)
        // Destroy(effectInstance, effectInstance.GetComponent<ParticleSystem>().main.duration);
        // }
    }
}

