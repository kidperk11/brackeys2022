using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoints : MonoBehaviour
{
    public GameObject[] respawnPoints;

    public GameObject FindClosest()
    {
        return respawnPoints[0];
    }    
}
