using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMotion : MonoBehaviour
{
    public float hoverSpeed = 1.0f; // Adjust the speed of hovering.
    public float rotationSpeed = 30.0f; // Adjust the speed of rotation.
    public float hoverDistance = 0.2f; // Adjust the distance the orb hovers.
    public ParticleSystem pickupParticles; // Reference to the Particle System.


    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Hovering motion (up and down).
        Vector3 newPosition = initialPosition + new Vector3(0, Mathf.Sin(Time.time * hoverSpeed) * hoverDistance, 0);
        transform.position = newPosition;

        // Rotating motion (around its own Y-axis).
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pickupParticles != null)
        {
            pickupParticles.Emit(20); // Emit 20 particles (adjust as needed).
        }
    }
}
