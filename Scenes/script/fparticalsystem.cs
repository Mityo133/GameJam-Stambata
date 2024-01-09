using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fparticalsystem : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDelay = 2.0f; // Delay before the object starts moving
    public float particleDelay = 1.0f; // Delay before the particle system starts

    private bool canMove = false;
    private float moveTimer = 0.0f;
    private bool particleStarted = false;

    public ParticleSystem particleSystemPrefab;

    void Start()
    {
        // Set up the delays
        moveTimer = -moveDelay;
    }

    void Update()
    {
        // Increment the timer
        moveTimer += Time.deltaTime;

        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E) && !canMove)
        {
            canMove = true; // Set to true to start movement
        }

        // Check if the delay time has passed and movement is allowed
        if (moveTimer >= 0 && canMove)
        {
            // Move the object down relative to its local orientation for 5 times
            for (int i = 0; i < 5; i++)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);

                // Wait for a short delay between movements
                if (i < 4)
                {
                    // Increase the timer to introduce a short delay between movements
                    moveTimer += 0.1f;
                    return;
                }
            }

            // Reset variables after movement is completed
            canMove = false;
            moveTimer = -moveDelay;

            // Start the particle system with a delay
            if (!particleStarted)
            {
                Invoke("StartParticle", particleDelay);
                particleStarted = true;
            }
        }
    }

    void StartParticle()
    {
        // Instantiate the particle system prefab
        ParticleSystem newParticleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

        // Optionally, you can parent the particle system to the current GameObject
        newParticleSystem.transform.parent = transform;

        // Play the particle system
        newParticleSystem.Play();
    }
}

