using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerHealth : MonoBehaviour
{
    #region "Variables"
    public Image fillHealth;
    public float life = 100;
    public float reviveTime = 3.0f;

    private PlayerController playerController;
    private PhotonView photonView;
    private float currentLife;
    #endregion

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        photonView = GetComponent<PhotonView>();
        currentLife = life;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy") && photonView.IsMine && playerController.control)
        {
            currentLife -= UnityEngine.Random.Range(15, 20);
            photonView.RPC("Damage", RpcTarget.AllBuffered, currentLife);
        }
            
    }

    [PunRPC]
    private void Damage(float newLife)
    {
        currentLife = newLife;
        fillHealth.fillAmount = currentLife / life;
        CheckIsDeath();
    }

    private void CheckIsDeath()
    {
        if (currentLife <= 0 && photonView.IsMine)
        {          
            playerController.control = false;
            StartCoroutine(Revive());
        }
    }

    private IEnumerator Revive()
    {
        yield return new WaitForSeconds(reviveTime);
        playerController.control = true;
        currentLife = life;
        fillHealth.fillAmount = 1;
    }
}
