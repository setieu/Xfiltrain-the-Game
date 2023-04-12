using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public List<ParticleSystem> particleSystems;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomParticle()
    {
        int randomIndex = Random.Range(0, particleSystems.Count);
        particle = particleSystems[randomIndex];
        particle.Play();
    }
}
