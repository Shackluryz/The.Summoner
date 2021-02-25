using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Animator anim;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) {
            if (!GameObject.Find("Fletcher").gameObject.transform) return;
            transform.LookAt(GameObject.Find("Fletcher").gameObject.transform);
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0) {

                float distance = Vector3.Distance(transform.position, GameObject.Find("Fletcher").transform.position);
                if (distance < 30f) {
                    anim.speed = 2f;
                    anim.Play("walk");
                    transform.position += transform.forward * 0.03f;
                }

            } else {
                anim.Play("idle");
            }
        } else {
            //yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Fire") {

            anim.Play("FallingBack");
            dead = true;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
