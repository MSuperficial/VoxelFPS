using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotate : MonoBehaviour
{
    private Transform trans;
    private Vector3 direction;
    public Camera _camera;
    // Use this for initialization
    void Start()
    {
        trans = this.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //this.transform.rotation = Quaternion.Euler(_camera.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.rotation = _camera.transform.rotation;
    }
}
