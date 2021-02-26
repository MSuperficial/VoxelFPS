using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Vector3 firePosition;
    private Transform trans;
    private Animator animator;
    public GameObject weapon;
    public float Hp;
    public bool isFiring;
    public bool died;
	// Use this for initialization
	void Start () {
        isFiring = false;
        died = false;
        trans = transform;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        isFiring = false;
        if(!died && Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isFiring = true;
                firePosition = trans.position;
            }
        }
        if(died)
        {
            animator.SetBool("isDied", true);
            animator.SetBool("isIdling", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isFiring", false);
        }
	}

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if(Hp < 0)
        {
            Hp = 0;
            died = true;
        }
    }
}
