using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFSM : AiController
{
    public bool isWound;
    public override void Start()
    {
        
        GameManager.instance.FriendlyControllers.Add(this);
        base.Start();
        anim.SetBool("isWounded",true);
        currentState = AiStates.Idle;
        isWound = true;
        
    }

    
    public void Update()
    {
       SetAnimations();
       MakeDecisions();
    }
    public override void MakeDecisions()
    {
        
        switch (currentState)
        {
            case AiStates.Idle:
            if(isWound) return; 
            DoIdleState(); 
            targetNearestAlly();
            targetNearestEnemy();
            timeSpentInState += Time.deltaTime;
             if(isCanSee(target) && isDistanceLessThan(target,visionRange))
            {
                ChangeState(AiStates.Aim);
            }     
            break;
        }
        switch (currentState)
        {
            case AiStates.ChooseWayPoint:
            if(isWound) return;   
            timeSpentInState += Time.deltaTime;
            DoChooseWayPointState();       
            ChangeState(AiStates.Patrol); 
            break;
        }
        switch (currentState)
        {
            case AiStates.follow:
            if(isWound) return; 
            aiPath.canMove = true;
            targetNearestEnemy();  
            DoFollowState();
            timeSpentInState += Time.deltaTime;
             if(isCanSee(target) && isDistanceLessThan(AllyTarget,followRange) && isDistanceLessThan(target,visionRange))
            {
                ChangeState(AiStates.Aim);
            }     
            
            break;
        }
        switch (currentState)
        {
            case AiStates.Patrol:
            if(isWound) return; 
            aiPath.canMove = true;
            timeSpentInState += Time.deltaTime;
            Debug.Log("Patrolling");
            targetNearestEnemy();
            if(HasreachedWaypoint())
            {
              ChangeState(AiStates.ChooseWayPoint);
            }   
            if(isCanSee(target))
            {
                ChangeState(AiStates.Aim);
            }     
            break;
        }
       
         switch (currentState)
        {
            case AiStates.Chase:
            if(isWound) return; 
            DoChaseState();
            targetNearestEnemy();
            Debug.Log("Chasing");
            if(!isCanSee(target))
            {
               timeSpentInState += Time.deltaTime;
            }
            if(timeSpentInState > aiMemory)
            {
                ChangeState(AiStates.ChooseWayPoint);
            }
            break;
        }
        switch (currentState)
        {
            case AiStates.Aim:
            if(isWound) return; 
            aiPath.canMove = false;
            DoAimState();
            targetNearestEnemy();
            targetNearestAlly();
            aiDestination.target = target.transform;
            if(!isDistanceLessThan(AllyTarget,followRange) && commandState == AiStates.follow)
            {
                ChangeState(AiStates.follow);
            }
            if(isOnTarget(target) && isCanSee(target) && isDistanceLessThan(target,AttackRange) && commandState != AiStates.follow)
            {
                ChangeState(AiStates.Attack);
            }
            if(isOnTarget(target) && isDistanceLessThan(AllyTarget,followRange) && isCanSee(target) && isDistanceLessThan(target,AttackRange) && commandState == AiStates.follow)
            {
                ChangeState(AiStates.Attack);
            }
            


            if(!isOnTarget(target) && !isCanSee(target) && commandState == AiStates.Idle)
            {
                ChangeState(AiStates.Idle);
            }
             if(!isOnTarget(target) && !isCanSee(target) && commandState == AiStates.Patrol)
            {
                ChangeState(AiStates.Patrol);
            }
              if(!isOnTarget(target) && !isCanSee(target) && commandState == AiStates.follow)
            {
                ChangeState(AiStates.follow);
            }
            break;
        }
         switch (currentState)
        {
            case AiStates.Attack:
            if(isWound) return; 
            aiPath.canMove = false;
            DoAttackState();
            targetNearestEnemy();
            targetNearestAlly();
            aiDestination.target = target.transform;
            if(!isOnTarget(target) && isCanSee(target) && !isDistanceLessThan(target,AttackRange))
            {
                ChangeState(AiStates.Aim);
            }
            if(!isOnTarget(target) && isCanSee(target) && commandState != AiStates.follow)
            {
                ChangeState(AiStates.Aim);
            }
            if(!isOnTarget(target) && isCanSee(target) && isDistanceLessThan(AllyTarget,followRange) && commandState == AiStates.follow)
            {
                ChangeState(AiStates.Aim);
            }
            if(!isOnTarget(target) && isCanSee(target) && !isDistanceLessThan(AllyTarget,followRange) && commandState == AiStates.follow)
            {
                ChangeState(AiStates.follow);
            }
            if(!isOnTarget(target) && !isCanSee(target) && commandState == AiStates.Idle)
            {
                ChangeState(AiStates.Idle);
            }
            if(!isOnTarget(target) && !isCanSee(target) && commandState == AiStates.Patrol)
            {
                ChangeState(AiStates.Patrol);
            }
            if(!isOnTarget(target) && !isCanSee(target) && commandState == AiStates.follow)
            {
                ChangeState(AiStates.follow);
            }
            Debug.Log("Attacking");
           
            break;
        }
        

    }
}
