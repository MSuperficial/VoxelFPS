using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {
    private ParticleSystem ps;
	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
        ps.Play();
        Destroy(gameObject, ps.main.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
