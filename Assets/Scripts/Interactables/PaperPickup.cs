using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperPickup : Pickup
{
    public TextMeshProUGUI interactWithObjectGUI;
    public ColliderTriggerRange isItemInRange;
    public GameObject paperMesh;
    public MeshCollider meshColl;

    private bool m_pickupItem;


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
            coll.enabled = true;
            meshColl.enabled = true;
            Rigidbody temp = gameObject.AddComponent<Rigidbody>();
            rb = temp;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        if(equipped)
        {
            transform.localRotation = rotateOffset;
        }
    }
}
