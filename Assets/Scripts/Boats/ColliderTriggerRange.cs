using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ColliderTriggerRange : MonoBehaviour
{
    public bool IsPlayerInRange { 
        get { return m_IsPlayerInRange; } 
        set { m_IsPlayerInRange = value; } }

    public bool m_IsPlayerInRange;

    private SphereCollider sc;
    private void Awake()
    {
        sc = GetComponent<SphereCollider>();
        sc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsPlayerInRange = false;
        }
    }
}
