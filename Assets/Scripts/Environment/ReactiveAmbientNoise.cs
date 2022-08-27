using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveAmbientNoise : MonoBehaviour
{
    public AudioSource ambientSound;
    public AudioSource alertSound;
    public GameObject monster;
    public GameObject character;
    public float volumeRatio;
    public float desiredDistance;
    public float alertDistance;

    // Start is called before the first frame update
    void Start()
    {
       alertSound.volume = 0; 
    }

    private void OnEnable() {
        alertSound.volume = 0; 
        alertSound.Play();
        monster = GameObject.Find("Monster(Clone)");
    }

    private void OnDisable() {
        alertSound.volume = 0;
        alertSound.Stop();
        ambientSound.Play();
        
        monster = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(monster == null){
            monster = GameObject.Find("Monster(Clone)");
        }
        if(Vector3.Distance(monster.transform.position, character.transform.position) <= desiredDistance){
            volumeRatio = (Vector3.Distance(monster.transform.position, character.transform.position) - 8) / (desiredDistance - 8);
            if(volumeRatio >= 0){
                alertSound.volume = 0;
                //Debug.Log(volumeRatio);
                ambientSound.volume = volumeRatio;
            }else{
                ambientSound.volume = 0;
                volumeRatio = Vector3.Distance(monster.transform.position, character.transform.position) / 8;
                alertSound.volume = 1 - volumeRatio;
            }
        }else{
            ambientSound.volume = 1;
        }
    }
}
