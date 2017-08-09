using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class characterScript : NetworkBehaviour {

    public int jumpLimit = 2;
    int jumpsRemaining;
    public float xSpeed = 5.0f, ySpeed = 5.0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    Vector3 spawn;
    Vector3 xTrans, yTrans;
    Rigidbody rb;
    float bulletSpeed = 6.0f;

	// Use this for initialization
	void Start () {
        spawn = transform.position;

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
        if (!isLocalPlayer)
        {
            return;
        }

        //Movement
        if (Input.GetKey("a"))
        {
            moveLeft();
        }
        if (Input.GetKey("d"))
        {
            moveRight();
        }

        //Jumping
        if (Input.GetKeyDown("w"))
        {
            if (jumpsRemaining > 0)
            {
                jumpsRemaining--;
                jump();
            }
        }
        //Debug.Log("Jumps Remaining: " + jumpsRemaining);

        //Firing
        if (Input.GetKeyDown("space"))
        {
            CmdFire();
        }
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

    public Vector3 getSpawn()
    {
        return spawn;
    }

    [Command]
    void CmdFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, 
            bulletSpawn.position, 
            bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        //Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        //Destroy bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
