using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLanding : MonoBehaviour {

    GameObject go;
    characterMovement cm;

	// Use this for initialization
	void Start () {
        cm = GetComponentInParent<characterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            cm.setJumpsRemaining(cm.getJumpLimit());
        }
    }
}
