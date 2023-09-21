using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcGuide : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform player; // Player's Transform
    public Vector3 fixedUpDirection = Vector3.up; // Direction that should always face the player
    public float activationDistance = 5f; // Proximity distance for automatic audio play

    private bool hasPlayed = false; // Flag to track if the audio has been played

    private void Start()
    {
        // Add a listener to the button's onClick event
        button.onClick.AddListener(PlayAudio);
    }

    private void Update()
    {
        // Calculate the distance between the player and the NPC
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the activation distance and the audio hasn't been played yet
        if (distanceToPlayer <= activationDistance && !hasPlayed)
        {
            PlayAudio(); // Automatically play the audio
            hasPlayed = true; // Set the flag to indicate the audio has been played
        }

        // Calculate the direction from the game object to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the rotation needed to face the player
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, fixedUpDirection);

        // Apply the rotation while preserving the fixedUpDirection
        transform.rotation = targetRotation;
    }

    public void PlayAudio()
    {
        // Play the specified audio clip through the AudioSource
        audioSource.PlayOneShot(audioClip);
    }
}
