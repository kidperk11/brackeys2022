using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public GameObject monster;
    public GameObject monsterPrefab;
    public ReactiveAmbientNoise ambientNoise;
    public GameObject currentClueArea;
    public PaperPickup currentPaperPickup;
    public Transform currentMonsterSpawn;
    // public List<Throwable> throwables = new List<Throwable>();
    // public List<ReactiveLightFlicker> reactiveLights = new List<ReactiveLightFlicker>();
    
    public void ActivateEncounter(GameObject clueArea, Transform monsterSpawn, PaperPickup paperPickup){
        currentClueArea = clueArea;
        currentPaperPickup = paperPickup;
        currentMonsterSpawn = monsterSpawn;
        Throwable[] throwables = clueArea.GetComponentsInChildren<Throwable>();
        foreach(Throwable child in throwables){
            child.enabled = true;
        }
        ReactiveLightFlicker[] reactiveLights = clueArea.GetComponentsInChildren<ReactiveLightFlicker>();
        foreach(ReactiveLightFlicker child in reactiveLights){
            child.enabled = true;
        }
        ambientNoise.enabled = true;
        Debug.Log("Instatiating Monster");
        monster = Instantiate(monsterPrefab, monsterSpawn.position, monsterSpawn.rotation);
        Debug.Log(monster.transform.position);
    }

    public void DeactivateEncounter(GameObject clueArea, PaperPickup paperPickup){
        Throwable[] throwables = clueArea.GetComponentsInChildren<Throwable>();
        foreach(Throwable child in throwables){
            child.enabled = false;
        }
        ReactiveLightFlicker[] reactiveLights = clueArea.GetComponentsInChildren<ReactiveLightFlicker>();
        foreach(ReactiveLightFlicker child in reactiveLights){
            child.enabled = false;
        }
        // MonsterTeleportTrigger[] teleportTriggers = clueArea.GetComponentsInChildren<MonsterTeleportTrigger>();
        // foreach(MonsterTeleportTrigger child in teleportTriggers){
        //     child.gameObject.SetActive(false);

        // }
        Destroy(monster);
        Destroy(paperPickup.gameObject);
        ambientNoise.enabled = false;
    }
    public void ResetEncounter(){
        
        // MonsterTeleportTrigger[] teleportTriggers = clueArea.GetComponentsInChildren<MonsterTeleportTrigger>();
        // foreach(MonsterTeleportTrigger child in teleportTriggers){
        //     child.gameObject.SetActive(false);

        // }
        monster.transform.position = currentMonsterSpawn.position;
        monster.GetComponentInChildren<MonsterSoundDetector>().CheckSoundPriority("Player", currentMonsterSpawn.position);
    }
}
