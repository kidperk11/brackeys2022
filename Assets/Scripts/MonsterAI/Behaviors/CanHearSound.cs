using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CanHearSound : Conditional
{
   public SharedVector3 target;

   // A cache of all of the possible targets
   private Transform[] possibleTargets;

   public override void OnAwake()
   {
      
   }

   public override TaskStatus OnUpdate()
   {
      if(target.Value != new Vector3(0,0,0)){
        return TaskStatus.Success;
      }
      else{
        return TaskStatus.Running;
      }
   }
}
