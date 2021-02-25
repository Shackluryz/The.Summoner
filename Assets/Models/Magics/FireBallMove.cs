using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 initialPosition;
    public float maxDistance = 0;
    public float speed = 0.15f;

    void Update()
    {
        transform.position += direction * speed;      
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            return;
        } else {
            Destroy(gameObject);
        }
        
    }
}
