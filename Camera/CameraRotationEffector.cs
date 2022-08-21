using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationEffector : MonoBehaviour
{    public Transform pawnTransform;
     public float idleRotation;
     public float movementRotation;
     public float aimRotation;
     [Range(0,1)]
     public float rotationSpeed;
     public Vector3 origionalPos;


     private void Start()
     {
       
     }

     public void SetIdleRotation()
     {    
          StopAllCoroutines();
          Quaternion DesiredRotation = Quaternion.Euler (idleRotation,0,0);
          transform.localRotation = DesiredRotation;
          //StartCoroutine(Idle(rotationSpeed, transform.localRotation.x));
     }
     public void SetRunRotation()
     {
          Quaternion DesiredRotation = Quaternion.Euler (movementRotation,0,0);
          transform.localRotation = DesiredRotation;
     }
      public void SetAimRotation()
     {  
             
             StartCoroutine(Aim(rotationSpeed, transform.localRotation.x));
     }

     public IEnumerator Aim(float speed, float previousRotation)
     {
          Quaternion DesiredRotation = Quaternion.Euler (aimRotation,0,0); 
          float currentRotation = previousRotation;
          while(currentRotation > aimRotation)
          {
               Debug.Log("looping aim");
               currentRotation -= speed; 
               transform.localRotation = Quaternion.Euler(currentRotation,0,0);  
               yield return null;  
          }
          transform.localRotation = DesiredRotation;
          
     }

      public IEnumerator Idle(float speed, float previousRotation)
     {
          Quaternion DesiredRotation = Quaternion.Euler (idleRotation,0,0); 
          float currentRotation = previousRotation;
          
          while(currentRotation < idleRotation)
          {
               Debug.Log("looping idle");
               currentRotation += speed; 
               transform.localRotation = Quaternion.Euler(currentRotation,0,0);  
               yield return null;  
          }
          transform.localRotation = DesiredRotation;
          
     }
     public void CamShake()
     {
        StartCoroutine(Shake(.05f, .1f));
     }
    
     public IEnumerator Shake (float duration, float magnitude)
     {
         origionalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f,+ 1f) * magnitude;
            float y = Random.Range(-1f,+ 1f) * magnitude;
    
            transform.localPosition = new Vector3 (x,y,origionalPos.z);
    
            elapsed += Time.deltaTime;
    
            yield return null;
        }
    
        transform.localPosition = origionalPos;
     }
}
