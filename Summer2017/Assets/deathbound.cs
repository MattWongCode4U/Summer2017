using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbound : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        characterHealth health = hit.GetComponent<characterHealth>();

        //Instant kill player
        health.takeDamage(health.getMaxHealth());
    }
}
