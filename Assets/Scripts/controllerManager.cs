using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ADD THIS SCRIPT TO BOTH CONTROLLERS */

public class controllerManager : MonoBehaviour {


    /*DEBUG*/
    public bool triggerDown = false;
    public bool triggerUp = false;
    public bool triggerPressed = false;

    //representation of buttons on controller
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject trackedObj;
    //grabs correct controller (L or R)
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private GameObject pickup;

	void Start () {
        trackedObj = GetComponent <SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller == null)
        {
            Debug.Log("CONTROLLER IS NOT INITIALIZED");
            return;
        }

        triggerDown = controller.GetPressDown(triggerButton);
        triggerPressed = controller.GetPress(triggerButton);
        triggerUp = controller.GetPressUp(triggerButton);

        debugPrint(triggerDown,triggerPressed,triggerUp);

        if(triggerDown && pickup != null)
        {
            //controller becomes parent of object
            pickup.transform.parent = this.transform;
            //pickup.GetComponent<Rigidbody>().isKinematic = true;
            pickup.GetComponent<Rigidbody>().useGravity = true;
        }
        if(triggerUp && pickup != null)
        {
            //detach controller from object
            pickup.transform.parent = null;
           
            //Solution: follows pickup | Problem: clipping
            //pickup.GetComponent<Rigidbody>().isKinematic = false;
            
            //Solution: no clipping | Problem: if released will float away
            pickup.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("INPUT: triggerEnter");
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("INPUT: triggerExit");
        pickup = null;
    }

    private void debugPrint(bool td, bool tp, bool tu)
    {
        if (td)
        {
            Debug.Log("INPUT: trigger down");
        }
        if (tp)
        {
            Debug.Log("INPUT: trigger pressed");
        }
        if (tu)
        {
            Debug.Log("INPUT: trigger up");
        }
    }

}

