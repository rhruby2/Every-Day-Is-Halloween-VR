using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mvmt : MonoBehaviour
{

    public Rigidbody rb_player;

    public float zForce = 200f;
    public float xyForce = 200f;
    public float RotateSpeed = 30f;
    // Use this for initialization
    void Start()
    {
        Debug.Log("init: player_mvmt");
    }

    // Update is called once per frame
    //[T] FixedUpdate preferred for physics modifications
    void FixedUpdate()
    {
        //[T] multiply by Time.deltaTime to update only once per frame
        rb_player.AddForce(0, 0, zForce * Time.deltaTime);
        
        if (Input.GetKey("a"))
        {

            //rb_player.AddForce(-xyForce*Time.deltaTime, 0,0);
            rb_player.AddForce(-xyForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            //rb_player.AddForce(xyForce*Time.deltaTime, 0,0 );
            rb_player.AddForce(xyForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))
        {
            //rb_player.AddForce(xyForce*Time.deltaTime, 0,0 );
            rb_player.AddForce(0, 0, xyForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            //rb_player.AddForce(xyForce*Time.deltaTime, 0,0 );
            rb_player.AddForce(0, 0, -xyForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
            
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
            


    }
}