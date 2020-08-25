using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    public float smoothtime = .15f;
    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothtime);
    }
}
