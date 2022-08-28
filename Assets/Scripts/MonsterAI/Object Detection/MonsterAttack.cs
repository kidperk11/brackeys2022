using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;

public class MonsterAttack : MonoBehaviour
{
    public MyCharacterController characterController;
    private void Start() {
        characterController = FindObjectOfType<MyCharacterController>();

    }

    private void Update() {
        if(characterController == null){
            characterController = FindObjectOfType<MyCharacterController>();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            characterController.Respawn();

        }
    }
}
