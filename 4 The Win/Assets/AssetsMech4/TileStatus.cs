using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TileStatus : MonoBehaviour
{
    public MapCreation MC;

    // Start is called before the first frame update
    // Update is called once per frame

    [PunRPC]
    void testClick(Vector2 pos, int actor){
        MC.GetTile((int)pos.x,(int)pos.y).GetComponent<TileBehaviour>().testClick(actor);
    }
}
