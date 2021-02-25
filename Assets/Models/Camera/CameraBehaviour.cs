using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;

    private float distance = 10.0f;
    public float maxDistance = 10.0f;
    public float minDistance = 4.0f;

    private float height = 5.0f;
    public float minHeight = -1;
    public float maxHeight = 10;

    public float heightDamping = 1000f;
    public float rotationDamping = 1f;

    public Vector3 sensibility;

    void LateUpdate()
    {
        if (!target) return;

        distance -= Input.GetAxis("Mouse ScrollWheel") * sensibility.z;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        height -= Input.GetAxis("Mouse Y") * sensibility.y;
        height = Mathf.Clamp(height, minHeight, maxHeight);

        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, transform.eulerAngles.y+Input.GetAxis("Mouse X") * sensibility.x, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(target);

    }
}
