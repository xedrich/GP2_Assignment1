using UnityEngine;
using System.Collections;

public class BluePickup : MonoBehaviour
{
    public float respawnTime = 5.0f;
    private bool isCollected = false;
    public ParticleSystem pickupParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            // The pickup has been collected.
            isCollected = true;
            GetComponent<Renderer>().enabled = false; // Disable rendering.

            // Trigger the particle burst.
            if (pickupParticles != null)
            {
                pickupParticles.Emit(20); // Emit 20 particles (adjust as needed).
            }

            // Tell the character that a blue orb was collected.
            other.GetComponent<CharacterMovement>().CollectBlueOrb();

            // Start the respawn timer.
            StartCoroutine(RespawnPickup());
        }
    }


    private IEnumerator RespawnPickup()
    {
        yield return new WaitForSeconds(respawnTime);

        // The pickup is back!
        isCollected = false;
        GetComponent<Renderer>().enabled = true;
    }
}
