using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.EventSystems;

public class ChatController : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject panelChat;
    public InputField inputMessage;
    public Text txtMessage;
    [Tooltip("Caracteres mínimos para enviar mensagem")] public int minLength = 2;
    [HideInInspector] public PlayerController playerController;
    public AudioSource audioSource;

    private bool isOpen = false;
    private PhotonView photonView;

    void Start()
    {
        panelChat.SetActive(false);
        photonView = GetComponent<PhotonView>();
        ResetChat();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            ChangeVisible();

            if (isOpen) InputFocus();
            
        }

        //KeyCode.Return = Enter do Meio
        if(isOpen && inputMessage.text.Length >= minLength && Input.GetKeyDown(KeyCode.Return))
        {
            photonView.RPC("SendChatMessage", RpcTarget.All, GetMessage());
            inputMessage.text = string.Empty;
            InputFocus();
        }
    }

    private string GetMessage()
    {
        string c = "#ffa500ff";
        string nickName = PhotonNetwork.LocalPlayer.NickName;

        return string.Format("<b><color={0}>{1}</color></b> - {2}", c, nickName, inputMessage.text);
    }

    [PunRPC]
    private void SendChatMessage(string msg)
    {
        txtMessage.text += msg + "\n";
        audioSource.Play();
    }

    private void InputFocus()
    {
        EventSystem.current.SetSelectedGameObject(inputMessage.gameObject, null);
        inputMessage.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    private void ChangeVisible()
    {
        panelChat.SetActive(isOpen);
        playerController.control = !isOpen;
    }

    private void ResetChat()
    {
        txtMessage.text = string.Empty;
        inputMessage.text = string.Empty;
    }
}
