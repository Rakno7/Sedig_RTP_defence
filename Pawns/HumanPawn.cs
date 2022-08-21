using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPawn : Pawn
{
    
    public override void Start()
    {
      if(!controller.GetComponent<TurretFSM>())
      {
      setRigidbodyRagdollState(true);
      setColliderRagdollState(false);
      }
       base.Start(); 
    }
    public override void MoveForward()
    {
     if(mover == null)
     {
        Debug.LogWarning("No Mover in Humanpawn, add mover");
        return;
     }

     mover.Move(transform.forward,moveSpeed);
    }
    public override void MoveBackward()
    {
        if(mover == null)
     {
        Debug.LogWarning("No Mover in Humanpawn, add mover");
        return;
     }
     mover.Move(-transform.forward,moveSpeed);
    }
    public override void RotateLeft()
    {
        if(mover == null)
     {
        Debug.LogWarning("No Mover in Humanpawn, add mover");
        return;
     }
     mover.Rotate(-turnSpeed);
    }
    public override void RotateRight()
    {
        if(mover == null)
     {
        Debug.LogWarning("No Mover in Humanpawn, add mover");
        return;
     }
     mover.Rotate(turnSpeed);
    }
      public override void RotateTowards(Vector3 targetPosition)
    {
        if(mover == null)
     {
        Debug.LogWarning("No Mover in Humanpawn, add mover");
        return;
     }
      Vector3 vectorToTarget = targetPosition - transform.position;
      Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget,Vector3.up);
      transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,turnSpeed * Time.deltaTime);
    }
    
    public override void Attack()
    {
          if(attacker == null)
       {
          Debug.LogWarning("No Attacker in Humanpawn, add Attacker");
          return;
       }
       attacker.Attack();
    }
    public override void Grab()
    {
      if(graber.GrabableObject !=null)
      {
         graber.Grab();
      }
    }
    public override void Drop()
    {
      if(graber.GrabableObject !=null)
      {
         graber.Drop();
      }
    }

    public void setRigidbodyRagdollState(bool state)
    {
      
      Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
      if(rigidbodies ==null) return;
      foreach(Rigidbody rb in rigidbodies)
      {
         rb.mass = 0.2f;
         rb.isKinematic = state;
      }
      // whatever we do for the children, to the opposite for the parent
      if(GetComponent<Rigidbody>())
      {
      GetComponent<Rigidbody>().mass = 30f;
      GetComponent<Rigidbody>().isKinematic = !state;
      }
    }
    public void setColliderRagdollState(bool state)
    {
      Collider[] colliders = GetComponentsInChildren<Collider>();
      if(colliders ==null) return;
      foreach(Collider collider in colliders)
      {
         collider.enabled = state;
      }
      // whatever we do for the children, to the opposite for the parent
      if(GetComponent<Collider>())
      {  
      GetComponent<Collider>().enabled = !state;
      }
    }


   
}
