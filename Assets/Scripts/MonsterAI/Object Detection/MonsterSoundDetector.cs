using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class MonsterSoundDetector : MonoBehaviour
{
    public BehaviorTree behaviorTree;
    public string[] tagList;
    private string currentTargetTag;
    // private Vector3 m_Target;
    // public Vector3 Target { get { return m_Target; } set { m_Target = value; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSoundPriority(string tag, Vector3 soundPosition){
        //Debug.Log(tag + " " + soundPosition);
        int newTagIndex = 5;
        int oldTagIndex = 5;
        for(int i = 0; i < 3; i++){
            if(tagList[i] == tag){
                newTagIndex = i;
            }
            if(tagList[i] == currentTargetTag){
                oldTagIndex = i;
            }
        }
        if(newTagIndex <= oldTagIndex){
            currentTargetTag = tag;
            var Target = (SharedVector3)behaviorTree.GetVariable("Target");
            Target.Value = soundPosition;
        }
    }

    public void ChangePlayerTagToIdle(){
        currentTargetTag = "PlayerIdle";
    }
}
