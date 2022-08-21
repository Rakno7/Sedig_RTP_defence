using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   public float hitAnimCoolDown = 5;
    private bool ishit;
    public float maxHealth;
    private playerUI playerUI;
    [HideInInspector]
    public float currentHealth;
    
    void Start()
    { 
        currentHealth = maxHealth;
        if(GetComponent<Pawn>().controller.GetComponent<PlayerController>())
        {playerUI = GetComponent<Pawn>().controller.GetComponent<PlayerController>().GetComponentInChildren<playerUI>();}
    }

    public void RestoreHealth(float amount, Pawn pawn)
    {
        
      currentHealth += amount;
      currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
      //Set UI
      if(playerUI != null)
      {
        float percentage = currentHealth / maxHealth * 100;
        playerUI.SetHealthUI(percentage);
      }
    }
    public void ReduceHealth(float amount, Pawn pawn)
    {
      if(GetComponent<HumanPawn>() && !ishit)
        {
          if(GetComponent<Pawn>().controller.anim !=null)
          {
          GetComponent<Pawn>().controller.anim.SetBool("isHit",true);
          Invoke("HitCooldown", hitAnimCoolDown);
          
          ishit = true;
          }
        }
      currentHealth -= amount;
      currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
      //Set UI
      if(playerUI != null)
      {
        float percentage = currentHealth / maxHealth * 100;
        playerUI.SetHealthUI(percentage);
      }
      if(currentHealth <= 0)
      {
        Die();
      }
    }
    public void Die()
    {
        Pawn pawn = GetComponent<Pawn>();
        if(pawn.GetComponent<HumanPawn>())
        {
          if(GetComponent<Pawn>().controller.anim !=null)
          {
          HumanPawn Humanpawn = pawn.GetComponent<HumanPawn>();
          
          //Set Ragdoll
          Humanpawn.GetComponentInChildren<Animator>().enabled = false;
          Humanpawn.setColliderRagdollState(true);
          Humanpawn.setRigidbodyRagdollState(false);
          //Gameover
             if(pawn.controller.GetComponent<PlayerController>())
             {
               GameManager.instance.gameStates.PrepGameover();
             }
          }
          AiController ai = pawn.controller.GetComponent<AiController>();
          if(ai != null)
          {
            if(ai.aiPath !=null)
            {
             ai.aiDestination.enabled = false;
             ai.aiPath.canMove = false;
            }
          }
        }
        if(pawn.controller.GetComponent<ZombieFSM>())
        {
          
         GameManager.instance.enemyControllers.Remove(pawn.controller.GetComponent<ZombieFSM>());
         MeleeAttacker[] attacker = pawn.GetComponentsInChildren<MeleeAttacker>();
         foreach(MeleeAttacker A in attacker)
         {
          A.gameObject.GetComponent<Collider>().enabled = false;
          A.enabled=false;
         }
        }
        else
        {
          AllyReference ally = GetComponent<AllyReference>();
          ally.enabled = false;
          GameManager.instance.FriendlyControllers.Remove(pawn.controller.GetComponent<Controller>());
        }
        if(pawn.controller.GetComponent<TurretFSM>())
        {
         GameManager.instance.FriendlyControllers.Remove(pawn.controller.GetComponent<TurretFSM>());
         Destroy(gameObject);
        }
        pawn.attacker.enabled = false;
        pawn.controller.enabled = false;
        pawn.enabled = false;
        

        
        
       
    }
    public void HitCooldown()
    {
      ishit = false;
      hitAnimCoolDown = Random.Range(1,5);
    }
}
