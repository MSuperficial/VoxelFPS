using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private Transform trans;
    private CharacterController controller;
    private Vector3 direction;
    private Animator animator;
    private float dir_y;
    public float speed;
    public float jumpspeed;
    public float gravity;
    private float rot_y;
    public float rotSpeed;
    private float h;
    private float v;
    private bool isWalking;
	// Use this for initialization
	void Start () {
        trans = transform;
        rot_y = trans.eulerAngles.y;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        direction = Vector3.zero;
        dir_y = direction.y;
        if (Application.platform == RuntimePlatform.WebGLPlayer) rotSpeed *= 0.25f;
    }
	
	// Update is called once per frame
	void Update () {
        //Rotate
        rot_y += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        
        Quaternion rotation = Quaternion.Euler(trans.eulerAngles.x, rot_y, trans.eulerAngles.z);
        trans.rotation = rotation;
        //Move
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        direction = h * trans.right + v * trans.forward;
        //direction = transform.TransformDirection(direction);
        direction = direction.normalized * speed;
        direction += dir_y * trans.up;
        dir_y = direction.y;
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dir_y = jumpspeed;
            }
        }
        dir_y -= gravity * Time.deltaTime;
        direction.y = Mathf.Clamp(direction.y, -gravity, jumpspeed);
        if(h != 0 || v != 0)
        {
            if(!GetComponent<Player>().died)
            {
                isWalking = true;
            }
        }
        else
        {
            isWalking = false;
        }
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", controller.isGrounded);
    }

    void FixedUpdate(){
        if(!GetComponent<Player>().died)
        {
            controller.Move(direction * Time.deltaTime);
        }
    }
}
