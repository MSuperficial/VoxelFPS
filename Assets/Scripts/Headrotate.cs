using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headrotate : MonoBehaviour {
    private Transform trans;
    private Vector3 direction;
    public Camera _camera;
	// Use this for initialization
	void Start () {
        trans = this.transform;
	}
	
	// Update is called once per frame
	void LateUpdate (){
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            direction = hit.point;
            //Debug.DrawLine(trans.position, hit.point, Color.blue);
        }
        trans.LookAt(direction);

    }
}
