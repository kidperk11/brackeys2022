using NWH.Common.Cameras;
using NWH.DWP2.ShipController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BoatControls
{
    public enum ControllableCameras // your custom enumeration
    {
        Boat,
        Player,
    };

    public class BoatControlsToggle : MonoBehaviour
    {

        public ControllableCameras gameLaunchController = new ControllableCameras();
        public GameObject boatCam;
        public GameObject boatControls;
        public GameObject playerCam;
        public GameObject playerControls;

        [Header("Boat Interaction")]
        public SphereCollider playerEnterRange;
        public TextMeshProUGUI interactWithBoatText;
        public ColliderTriggerRange IsPlayerInRange;

        [Header("Visual Debugger")]
        public bool isPlayerEnabled;
        public bool isBoatEnabled;

        private bool m_ToggleBoat;
        private ControllableCameras currentlyActiveCamera = new ControllableCameras();

        private void Start()
        {
            IsPlayerInRange.m_IsPlayerInRange = false;
            interactWithBoatText.enabled = false;

            switch (gameLaunchController.ToString())
            {
                case "Player":
                    interactWithBoatText.text = "Press 'O' to Enter Boat";
                    EnablePlayer();
                    DisableBoat();
                    currentlyActiveCamera = ControllableCameras.Player;
                    break;

                case "Boat":
                    interactWithBoatText.text = "Press 'O' to Exit Boat";
                    EnableBoat();
                    DisablePlayer();
                    currentlyActiveCamera = ControllableCameras.Boat;
                    break;
            }
        }

        private void Update()
        {
            m_ToggleBoat = Input.GetKeyDown(KeyCode.O);

            if (IsPlayerInRange.IsPlayerInRange)
            {
                interactWithBoatText.enabled = true;
                if (m_ToggleBoat)
                {
                    Toggle();
                }
            }
            else
            {
                interactWithBoatText.enabled = false;
            }
        }

        public void Toggle()
        {
            switch (currentlyActiveCamera.ToString())
            {
                case "Player":
                    interactWithBoatText.text = "Press 'O' to Exit Boat";
                    EnableBoat();
                    DisablePlayer();
                    currentlyActiveCamera = ControllableCameras.Boat;
                    break;
                case "Boat":
                    interactWithBoatText.text = "Press 'O' to Enter Boat";
                    EnablePlayer();
                    DisableBoat();
                    currentlyActiveCamera = ControllableCameras.Player;
                    break;
            }
        }

        private void DisableBoat()
        {
            isBoatEnabled = false;
            boatCam.SetActive(false);
            boatControls.SetActive(false);
        }

        private void EnableBoat()
        {

            isBoatEnabled = true;
            boatCam.SetActive(true);
            boatControls.SetActive(true);
        }

        private void DisablePlayer()
        {
            isPlayerEnabled = false;
            playerCam.SetActive(false);
            playerControls.SetActive(false);
        }

        private void EnablePlayer()
        {
            isPlayerEnabled = true;
            playerCam.SetActive(true);
            playerControls.SetActive(true);
        }
    }
}