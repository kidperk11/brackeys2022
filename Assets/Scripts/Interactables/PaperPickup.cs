using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KinematicCharacterController;

public class PaperPickup : Pickup
{
    public TextMeshProUGUI interactWithObjectGUI;
    public TextMeshProUGUI flipPaperGUI;
    public ColliderTriggerRange isItemInRange;
    public GameObject paperMesh;
    public MeshCollider meshColl;

    //Variables for interacting with the encounterManager
    public EncounterManager encounterManager;
    public GameObject clueArea;
    public GameObject clueAreaExit;
    public Transform monsterSpawn;

    private bool m_pickupItem;
    private bool flipped = false;


    private void Update()
    {
        m_pickupItem = Input.GetKeyDown(KeyCode.E);

        if (isItemInRange.IsPlayerInRange)
        {
            interactWithObjectGUI.enabled = true;
            if (m_pickupItem)
            {
                PickupItem(pickupPoint, "Inspect");
                Destroy(rb);
                coll.enabled = false;
                meshColl.enabled = false;
            }

        }
        else
        {
            interactWithObjectGUI.enabled = false;
        }

        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop("Inspect");
            player.GetComponentInChildren<MyPlayer>().EnablePlayer = true;
            interactWithObjectGUI.text = "Press 'E' to Pickup";
            coll.enabled = true;
            meshColl.enabled = true;
            Rigidbody temp = gameObject.AddComponent<Rigidbody>();
            rb = temp;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            encounterManager.ActivateEncounter(clueArea, monsterSpawn);
            clueAreaExit.SetActive(true);
        }

        if(equipped)
        {
            interactWithObjectGUI.text = "Press 'Q' to Drop";
            flipPaperGUI.enabled = true;
            player.GetComponentInChildren<MyPlayer>().EnablePlayer = false;

            if (Input.GetKeyDown(KeyCode.F))
            {
                if(!flipped)
                {
                    transform.localRotation = new Quaternion(0f, 0f, -070711f, -070711f);
                    print(transform.localRotation);
                    flipped = true;
                    print(flipped);
                }
                else
                {
                    transform.localRotation = new Quaternion(0.070711f, 0.070711f, 0f, 0f);
                    print(transform.localRotation);
                    flipped = false;
                    print(flipped);
                }
            }
            
        }
        else
        {
            flipPaperGUI.enabled = false;
            flipped = false;
        }
    }
}
