using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f,3f,-6f);
    public float followSpeed = 5f;
    public float rotateSpeed=3f;
    private float currentYaw = 0f;
    
    void LateUpdate()
    {
       currentYaw+= Input.GetAxis("Mouse X")*rotateSpeed;
       Quaternion rotation = Quaternion.Euler(0f,currentYaw,0f);
       Vector3 desirePosition = player.position+rotation*offset;
       transform.position= Vector3.Lerp(transform.position,desirePosition,followSpeed*Time.deltaTime);
       transform.LookAt(player.position+Vector3.up*1.5f);
    }
}
