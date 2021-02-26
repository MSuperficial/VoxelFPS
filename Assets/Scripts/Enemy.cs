using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform player;
    public float Hp;
    public float damage;
    private float timer = 0f;
    public bool isDied;
    public bool isAttacked;
    private int state;
	// Use this for initialization
	void Start () {
        isDied = false;
        isAttacked = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(gameObject.name.Contains("zombie"))
        {
            state = GetComponent<Zombie_AI>().state;
        }
        if(gameObject.name.Contains("Spider"))
        {
            state = GetComponent<Spider_AI>().state;
        }
        if (Hp <= 0)
            isDied = true;
	}

    public void TakeDamage(float damage)
    {
        isAttacked = true;
        Hp -= damage;
        if (Hp < 0)
            Hp = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if(state != 2)
        {
            timer = 0f;
        }
        else if (other.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                player.GetComponent<Player>().TakeDamage(damage);
                timer = 0f;
            }
        }
    }
}
