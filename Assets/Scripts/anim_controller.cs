using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_controller : MonoBehaviour {
    public Animator animController;

	// Use this for initialization
	void Start () {
        Debug.Log("init anim_controller");
        animController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player_inventory.instance.keyDoorTrigger)
        {
            playBasementDoorsAnimation();
        }
	}
    public void playBasementDoorsAnimation()
    {
        animController.Play("basementDoors");
    }
}
