using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new(1, 1, 0, 0.75f);
        Gizmos.DrawSphere(transform.position, 2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
