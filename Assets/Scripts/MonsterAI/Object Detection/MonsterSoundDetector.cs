using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSoundDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSoundPriority(string tag, Vector3 soundPosition){
        Debug.Log(tag + " " + soundPosition);
    }
}
