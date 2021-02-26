using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_AI : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;
    public Transform player;
    public Transform head;
    private Transform trans;
    private Vector3 dest;
    private Vector3 firePosition;
    //public AudioClip clip_attack;
    //public AudioClip clip_chase;
    //public AudioClip clip_die;
    //private AudioSource audioSource;
    public float chaseRange;
    public float attackRange;
    private float distance;
    private const int idle = 0;
    private const int walk = 1;
    private const int attack = 2;
    private const int die = 3;
    private const int beAttack = 4;
    // private const int find = 5;
    public int state;
    private bool finding;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        state = idle;
        trans = transform;
        finding = false;
	}
	
	// Update is called once per frame
	void Update () {
        firePosition = player.GetComponent<Player>().firePosition;
        ThinkState();
        SetState(state);
	}

    void ThinkState()
    {
        distance = Vector3.Distance(trans.position, player.position);
        //Debug.Log(distance + " , " + state);
        if(distance > chaseRange)
        {
            if(!GetComponent<Enemy>().isAttacked)
            {
                state = idle;
            }
            if(player.GetComponent<Player>().isFiring || finding)
            {
                finding = true;
                dest = firePosition;
                state = walk;
                if (Vector3.Distance(trans.position, firePosition) <= 5f)
                {
                    finding = false;
                }
            }
        }
        else if(distance > attackRange && distance <= chaseRange)
        {
            state = walk;
            dest = player.position;
            finding = false;
        }
        else
        {
            state = attack;
            //audioSource.clip = clip_attack;
        }
        if(GetComponent<Enemy>().isAttacked)
        {
            state = beAttack;
        }
        if (GetComponent<Enemy>().isDied)
        {
            state = die;
            //audioSource.clip = clip_die;
            //audioSource.Play();
        }
    }

    void SetState(int newState)
    {
        switch(newState)
        {
            case idle:
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isDied", false);
                animator.SetBool("beingAttacked", false);
                agent.ResetPath();
                break;
            case walk:
                animator.SetBool("beingAttacked", false);
                if(!agent.isStopped)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isAttacking", false);
                    animator.SetBool("isDied", false);
                    agent.SetDestination(dest);
                }
                break;
            case attack:
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
                animator.SetBool("isDied", false);
                animator.SetBool("beingAttacked", false);
                agent.ResetPath();
                trans.LookAt(player.position);
                break;
            case beAttack:
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isDied", false);
                animator.SetBool("beingAttacked", true);
                agent.ResetPath();
                agent.isStopped = true;
                if(coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = EnableAgentDelay(0.5f);
                StartCoroutine(coroutine);
                GetComponent<Enemy>().isAttacked = false;
                break;
            case die:
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isDied", true);
                animator.SetBool("beingAttacked", false);
                agent.ResetPath();
                trans.GetComponent<CapsuleCollider>().enabled = false;
                trans.GetComponent<SphereCollider>().enabled = false;
                head.GetComponent<BoxCollider>().enabled = false;
                Destroy(gameObject, 3f);
                break;
        }
    }

    IEnumerator EnableAgentDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        agent.isStopped = false;
    }
}
