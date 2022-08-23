using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveAmbientNoise : MonoBehaviour
{
    public AudioSource sound;
    public GameObject monster;
    public GameObject character;
    public float volumeRatio;
    public float desiredDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(monster.transform.position, character.transform.position) <= desiredDistance){
            volumeRatio = (Vector3.Distance(monster.transform.position, character.transform.position) - 3) / (desiredDistance - 3);
            if(volumeRatio >= 0){
                Debug.Log(volumeRatio);
                sound.volume = volumeRatio;
            }else{
                sound.volume = 0;
            }
        }else{
            sound.volume = 1;
        }
    }
}
