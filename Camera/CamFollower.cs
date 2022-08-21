using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform playerToFollowTransform;
    
    void Start()
    {
     GameManager.instance.MiniMap.Add(this.gameObject);
     transform.parent = null;
    }

   
    void LateUpdate()
    {
        Vector3 pos = playerToFollowTransform.position;
        
        pos.y = transform.position.y;
        transform.position = pos;
    }
}
