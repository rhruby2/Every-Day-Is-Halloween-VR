using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour {
    //public ScriptName varOfScript;
    //public player_inventory inventory;

    void Start()
    {
    }

    //called when player starts to collide with another object
    void OnTriggerEnter(Collider collider)
    {
        string name = collider.name;
        Debug.Log("controller hit object" + name);
    
        player_inventory playerInventory = player_inventory.instance;
        if (name == "key")
        {
            playerInventory.pickedUpKey = true;
            Debug.Log("picked up key!");
        }
        if (name == "basementDoors")
        {
            if (playerInventory.pickedUpKey)
            {
                //trigger door animation
                Debug.Log("setting door trigger");
                playerInventory.keyDoorTrigger = true;

            }
            else
            {
                Debug.Log("have not picked up key yet!");
            }
            
        }
    }
}
