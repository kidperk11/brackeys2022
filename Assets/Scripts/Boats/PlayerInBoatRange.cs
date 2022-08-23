using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatControls
{
    public class PlayerInBoatRange : MonoBehaviour
    {
        private BoatControlsToggle boatToggle;

        private void Start()
        {
            boatToggle = GetComponentInParent<BoatControlsToggle>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                boatToggle.playerInRangeBool = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                boatToggle.playerInRangeBool = false;
            }
        }
    }
}
