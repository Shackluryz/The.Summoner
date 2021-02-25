using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        
        Transform t = spawnPoint;
        PhotonNetwork.Instantiate(player.name, t.position, t.rotation);

    }

}
