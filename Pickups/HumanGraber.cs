using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGraber : Graber
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
  
      if(isHolding)
            if(GrabableObject == null)
            {
                isHolding = false;
            }
    }

    public override void Grab()
    {
        Invoke("DoGrab",0.1f);
    }
    public override void Drop()
    {
       Invoke("DoDrop",0.1f);
    }

    public override void DoGrab()
    {
      if(GrabableObject !=null)
       isHolding = true;
       GrabableObject.GetComponent<Rigidbody>().isKinematic = true;
       GrabableObject.transform.parent = GetComponent<Pawn>().holdPosition.transform;
       GrabableObject.transform.position = GetComponent<Pawn>().holdPosition.position;
       
       GrabableObject.GetComponent<Collider>().enabled = false;
    }
    public override void DoDrop()
    {
      if(GrabableObject !=null)
       isHolding = false;
       if(GrabableObject.transform.parent !=null)
       {
       GrabableObject.transform.parent = null;
       }
       GrabableObject.transform.position = GetComponent<Pawn>().holdPosition.position;
       GrabableObject.transform.rotation = GetComponent<Pawn>().transform.rotation;
       GrabableObject.GetComponent<Collider>().enabled = true;
       GrabableObject.GetComponent<Rigidbody>().isKinematic = false;
       
    }
}
