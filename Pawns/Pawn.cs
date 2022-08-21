using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    public Mover mover;
    public Attacker attacker;
    public Graber graber;
    public Transform holdPosition;


    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public float IdleTurnSpeed;
    public float MovementTurnSpeed;
     public float AimingTurnSpeed;
    public float attackSpeed;
    [HideInInspector]
    public float moveSpeed = 5;
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        graber = GetComponent<Graber>();
        attacker = GetComponentInChildren<Attacker>();
    }
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateLeft();
    public abstract void RotateRight();
    public abstract void RotateTowards(Vector3 targetPosition);
    public abstract void Attack();
    public abstract void Grab();
    public abstract void Drop();
  
}
