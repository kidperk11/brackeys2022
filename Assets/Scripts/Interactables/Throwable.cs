using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Pickup
{
    public bool hasBeenThrown;
    public bool hasMonsterSpeedModifier;
    public float monsterSpeedModifier;
    public Transform fpsCam;

    public float throwForwardForce, throwUpwardForce;

    public MonsterSoundDetector monsterSoundDetector;

    private void OnEnable() {
        monsterSoundDetector = FindObjectOfType<MonsterSoundDetector>();
    }

    private void Start()
    {
        fpsCam = GameObject.Find("Character Camera").GetComponent<Transform>();
        player = GameObject.Find("Character").GetComponent<Transform>();
        pickupPoint = GameObject.Find("PickupPosition").GetComponent<Transform>();
        //Setup
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        if(monsterSoundDetector == null){
            monsterSoundDetector = FindObjectOfType<MonsterSoundDetector>();
        }
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        
            PickupItem(pickupPoint, "Hold");
        

        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        
            Drop("Hold");
        

        //Throw if equipped and "Left Mouse" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Mouse0)) Throw();
    }

    private void Throw()
    {
        hasBeenThrown = true;
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //AddForce
        rb.AddForce(fpsCam.forward * throwForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * throwUpwardForce, ForceMode.Impulse);

        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && hasBeenThrown){
            monsterSoundDetector.CheckSoundPriority(tag, transform.position);
            hasBeenThrown = false;
        }
    }
}
