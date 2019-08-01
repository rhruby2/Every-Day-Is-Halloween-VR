using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

    public Transform player;
    public Vector3 camera_pos_offset = new Vector3(0, 1, -5);

    // Update is called once per frame
    void Update () {
        //Debug.Log(player.position);
        //set camera position to follow player with offset
        transform.position = player.position + camera_pos_offset;
	}
}
