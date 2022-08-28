using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveLightFlicker : MonoBehaviour
{
    public GameObject lighting;
    public GameObject monster;
    public float blinkRatio;
    public float blinkTimer;
    public float blinkDistance;
    public AudioSource soundEffect;

    private void OnEnable() {
        monster = GameObject.Find("Monster(Clone)");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(monster == null){
            monster = GameObject.Find("Monster(Clone)");
        }
        if(Vector3.Distance(monster.transform.position, transform.position) <= blinkDistance){
            blinkRatio = Vector3.Distance(monster.transform.position, transform.position) / blinkDistance;
        }else{
            blinkTimer = 0;
            blinkRatio = 0;
            lighting.SetActive(true);
        }
        blinkTimer-=Time.deltaTime;
        if(blinkTimer <= 0 && blinkRatio != 0){
            if(lighting.activeInHierarchy){
                lighting.SetActive(false);
                soundEffect.Stop();
            }else{
                lighting.SetActive(true);
                soundEffect.Play();
            }
            blinkTimer = blinkRatio;
        }
    }
}
