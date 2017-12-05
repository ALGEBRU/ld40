using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraS : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    public Transform backGround;
    public Transform healthBar;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float smoothSpeed = 0.125f;

    private void LateUpdate()
    {

        Vector3 desiredPosition = new Vector3(target.position.x, 0.0f, 0.0f) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = desiredPosition;
        backGround.position = transform.position + new Vector3(0f, 0f, 10);
        healthBar.position = new Vector3(transform.position.x, -4.75f, 0f);
    }
}
