using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class NavMeshMoveTowards : Action
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    // [SerializeField] private Vector3 target;
    public SharedVector3 target;
    private NavMeshAgent navMeshAgent;

    public override void OnAwake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public override void OnStart(){
        if(navMeshAgent == null){return;}
        if(target == null){return;}
    }
    public override TaskStatus OnUpdate()
    {
        navMeshAgent.SetDestination(target.Value);
        if(navMeshAgent == null){return TaskStatus.Failure;}
        if(target == null){return TaskStatus.Failure;}
        if(!navMeshAgent.pathPending){
            if(!navMeshAgent.isOnOffMeshLink){
                if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
                    target.Value = new Vector3(0,0,0);
                    return TaskStatus.Success;
                }
            }
        }
        return TaskStatus.Running;
        // // Return a task status of success once we've reached the target
        // if (Vector3.SqrMagnitude(transform.position - target.Value.position) < 0.1f) {
        //     return TaskStatus.Success;
        // }
        
        // // We haven't reached the target yet so keep moving towards it
        // transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        // return TaskStatus.Running;
    }
}
