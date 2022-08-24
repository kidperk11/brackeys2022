using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Rigidbody rb;
    public SphereCollider coll;
    public bool equipped;
    public static bool slotFull;
    public Transform player, pickupPoint;
    public float pickUpRange;

    public Vector3 positionOffset;
    public Quaternion rotateOffset;

    public void PickupItem(Transform pickupPoint, string itemType)
    {
        switch (itemType.ToString())
        {
            case "Hold":
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
                break;
            case "Inspect":
                equipped = true;
                slotFull = true;

                //Make weapon a child of the camera and move it to default position
                transform.SetParent(pickupPoint);
                transform.localPosition = Vector3.zero;
                transform.localPosition = positionOffset;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                transform.localRotation = rotateOffset;


                //Make Rigidbody kinematic and BoxCollider a trigger
                rb.isKinematic = true;
                break;
        }
    }

    public void Drop(string itemType)
    {
        switch (itemType.ToString()) {
            case "Hold":
                equipped = false;
                slotFull = false;

                //Set parent to null
                transform.SetParent(null);

                //Make Rigidbody not kinematic and BoxCollider normal
                rb.isKinematic = false;
                coll.isTrigger = false;
                break;
            case "Inspect":
                equipped = false;
                slotFull = false;

                //Set parent to null
                transform.SetParent(null);
                break;
        }

    }
}
