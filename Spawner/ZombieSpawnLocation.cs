using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnLocation : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.zombieSpawnLocations.Add(this.gameObject);
    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, 2);  
    }
}
