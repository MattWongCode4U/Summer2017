using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public int projectileDamage = 25;

	void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        characterHealth health = hit.GetComponent<characterHealth>();
        health.takeDamage(projectileDamage);

        Destroy(gameObject);
    }
}
