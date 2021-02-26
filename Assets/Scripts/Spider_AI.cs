using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider_AI : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;
    public Transform player;
    public Transform body;
    public Transform head;
    private Transform trans;
    private Vector3 dest;
    public float chaseRange;
    public float attack_1Range;
    private float distance;
    private const int idle = 0;
    private const int chase = 1;
    private const int attack_1 = 2;
    private const int die = 3;
    public int state;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        trans = transform;
        state = idle;
	}
	
	// Update is called once per frame
	void Update () {
        ThinkState();
        SetState(state);
	}

    void ThinkState()
    {
        distance = Vector3.Distance(trans.position, player.position);
        if (distance > chaseRange)
        {
            state = idle;
        }
        else if (distance > attack_1Range && distance <= chaseRange)
        {
            GetComponent<Enemy>().isAttacked = false;
            state = chase;
            dest = player.position;
        }
        else
        {
            state = attack_1;
        }
        if(GetComponent<Enemy>().isAttacked)
        {
            state = chase;
            dest = player.position;
        }
        if (GetComponent<Enemy>().isDied)
        {
            state = die;
        }
    }

    void SetState(int newState)
    {
        switch (newState)
        {
            case idle:
                animator.SetBool("walk", false);
                animator.SetBool("atk_1", false);
                animator.SetBool("die", false);
                agent.ResetPath();
                break;
            case chase:
                animator.SetBool("walk", true);
                animator.SetBool("atk_1", false);
                animator.SetBool("die", false);
                agent.SetDestination(dest);
                break;
            case attack_1:
                animator.SetBool("walk", false);
                animator.SetBool("atk_1", true);
                animator.SetBool("die", false);
                agent.ResetPath();
                break;
            case die:
                animator.SetBool("walk", false);
                animator.SetBool("atk_1", false);
                animator.SetBool("die", true);
                agent.ResetPath();
                trans.GetComponent<BoxCollider>().enabled = false;
                trans.GetComponent<SphereCollider>().enabled = false;
                body.GetComponent<BoxCollider>().enabled = false;
                Destroy(gameObject, 3f);
                break;
        }

    }
}
