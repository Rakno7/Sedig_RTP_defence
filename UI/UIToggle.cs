using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    public GameObject uiCommands;
    public AiController ai;
    private void Start()
    {
        //ai.aiPath.whenCloseToDestination = Pathfinding.CloseToDestinationMode.ContinueToExactDestination;
        //ai.aiPath.whenCloseToDestination = Pathfinding.CloseToDestinationMode.Stop;

        uiCommands.SetActive(false);
    }

    public void ToggleCanvas()
    {
      //ai.aiPath.canMove = false;
      
      uiCommands.SetActive(true);
    }
     public void ToggleOffCanvas()
    {
       // ai.aiPath.canMove = true;
        uiCommands.SetActive(false);
    }
}
