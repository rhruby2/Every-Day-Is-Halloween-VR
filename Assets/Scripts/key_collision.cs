using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_collision : MonoBehaviour {
    //public ScriptName varOfScript;
    public player_mvmt mvmt;
    public player_inventory inventory;
    public anim_controller animController;

    //called when key starts to collide with another object
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("hit object" + collisionInfo.collider.name);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "key")
        {
            inventory.pickedUpKey = true;
            Debug.Log("picked up key!");
        }
        if (collider.name == "basementDoors")
        {
            if (inventory.pickedUpKey)
            {
                //trigger door animation
                Debug.Log("doors animation not yet implemented");
            }
            else
            {
                Debug.Log("have not picked up key yet!");
            }

        }
    }
}
