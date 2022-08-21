using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode MoveForwardKey;
    public KeyCode AimKey;
    public KeyCode AttackKey;
    public KeyCode MoveBackwardKey;
    public KeyCode RotateLeftKey;
    public KeyCode RotateRightKey;
    public KeyCode WalkKey;
    public KeyCode GrabKey;
    public KeyCode ReloadKey;
    private CameraRotationEffector cameraRotationState;
    public override void Start()
    {
        GameManager.instance.playerControllers.Add(this);
        GameManager.instance.FriendlyControllers.Add(this);
        pawn.turnSpeed = pawn.IdleTurnSpeed;
        cameraRotationState = GetComponentInChildren<CameraRotationEffector>();
        base.Start();
    }
    void Update()
    {
        ProcessInputs();
    }

    public override void ProcessInputs()
    {
         if(Input.GetKeyDown(ReloadKey) && pawn.attacker.GetComponent<GunAttacker>())
         {
           pawn.attacker.GetComponent<GunAttacker>().ReloadGun();
         }
         if(pawn.gameObject.GetComponent<Graber>().isHolding)
         {
          anim.SetBool("isCarrying", true);
         }
         if(!pawn.gameObject.GetComponent<Graber>().isHolding)
         {
          anim.SetBool("isCarrying", false);
         }
        if(Input.GetKey(MoveForwardKey) && !Input.GetKey(AimKey))
        {
          //cameraRotationState.SetRunRotation();
          cameraRotationState.SetAimRotation();
          pawn.turnSpeed = pawn.MovementTurnSpeed;
          anim.SetBool("isMoving", true);
          anim.SetBool("isRunning", true);
          pawn.MoveForward();
        }
        if(Input.GetKey(MoveBackwardKey)&& !Input.GetKey(AimKey))
        {
          pawn.turnSpeed = pawn.MovementTurnSpeed;
          anim.SetBool("isMovingBack", true);
          anim.SetBool("isRunning", false);
           pawn.moveSpeed = pawn.walkSpeed;
          pawn.MoveBackward();
        }
        if(!Input.GetKey(MoveBackwardKey))
        {
          anim.SetBool("isMovingBack", false);
        }
        if(!Input.GetKey(MoveForwardKey))
        {
          if(!Input.GetKey(AimKey))
          {
          cameraRotationState.SetIdleRotation();
          }
          anim.SetBool("isMoving", false);
          anim.SetBool("isRunning", false);
        }
        if(!Input.GetKey(MoveBackwardKey) && !Input.GetKey(MoveForwardKey) && !Input.GetKey(AimKey))
        {
          pawn.turnSpeed = pawn.IdleTurnSpeed;
        }
        if(Input.GetKey(RotateLeftKey))
        {
          anim.SetBool("isTurning", true);
          pawn.RotateLeft();
        }
        if(Input.GetKey(RotateRightKey))
        {
          anim.SetBool("isTurning", true);
          pawn.RotateRight(); 
        }
        if(!Input.GetKey(RotateRightKey) && !Input.GetKey(RotateLeftKey))
        {
          anim.SetBool("isTurning", false);
        }
        if(Input.GetKeyDown(GrabKey)
         && !pawn.gameObject.GetComponent<Graber>().isHolding)
        {
            pawn.Grab();
        }
        if(Input.GetKeyDown(GrabKey)
         && pawn.gameObject.GetComponent<Graber>().isHolding)
        {
           
           pawn.Drop();
        }
        if(Input.GetKey(WalkKey))
        {
          cameraRotationState.SetIdleRotation();
            anim.SetBool("isRunning", false);
            pawn.moveSpeed = pawn.walkSpeed;
        }
        else
        {
            pawn.moveSpeed = pawn.runSpeed;
        }
        if(Input.GetKey(AimKey))
        {
          cameraRotationState.SetAimRotation();
          pawn.turnSpeed = pawn.AimingTurnSpeed;
          anim.SetBool("isAiming", true);
          anim.SetBool("isMoving", false);
          anim.SetBool("isRunning", false);
          
        }
        else
        {
          anim.SetBool("isAiming", false);
        }
         if(Input.GetKey(AimKey) && Input.GetKey(AttackKey) && !pawn.attacker.isHasAttacked)
        {
          anim.SetBool("isAttacking", true);
          cameraRotationState.CamShake();
          pawn.Attack();
        }
    }
}
