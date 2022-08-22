using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public bool hasBeenThrown;
    public bool hasMonsterSpeedModifier;
    public float monsterSpeedModifier;

    public Rigidbody rb;
    public SphereCollider coll;
    public Transform player, pickupPoint, fpsCam;

    public float pickUpRange;
    public float throwForwardForce, throwUpwardForce;

    public bool equipped;
    public static bool slotFull;

    public MonsterSoundDetector monsterSoundDetector;
    private void Start()
    {
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
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Mouse0)) Throw();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(pickupPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;
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
