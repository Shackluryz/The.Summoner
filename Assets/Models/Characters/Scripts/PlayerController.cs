using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class PlayerController : MonoBehaviour
{

    public bool control = true;
    public Text txtNickname;
    public float speed = 0.12f;
    private bool canJump = false;
    public GameObject fireBall;

    public Animator anim;
    private PhotonView photonView;

    public int vida;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        photonView = GetComponent<PhotonView>();
        if (!PhotonNetwork.IsConnected) return;
        if (photonView.IsMine) {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraBehaviour>().target = GameObject.Find("CameraTarget").gameObject.transform;
            txtNickname.text = PhotonNetwork.LocalPlayer.NickName;
        } else {
            txtNickname.text = photonView.Owner.NickName;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!control || !photonView.IsMine) return;
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * speed;
            anim.Play("Run");
        }
        if (Input.GetKey("s")) {
            transform.position -= transform.forward * speed;
            anim.SetBool("RunBack", true);
            anim.Play("Run Back");
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("s")) {
            anim.SetBool("Run", false);
            anim.SetBool("RunBack", false);
            anim.Play("Idle");
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 3f, 0);            
        }
        else if (Input.GetKey("a"))
        {
            transform.Rotate(0, -3f, 0);            
        }
        if (Input.GetKey("space")) {
            if (canJump) {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
                anim.SetBool("Jump", true);
                anim.Play("Jump");
                canJump = false;
            }  
        }
        if (Input.GetKeyDown("e")) {

            GameObject obj = Instantiate(fireBall, transform.position + new Vector3(0, 1f, 0) + (transform.forward * 0.4f), Quaternion.identity);
            anim.Play("Fire Ball");
            obj.GetComponent<FireBallMove>().direction = transform.forward;
            Destroy(obj, 3f);
        }
    }

    void OnCollisionEnter(Collision obj) {
        if (obj.gameObject.tag == "floor") {
            canJump = true;
            anim.SetBool("Jump", false);
        }    
    }
}
