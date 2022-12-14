using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public GameObject monster;
    public GameObject monsterPrefab;
    public ReactiveAmbientNoise ambientNoise;
    // public List<Throwable> throwables = new List<Throwable>();
    // public List<ReactiveLightFlicker> reactiveLights = new List<ReactiveLightFlicker>();
    
    public void ActivateEncounter(GameObject clueArea, Transform monsterSpawn){
        Throwable[] throwables = clueArea.GetComponentsInChildren<Throwable>();
        foreach(Throwable child in throwables){
            child.enabled = true;
        }
        ReactiveLightFlicker[] reactiveLights = clueArea.GetComponentsInChildren<ReactiveLightFlicker>();
        foreach(ReactiveLightFlicker child in reactiveLights){
            child.enabled = true;
        }
        ambientNoise.enabled = true;
        monster = Instantiate(monsterPrefab, monsterSpawn.position, monsterSpawn.rotation);   
    }

    public void DeactivateEncounter(GameObject clueArea, PaperPickup paperPickup){
        Throwable[] throwables = clueArea.GetComponentsInChildren<Throwable>();
        foreach(Throwable child in throwables){
            child.enabled = true;
        }
        ReactiveLightFlicker[] reactiveLights = clueArea.GetComponentsInChildren<ReactiveLightFlicker>();
        foreach(ReactiveLightFlicker child in reactiveLights){
            child.enabled = true;
        }
        Destroy(monster);
        paperPickup.enabled = false;
        ambientNoise.enabled = false;
    }
}
