using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainParticle : MonoBehaviour
{
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            particle.Play();
        }
    }
}
