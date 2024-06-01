using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviourPunCallbacks
{

    [SerializeField] private string VersionName = "0.1";
    [SerializeField] GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPannel;
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField creategameInput;
    [SerializeField] private InputField joingameInput;
    [SerializeField] private GameObject startButton;


    private void Awake()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = VersionName;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        UsernameMenu.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected to Master");
    }

    public void ChangeUsernameInput()
    {
        if (usernameInput.text.Length > 0)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void SetUsername()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.NickName = usernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(creategameInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(joingameInput.text, roomOptions, TypedLobby.Default);

    }

    public override void OnJoinedRoom() 
    {
        PhotonNetwork.LoadLevel("testing");
        Debug.Log("Joined Room");
    }


}