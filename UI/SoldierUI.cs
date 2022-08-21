using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUI : MonoBehaviour
{
  public AiController soldierFSM;

 
  private void Update()
  {
    transform.rotation = Camera.main.transform.rotation;
  }
  public void EnterIdleState()
  {
    soldierFSM.currentState = AiController.AiStates.Idle;
    soldierFSM.commandState = AiController.AiStates.Idle;
  }
  public void EnterPatrolState()
  {
    soldierFSM.currentState = AiController.AiStates.ChooseWayPoint;
    soldierFSM.commandState = AiController.AiStates.ChooseWayPoint;
  }
  public void EnterFollowState()
  {
    soldierFSM.currentState = AiController.AiStates.follow;
    soldierFSM.commandState = AiController.AiStates.follow;
  }
}
