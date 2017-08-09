using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class characterHealth : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    public bool destroyOnDeath;

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void takeDamage(int amount)
    {
        if(!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = 0;

                // called on the Server, but invoked on the clients
                RpcRespawn();

                currentHealth = maxHealth;
            }
        }
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            //Respawn/move player back to original spawn location
            transform.position = gameObject.GetComponent<characterScript>().getSpawn();
        }
    }
}
