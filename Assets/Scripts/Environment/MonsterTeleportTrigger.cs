using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTeleportTrigger : MonoBehaviour
{
    public Transform teleportLocation;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            GameObject monster = GameObject.Find("Monster(Clone)");
            MonsterSoundDetector monsterSoundDetector = monster.GetComponent<MonsterSoundDetector>();
            monster.transform.position = teleportLocation.position;
            monsterSoundDetector.CheckSoundPriority("Player", teleportLocation.position);
            this.gameObject.SetActive(false);
        }
    }
}
