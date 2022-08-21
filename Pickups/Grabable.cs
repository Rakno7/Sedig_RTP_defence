using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HumanGraber>())
        {
            if(other.GetComponent<HumanGraber>().isHolding) return;
            HumanGraber humanGraber = other.GetComponent<HumanGraber>();
            humanGraber.GrabableObject = this.gameObject;
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<HumanGraber>())
        {
            if(other.GetComponent<HumanGraber>().isHolding) return;
            HumanGraber humanGraber = other.GetComponent<HumanGraber>();
            humanGraber.GrabableObject = null;
        }
    }
}
