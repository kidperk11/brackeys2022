using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatControls
{
    public class ColliderTriggerRange : MonoBehaviour
    {
        public bool IsPlayerInRange { 
            get { return m_IsPlayerInRange; } 
            set { m_IsPlayerInRange = value; } }

        public bool m_IsPlayerInRange;

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
}
