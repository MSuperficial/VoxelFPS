using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
 //   private Transform trans;
 //   public Transform ptrans;
 //   private RaycastHit hit1;
 //   private RaycastHit hit2;
 //   private RaycastHit hit3;
 //   private Vector3 targetPosition;
 //   private Vector3 ppos;
 //   public float rotSpeed;
 //   private float rot_x;
 //   private float rot_y;
 //   private float rot_z;
 //   public float rot_x_min;
 //   public float rot_x_max;
 //   private float distance;
 //   public float distance_min;
 //   public float distance_max;
 //   public float scrSpeed;
 //   // Use this for initialization
 //   void Start () {
 //       trans = transform;
 //       rot_x = trans.eulerAngles.x;
 //       rot_y = trans.eulerAngles.y;
 //       rot_z = trans.eulerAngles.z;
 //       distance = distance_max;
 //   }
	
	//// Update is called once per frame
	//void Update (){
 //       ppos = ptrans.position + Vector3.up * 2.0f;
 //       rot_x -= Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
 //       rot_y = ptrans.eulerAngles.y;
 //       rot_z = 0f;
 //       rot_x = Mathf.Clamp(rot_x, rot_x_min, rot_x_max);
 //       distance -= Input.GetAxis("Mouse ScrollWheel") * scrSpeed * Time.deltaTime;
 //       distance = Mathf.Clamp(distance, distance_min, distance_max);
 //   }

 //   void FixedUpdate(){
 //       Quaternion rotation = Quaternion.Euler(rot_x, rot_y, rot_z);
 //       targetPosition = rotation * new Vector3(0f, 0f, -distance) + ppos;
 //       trans.rotation = rotation;
 //       Ray ray1 = new Ray(targetPosition, (ppos - targetPosition).normalized);
 //       if (Physics.Raycast(ray1, out hit1))
 //       {
 //           if (hit1.collider.gameObject.tag == "Player" || hit1.collider.gameObject.tag == "Others" || hit1.collider.gameObject.tag == "Enemy")
 //           {
 //               //trans.position = Vector3.Lerp(trans.position, targetPosition, Time.deltaTime * 10f);
 //               trans.position = targetPosition;
 //           }
 //           //Debug.DrawLine(targetPosition, hit1.point, Color.yellow);
 //       }
 //   }

 //   void LateUpdate(){
 //       Ray ray2 = new Ray(ppos, (trans.position - ppos).normalized);
 //       if (Physics.Raycast(ray2, out hit2))
 //       {
 //           if (hit2.collider.gameObject.tag == "Ground")
 //           {
 //               trans.position = Vector3.Lerp(trans.position, hit2.point + (ppos - trans.position).normalized * 0.5f, Time.deltaTime * 5f);
 //               //trans.position = hit2.point + (ptrans.position - trans.position).normalized * 0.5f;
 //               //Debug.DrawLine(hit2.point, ppos, Color.red);
 //           }
 //       }
 //       Ray ray3 = new Ray(ppos, (targetPosition - ppos).normalized);
 //       if (Physics.Raycast(ray3, out hit3))
 //       {
 //           if (hit1.collider.gameObject.tag == "Ground" && hit2.collider.gameObject.tag == "MainCamera" && hit3.collider.gameObject.tag == "Ground")
 //           {
 //               trans.position = Vector3.Lerp(trans.position, hit3.point + (ppos - trans.position).normalized * 0.5f, Time.deltaTime * 5f);
 //               //trans.position = hit3.point + (ptrans.position - trans.position).normalized * 0.5f;
 //           }
 //       }
 //       //Debug.DrawLine(ppos, trans.position, Color.green);
 //       trans.LookAt(ppos + Vector3.up * 3.0f);
 //   }
}
