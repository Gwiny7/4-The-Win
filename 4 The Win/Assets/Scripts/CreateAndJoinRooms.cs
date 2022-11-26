using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInput;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;
    private PhotonView PV;
    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;
    public int[] PlayersActorOrder = { 0, 0, 0, 0 };
    int nextIndex;
    public GameObject playButton;

    private void Awake(){
        PhotonNetwork.JoinLobby();
        PV = GetComponent<PhotonView>();
    }

    public void CreateRoom()
    {
        if(roomInput.text.Length >= 1){
            PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions(){MaxPlayers = 4, BroadcastPropsChangeToAll = true});
        }
    }

    public void JoinRoom()
    {
        if(roomInput.text.Length >= 1){
            PhotonNetwork.JoinRoom(roomInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        JoinPlayerArray();
        UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerOnArray(newPlayer);
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        DeletePlayerOnArray(otherPlayer);
        UpdatePlayerList();
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        LeavePlayerArray();
        UpdatePlayerList();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        UpdatePlayerList();
    }

    public void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if(PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach(KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            
            if(player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }
            
            playerItemsList.Add(newPlayerItem);
        }
        for(int i = 0; i < 4; i++){
            Debug.Log("Player" + (i + 1) + " Actor Number: " + PlayersActorOrder[i] + ";");
        }
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    public void OnClickPlayButton()
    {
        nextIndex = Random.Range(2, 6);
        PlayerArrayControl.currentLevel = nextIndex;
        PV.RPC("RPC_ListPlayers", RpcTarget.AllBuffered);
        PhotonNetwork.LoadLevel(nextIndex);
    }

    private void JoinPlayerArray(){
        foreach(Player player in PhotonNetwork.PlayerList){
            AddPlayerOnArray(player);
        }
    }

    private void LeavePlayerArray(){
        for(int i = 0; i < 4; i++){
            PlayersActorOrder[i] = 0;
        }
    }

    private void AddPlayerOnArray(Player player){
        for(int i = 0; i < 4; i++){
            if(PlayersActorOrder[i] == 0){
                PlayersActorOrder[i] = player.ActorNumber;
                return;
            }
        }
    }

    private void DeletePlayerOnArray(Player player){
        for(int i = 0; i < 4; i++){
            if(player.ActorNumber == PlayersActorOrder[i]){
                for(int x = i; x < 4; x++){
                    if(x < 3){
                        PlayersActorOrder[x] = PlayersActorOrder[x+1];
                    }
                    else{
                        PlayersActorOrder[x] = 0;
                        return;
                    }
                }
            }
        }
    }

    [PunRPC]
    void RPC_ListPlayers(){
        for(int i = 0; i < 4; i++){
            PlayerArrayControl.PlayersActorOrder[i] = PlayersActorOrder[i];
        }
    }
}