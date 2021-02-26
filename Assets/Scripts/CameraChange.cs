using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
    public GameObject thirdCamera;
    public GameObject firstCamera;
    public GameObject player;
    //private Transform ttrans;
    private Transform ftrans;
    //private Transform ptrans;
    //private Vector3 tpos;
    //private Vector3 fpos;
    //private Vector3 ppos;
    private float rot_x;
    public float rotSpeed;
    public float rot_x_min;
    public float rot_x_max;
    private float depth;
	// Use this for initialization
	void Start () {
        //ttrans = thirdCamera.transform;
        ftrans = firstCamera.transform;
        //ptrans = player.transform;
        rot_x = ftrans.eulerAngles.x;
        if (Application.platform == RuntimePlatform.WebGLPlayer) rotSpeed *= 0.25f;
    }
	
	// Update is called once per frame
	void Update () {
        depth = firstCamera.GetComponent<Camera>().depth;
        rot_x -= Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        rot_x = Mathf.Clamp(rot_x, rot_x_min, rot_x_max);
        ftrans.rotation = Quaternion.Euler(rot_x, ftrans.eulerAngles.y, ftrans.eulerAngles.z);
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate(){
        //tpos = ttrans.position;
        //fpos = ftrans.position;
        //ppos = ptrans.position + Vector3.up * 2.0f;
        //Debug.Log(Vector3.Distance(tpos, ppos));
        //ftrans.rotation = Quaternion.Euler(rot_x, ftrans.eulerAngles.y, ftrans.eulerAngles.z);
        //if (Vector3.Distance(tpos, ppos) <= 4.0f)
        //{
        //    firstCamera.GetComponent<Camera>().depth = 0;
        //}
        //else
        //{
        //    firstCamera.GetComponent<Camera>().depth = -2;
        //}
        if(Input.GetKeyDown(KeyCode.V))
        {
            if (depth == -2)
                depth = 0;
            else
                depth = -2;
        }
        firstCamera.GetComponent<Camera>().depth = depth;
    }
}
