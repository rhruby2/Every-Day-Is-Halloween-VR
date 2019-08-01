using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_inventory : MonoBehaviour {

    public static player_inventory instance;

    public bool pickedUpKey = false;
    public bool keyDoorTrigger = false;

    void Awake()
    {
        //setting up AudioManager singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
        // Use this for initialization
        void Start () {
        Debug.Log("init player_inventory");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
