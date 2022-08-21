using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.wayPoints.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(transform.position, 2);  
    }
}
