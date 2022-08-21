using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   public GameObject zombiePrefab;
   public float Timer;
   private float SpawnTimeStartTime;
   public float SpawnTime;
   
   private void Start()
   {
    SpawnTime = GameManager.instance.zombieSpawnTime;
    SpawnTimeStartTime = SpawnTime;
   }
   public void Update()
   {
     
     Timer -= Time.deltaTime;
     if(Timer <= 0)
     {
        GameObject Zombie = Instantiate(zombiePrefab);
        Zombie.transform.position = GameManager.instance.RandomZombieSpawnLocation().transform.position;
        
        Debug.Log("Spawned Zombie");
        //dont let the spawn time reduce lower then a quarter of the starting start time.
        if(SpawnTime > SpawnTimeStartTime / 4)
        {
            //reduce the spawn time
            if(SpawnTime !=5)
            {
            SpawnTime -= 5;
            }
            Debug.Log("Next Spawn in:" + " " + SpawnTime);
        }
        Timer = SpawnTime;
     }
   }
}
