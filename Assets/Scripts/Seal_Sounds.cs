using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal_Sounds : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Seal Sounds")]
    public AudioClip sound1;
    public AudioClip sound2;

    [Header("Timing")]
    public float minTimeBetweenSounds = 5f;
    public float maxTimeBetweenSounds = 15f;

    void Start()
    {
        StartCoroutine(PlayRandomSealSound());
    }
    IEnumerator PlayRandomSealSound()
    {
        while (true)
        {
            float waitTime = Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
            yield return new WaitForSeconds(waitTime);

            // Choose randomly between the two sounds
            AudioClip chosenSound = Random.value > 0.5f ? sound1 : sound2;

            audioSource.PlayOneShot(chosenSound);
        }
    }
}
