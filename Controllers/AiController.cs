using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public abstract class AiController : Controller
{
    public enum AiStates
    {
       Idle,Patrol, Chase, Turn, Attack, ChooseWayPoint, Held , follow,Aim
    };
    public float timeSpentInState;
    public float aiMemory = 10;
    public AIPath aiPath;
    public AIDestinationSetter aiDestination;
    public AstarPath graph;
    public AiStates currentState;
    public AiStates commandState;
    public GameObject target;
    public GameObject AllyTarget;
    public float followRange;
    private GameObject hitObject;
    public float visionRange = 100;
    public float FOV = 90;
    public float onTargetFOV = 5;
    public bool isPathChosen = false;
    public GameObject EmptyWayPoint;
    public float AttackRange;

    public override void Start()
    { 
      transform.SetParent(GameManager.instance.SpawnedLevel.transform);
      graph = GameManager.instance.graph;
      if(pawn.gameObject.GetComponent<AIPath>())
       {
         aiPath = pawn.gameObject.GetComponent<AIPath>();
         aiDestination = pawn.gameObject.GetComponent<AIDestinationSetter>();
         transform.SetParent(GameManager.instance.SpawnedLevel.transform);
         base.Start();

       }
    }

    public abstract void MakeDecisions();

    protected void ChangeState (AiStates newState)
    {
       timeSpentInState = 0;
       currentState = newState;
       pawn.moveSpeed = 5;
       pawn.turnSpeed = 50;
    }

    protected void SetAnimations()
    {
      //Debug.Log("Magnitude:" + aiPath.velocity.magnitude);
      if(anim == null) return;
      if(aiPath.velocity.magnitude > 0.2f && aiPath.canMove)
        {
            anim.SetBool("isMoving", true);
        }
        if(aiPath.velocity.magnitude < 0.2f || !aiPath.canMove)
        {
            anim.SetBool("isMoving", false);
        }
        if(GetComponent<ZombieFSM>()) return;
        if(aiPath.velocity.magnitude > 1)
        {
            anim.SetBool("isRunning", true);
        }
        if(aiPath.velocity.magnitude < 1)
        {
            anim.SetBool("isRunning", false);
        }
    }
     //Helpers--------------------------------------------------------------------------------------------------------------
    protected virtual bool isDistanceLessThan(GameObject thisTarget , float distance)
    {
      if(Vector3.Distance (pawn.transform.position, thisTarget.transform.position) < AttackRange)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    protected virtual bool isCanSee(GameObject thisTarget)
    {
      if(target == null) {return false;}
      Vector3 pawnToTargetVector = target.transform.position - pawn.transform.position;
      float angleToTarget = Vector3.Angle(pawnToTargetVector,pawn.transform.forward);
      RaycastHit hit;

      if(Physics.Raycast(pawn.transform.position, pawnToTargetVector, out hit, visionRange))
      {hitObject = hit.transform.gameObject;}

      if(angleToTarget < FOV && hitObject == target)
      {return true;}
      else
      {return false;}
    }
    protected virtual bool isOnTarget(GameObject thisTarget)
    {
      if(target == null) {return false;}
      Vector3 pawnToTargetVector = target.transform.position - pawn.transform.position;
      float angleToTarget = Vector3.Angle(pawnToTargetVector,pawn.transform.forward);
      RaycastHit hit;

      if(Physics.Raycast(pawn.transform.position, pawnToTargetVector, out hit, visionRange))
      {hitObject = hit.transform.gameObject;}

      if(angleToTarget < onTargetFOV && hitObject == target)
      {return true;}
      else
      {return false;}
    }
     protected bool HasreachedWaypoint()
     {
        if(aiPath.reachedDestination)
      {
        return true;
      }
      else return false;
     }

    //Finders--------------------------------------------------------------------------------------------------------------
     protected GameObject findRandomWaypoint()
     {
        List <GameObject> points = GameManager.instance.wayPoints;

        return points[Random.Range(0,points.Count)];
        
     }
  
      protected void targetNearestPlayer()
      {
               AllyReference[] players = FindObjectsOfType<AllyReference>();
               GameObject closestPlayer = players[0].gameObject;
               float distanceToPlayer = Vector3.Distance(pawn.transform.position, closestPlayer.transform.position);
               foreach (AllyReference p in players)
               {
                  if(Vector3.Distance(pawn.transform.position, p.transform.position) <= distanceToPlayer)
                  {
                    closestPlayer = p.gameObject;
                    distanceToPlayer = Vector3.Distance(pawn.transform.position, closestPlayer.transform.position);
                  }
               }
             target = closestPlayer.gameObject;
      }
      protected void targetNearestAlly()
      {
        if(GameManager.instance != null)
        {
           List<PlayerController> players = GameManager.instance.playerControllers;
           if(players.Count < 0) return;

           PlayerController closestPlayer = players[0];
           float distanceToPlayer = Vector3.Distance(pawn.transform.position, closestPlayer.pawn.gameObject.transform.position);
           foreach (PlayerController p in players)
           {
            if(Vector3.Distance(pawn.transform.position, p.pawn.transform.position) <= distanceToPlayer)
            {
              closestPlayer = p;
              distanceToPlayer = Vector3.Distance(pawn.transform.position, closestPlayer.pawn.transform.position);
            }
           }
           AllyTarget = closestPlayer.pawn.gameObject;
        }
      }
      protected void targetNearestEnemy()
      {
        if(GameManager.instance != null)
        {
          List<AiController> enemies = GameManager.instance.enemyControllers;
          if(enemies.Count > 0)
          {
             AiController closestEnemy = enemies[0];
             float distanceToEnemy = Vector3.Distance(pawn.gameObject.transform.position, closestEnemy.pawn.gameObject.transform.position);
             foreach (AiController p in enemies)
            {
              if(Vector3.Distance(pawn.transform.position, p.pawn.transform.position) <= distanceToEnemy)
              {
                closestEnemy = p;
                distanceToEnemy = Vector3.Distance(pawn.transform.position, closestEnemy.pawn.transform.position);
              }
            }
             target = closestEnemy.pawn.gameObject;
          }
        }
      }
    //Doers----------------------------------------------------------------------------------------------------------------------------------------
      protected void DoChaseState()
      {
        if(GetComponent<SoldierFSM>())
        {
        anim.SetBool("isAiming", false);
        }
        anim.SetBool("isAttacking", false);
        
      }
      protected void DoIdleState()
      {
        if(GetComponent<SoldierFSM>())
        {
        anim.SetBool("isAiming", false);
        }
        anim.SetBool("isAttacking", false);
        aiDestination.target = null;
      }
      protected void DoAttackState()
      {
        if(anim != null)
        {
        anim.SetBool("isAttacking", true);
        //anim.SetBool("isAiming", true);
        }
        pawn.Attack();
      }
      protected void DoFollowState()
      { 
        anim.SetBool("isAiming", false);
        anim.SetBool("isAttacking", false);
        //TODO: Create an empty follow position behind the player
        aiDestination.target = AllyTarget.transform;
      }
      protected void DoTurnState()
      {
        Seek(target,false,true);
      }
      protected void DoAimState()
      {
        anim.SetBool("isAiming", true);
        anim.SetBool("isAttacking", false);
        Seek(target,false,true);
      }
      protected void DoChooseWayPointState()
      {
        if(GetComponent<SoldierFSM>())
        {
        anim.SetBool("isAiming", false);
        }
        anim.SetBool("isAttacking", false);
        Transform point = findRandomWaypoint().transform;
        if(aiDestination.target !=point)
        {
          aiDestination.target = point;
        } 
        else return;
      }
    
      protected void Seek(Vector3 targetPosition, bool canMove, bool canRotate)
      {
       // if(pawn !=null)
       // {
            if(canRotate)
            {
            pawn.RotateTowards(targetPosition);
            }
            if(canMove)
            {
            pawn.MoveForward();
            }
       // }
      }
      protected void Seek(Transform targetTransform,bool canMove, bool canRotate)
      {Seek(targetTransform.position, canMove, canRotate);}
      protected void Seek(GameObject targetGameobject, bool canMove,bool canRotate)
      {Seek(targetGameobject.transform, canMove,canRotate);}
      protected void Seek(Pawn targetPawn, bool canMove,bool canRotate)
      {Seek(targetPawn.transform, canMove,canRotate);}
      protected void Seek(Controller targetController, bool canMove,bool canRotate)
      {Seek(targetController.pawn, canMove, canRotate);}
      
      private void OnDrawGizmos()
      {

      }
      
}

