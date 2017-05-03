using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour {

    public int jumpLimit = 2;
    int jumpsRemaining;
    public float xSpeed = 5.0f, ySpeed = 5.0f;

    //float x, y, z;
    Vector3 xTrans, yTrans;
    static Vector3 spawn;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        xTrans = new Vector3(xSpeed, 0);
        yTrans = new Vector3(0, ySpeed);
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = jumpLimit;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            moveLeft();
        }
        if (Input.GetKey("d"))
        {
            moveRight();
        }
        if (Input.GetKeyDown("w"))
        {
            if (jumpsRemaining > 0)
            {
                jumpsRemaining--;
                jump();
            }
        }

        Debug.Log("Jumps Remaining: " + jumpsRemaining);

    }

    void moveLeft()
    {
        rb.velocity -= xTrans;
    }

    void moveRight()
    {
        rb.velocity += xTrans;
    }

    void jump()
    {
        rb.velocity += yTrans;
    }

    public int getJumpLimit()
    {
        return jumpLimit;
    }

    public int getJumpsRemaining()
    {
        return jumpsRemaining;
    }

    public void setJumpsRemaining(int jumps)
    {
        jumpsRemaining = jumps;
    }

    public void setSpawn(Vector3 newSpawn)
    {
        spawn = new Vector3(newSpawn.x, newSpawn.y, newSpawn.z);
    }

    void respawn()
    {
        transform.position = spawn;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DeathBound")
        {
            respawn();
        }
    }
}
