using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShooter : MonoBehaviour
{
    // The damage that will be dealt to the enemy
    public float damage = 10.0f;
    public ParticleSystem muzzleParticle;
    public GameObject decalPrefabParticle;
    
    public AudioClip fireSFX;

    // The audio source for playing the fire sound effect
    public AudioSource audioSource;

    void Update()
    {
        // Check if the player has pressed the fire button
        if (Input.GetButtonDown("Fire1"))
        {
            muzzleParticle.Play(); 
            audioSource.PlayOneShot(fireSFX);
            // Create a ray from the center of the camera
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            // Create a raycast hit to store information about what the ray hits
            RaycastHit hit;

            // If the raycast hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object has a Health component
                Health health = hit.collider.GetComponent<Health>();
                if (health != null)
                {
                    // Deal damage to the object
                    var decalParticle = Instantiate(decalPrefabParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));

                    // Set the parent of the decal particle to the object it hit, so that it moves with the object
                    decalParticle.transform.SetParent(hit.transform);

                    // Destroy the decal particle after a short delay
                    Destroy(decalParticle, 0.1f);

                    health.TakeDamage(damage);
                }
            }
        }
    }
}
