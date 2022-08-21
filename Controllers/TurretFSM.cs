using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFSM : AiController
{
    public override void Start()
    {
        GameManager.instance.FriendlyControllers.Add(this);
        //base.Start();
        currentState = AiStates.Idle;
    }

    
    public void Update()
    {
       MakeDecisions();
    }
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AiStates.Idle:  
            timeSpentInState += Time.deltaTime;
            //do nothing TODO: Reset view to forward
            targetNearestEnemy();   
            if(isCanSee(target) && !isOnTarget(target))
            {
                ChangeState(AiStates.Turn);
            }        
            break;
        }
        switch (currentState)
        {
            case AiStates.Turn:
            timeSpentInState += Time.deltaTime;
            Debug.Log("Turning");
            DoTurnState();
            targetNearestEnemy();
           
            //check if isAimingAtTarget instead
            if(isOnTarget(target))
            {
                ChangeState(AiStates.Attack);
            }    
            if(!isOnTarget(target) && !isCanSee(target) && timeSpentInState > aiMemory)
            {
                ChangeState(AiStates.Idle);
            }
            break;
        }
       
         switch (currentState)
        {
            case AiStates.Attack:
            Debug.Log("Attacking");
            DoAttackState();
            if(!isOnTarget(target) && isCanSee(target))
            {
                ChangeState(AiStates.Turn);
            }    
            if(!isOnTarget(target) && !isCanSee(target))
            {
                ChangeState(AiStates.Idle);
            }   
            break;
        }
        

    }
}
