using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour {
    public MeshRenderer mesh;
    public int ammo;
    public int Hp;
    public float interval;
    private float timer;
	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!mesh.enabled)
        {
            timer += Time.deltaTime;
            if(timer >= interval)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                mesh.enabled = true;
                timer = 0.0f;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(gameObject.activeSelf)
            {
                other.GetComponent<Player>().Hp += Hp;
                other.GetComponent<Player>().weapon.GetComponent<DesertEagle>().bullet += ammo;
                if (other.GetComponent<Player>().Hp > 100)
                {
                    other.GetComponent<Player>().Hp = 100;
                }
                if (other.GetComponent<Player>().weapon.GetComponent<DesertEagle>().bullet > 50)
                {
                    other.GetComponent<Player>().weapon.GetComponent<DesertEagle>().bullet = 50;
                }
                gameObject.GetComponent<BoxCollider>().enabled = false;
                mesh.enabled = false;
                timer = 0.0f;
            }
        }
    }
}
