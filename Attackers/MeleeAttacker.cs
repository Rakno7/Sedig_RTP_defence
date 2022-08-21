using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : Attacker
{
   public Color raycolor;
   private RaycastHit Hit;
   public AudioPlayer audioPlayer;
  
   public override void Start()
   {
      audioPlayer = GetComponentInParent<AudioPlayer>();
      GetComponent<Collider>().enabled = true;
   }
   public override void Attack()
   {
    GetComponent<Collider>().enabled = true;
    
   }
   public override void Cooldown()
   {
      isHasAttacked = false;
   }
    //fuck it Im using collider triggers on the hands instead!
    
   
    private void OnTriggerEnter(Collider other)
    {
       if(other.isTrigger)return;
       if(other.GetComponent<Health>() && other.GetComponent<Health>() != pawn.GetComponent<Health>())
       {
         if(other.GetComponentInParent<Controller>())
         {
            if(other.GetComponentInParent<Controller>() != other.GetComponentInParent<ZombieFSM>())
            {
              audioPlayer.PlayBulletImpactFlesh();
              Instantiate(EnemyImpactParticlePrefab, transform.position,transform.rotation);
              Health health = other.GetComponent<Health>();
              health.ReduceHealth(attackDamage,GetComponentInParent<Pawn>());
            }
         }
       }
    }

  
}
