using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
    public float offset =1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(transform.position.x , target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed * Time.deltaTime);
    }
}
