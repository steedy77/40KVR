using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour {

    public ParticleSystem particleLauncher;
	public ParticleSystem splatterParticles;

	// Use this for initialization
	void Start () {
		
	}

	void OnParticleCollision(GameObject other)
	{
		EmitAtLocation ();
	}

    void EmitAtLocation()
    {
        splatterParticles.Emit(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire2"))
        {
        particleLauncher.Emit (1);
    }
   }
}