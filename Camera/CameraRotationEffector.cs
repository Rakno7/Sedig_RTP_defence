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

    

     public void SetIdleRotation()
     {
          Quaternion DesiredRotation = Quaternion.Euler (idleRotation,0,0);
          transform.localRotation = DesiredRotation;
     }
     public void SetRunRotation()
     {
          Quaternion DesiredRotation = Quaternion.Euler (movementRotation,0,0);
          transform.localRotation = DesiredRotation;
     }
      public void SetAimRotation()
     {
          Quaternion DesiredRotation = Quaternion.Euler (aimRotation,0,0);
          transform.localRotation = DesiredRotation;
     }
}
