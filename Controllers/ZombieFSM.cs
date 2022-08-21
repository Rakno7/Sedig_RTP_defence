using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSM : AiController
{
   
    public override void Start()
    {
        GameManager.instance.enemyControllers.Add(this);
        base.Start();
        currentState = AiStates.ChooseWayPoint;
    }

    
    public void Update()
    {
       targetNearestPlayer();
       SetAnimations();
       MakeDecisions();
       
       
    }
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AiStates.ChooseWayPoint:  
           
            timeSpentInState += Time.deltaTime;
            targetNearestPlayer();
            DoChooseWayPointState();       
            ChangeState(AiStates.Patrol); 
            break;
        }
        switch (currentState)
        {
            case AiStates.Patrol:
            timeSpentInState += Time.deltaTime;
           
            targetNearestPlayer();
            if(HasreachedWaypoint())
            {
              ChangeState(AiStates.ChooseWayPoint);
            }   
            if(isCanSee(target))
            {
                ChangeState(AiStates.Chase);
            }     
            break;
        }
       
         switch (currentState)
        {
            case AiStates.Chase:
            targetNearestPlayer();
            aiDestination.target = target.transform;
            DoChaseState();
            
            if(!isCanSee(target))
            {
               timeSpentInState += Time.deltaTime;
            }
            if(isCanSee(target))
            {
                timeSpentInState = 0;
            }
            if(timeSpentInState > aiMemory)
            {
                ChangeState(AiStates.ChooseWayPoint);
            }
            if(isCanSee(target) && isDistanceLessThan(target,AttackRange))
            {
                ChangeState(AiStates.Attack);
            }
            break;
        }
         switch (currentState)
        {
            case AiStates.Attack:
            targetNearestPlayer();
            aiDestination.target = target.transform;
            DoAttackState();
            if(!isDistanceLessThan(target,AttackRange) || !isCanSee(target))
            {
                ChangeState(AiStates.Chase);
            }
           
            break;
        }
    }
}
