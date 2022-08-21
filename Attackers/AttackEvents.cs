using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvents : MonoBehaviour
{
    public AiController aiController;
    
    void Start()
    {
        aiController = GetComponentInParent<AiController>();
    }

    public void StopMoving()
    {
     aiController.aiPath.canMove = false;
    }
    public void StartMoving()
    {
     aiController.aiPath.canMove = true;
    }
    public void HitCoolDown()
    {
        GetComponent<Animator>().SetBool("isHit",false);
    }

    void Update()
    {
        
    }
}
