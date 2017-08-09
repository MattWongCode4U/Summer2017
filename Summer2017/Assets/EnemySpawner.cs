using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] spawnLocations;

    public override void OnStartServer()
    {
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            var spawnPosition = spawnLocations[i];

            var spawnRotation = Quaternion.Euler(
                0.0f,
                0.0f,
                0.0f);
            
            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition.position, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
}