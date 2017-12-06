using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_sounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip swoosh;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void swing_sound()
    {
        audioSource.PlayOneShot(swoosh, 0.5f);
    }
}
