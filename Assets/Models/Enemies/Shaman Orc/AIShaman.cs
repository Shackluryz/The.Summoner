using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShaman : MonoBehaviour
{
    private Animator anim;
    private bool dead = false;
    private int hit = 0;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (!dead) {
            if (!GameObject.Find("Fletcher").gameObject.transform) return;
            transform.LookAt(GameObject.Find("Fletcher").gameObject.transform);
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0) {

                float distance = Vector3.Distance(transform.position, GameObject.Find("Fletcher").transform.position);
                if (distance < 30f) {
                    anim.speed = 0.5f;
                    anim.Play("Walking");
                    transform.position += transform.forward * 0.03f;
                }

            } else {
                anim.Play("Idle");
            }
        }

    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Fire") {

            hit++;
            if (hit > 4) {
                anim.SetTrigger("Death");
                dead = true;
                Destroy(col.gameObject);
            } else {
                anim.Play("React");  
            }
            
        }
    }
}
