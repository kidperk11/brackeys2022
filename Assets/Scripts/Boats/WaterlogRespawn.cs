using NWH.DWP2.WaterObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterlogRespawn : MonoBehaviour
{
    public WaterObject waterCheck;
    public float timeToRespawn = 2f;
    public RespawnPoints respawnPoints;
    public GameObject boat;


    private Vector3 respawnTransform;
    private Quaternion respawnRotation;
    private GameObject respawnPoint;
    private bool needToRespawn = false;

    private void Update()
    {
        if (!waterCheck.IsTouchingWater())
        {
            needToRespawn = true;
            StartCoroutine(TimeWaterLogged());
        }
        else
        {
            needToRespawn = false;
        }
    }

    private IEnumerator TimeWaterLogged()
    {
        while(needToRespawn)
        {
            yield return new WaitForSeconds(timeToRespawn);
            Respawn();
            needToRespawn = false;
        }
    }

    private void Respawn()
    {
        respawnPoint = respawnPoints.FindClosest();
        respawnTransform = respawnPoint.transform.position;
        respawnRotation = respawnPoint.transform.rotation;

        gameObject.transform.position = respawnPoint.transform.position;
        gameObject.transform.rotation = respawnPoint.transform.rotation;
        print("Respawning");
        print(needToRespawn);
        needToRespawn = false;
    }
}
