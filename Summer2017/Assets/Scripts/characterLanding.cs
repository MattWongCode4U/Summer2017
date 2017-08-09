using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLanding : MonoBehaviour {

    GameObject go;
    static characterScript cs;

	// Use this for initialization
	void Start () {
        cs = GetComponentInParent<characterScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            cs.setJumpsRemaining(cs.getJumpLimit());
        }
    }
}
