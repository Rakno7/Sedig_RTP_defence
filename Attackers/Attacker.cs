using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
   public Controller controller;
   public Pawn pawn;
   public float attackDamage;
   public float cooldownLength;
   public GameObject firePoint;
   public GameObject AttackParticlePrefab;
   public GameObject EnemyImpactParticlePrefab;
   public GameObject WallImpactParticlePrefab;
   public float attackRange, attackRadius;
   [HideInInspector]
   public bool isHasAttacked = false;
   
   public virtual void Start()
   {
      controller = GetComponentInParent<Controller>();
      pawn = GetComponentInParent<Pawn>();
   }
   public abstract void Attack();
   public abstract void Cooldown();
 
}
