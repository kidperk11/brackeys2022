using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NWH;
using BoatControls;
using NWH.DWP2.ShipController;

namespace KinematicCharacterController
{
    public class MyPlayer : MonoBehaviour
    {
        [Header("DEBUG")]
        public bool enableMonster;
        public bool enablePlayer;

        [Header("Control System")]
        public ExampleCharacterCamera OrbitCamera;
        public Transform CameraFollowPoint;
        public MyCharacterController Character;
        public BoatControlsToggle boatControls;

        [Header("Monster Detection System")]
        public MonsterSoundDetector monsterSoundDetector;
        public GameObject character;
        public GameObject heldObject;

        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private bool m_ToggleBoat;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Tell camera to follow transform
            OrbitCamera.SetFollowTransform(CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
            OrbitCamera.IgnoredColliders.Clear();
            OrbitCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {
            if(monsterSoundDetector == null){
                monsterSoundDetector = FindObjectOfType<MonsterSoundDetector>();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            HandleCharacterInput();
        }

        private void LateUpdate()
        {
            HandleCameraInput();
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

            // Prevent moving the camera while the cursor isn't locked
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                lookInputVector = Vector3.zero;
            }

            // Input for zooming the camera (disabled in WebGL because it can cause problems)
            float scrollInput = -Input.GetAxis(MouseScrollInput);
#if UNITY_WEBGL
        scrollInput = 0f;
#endif

            // Apply inputs to the camera
            OrbitCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);

            // Handle toggling zoom level
            if (Input.GetMouseButtonDown(1))
            {
                OrbitCamera.TargetDistance = (OrbitCamera.TargetDistance == 0f) ? OrbitCamera.DefaultDistance : 0f;
            }
        }

        private void HandleCharacterInput()
        {
           
                PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

                // Build the CharacterInputs struct
                characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
                characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
                characterInputs.CameraRotation = OrbitCamera.Transform.rotation;
                characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
                characterInputs.JumpHeld = Input.GetKey(KeyCode.Space);
                characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.C);
                characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.C);
                characterInputs.CrouchHeld = Input.GetKey(KeyCode.C);
                characterInputs.InteractDown = Input.GetKeyDown(KeyCode.Mouse0);
                characterInputs.InteractUp = Input.GetKeyUp(KeyCode.Mouse0);
                characterInputs.SprintDown = Input.GetKeyDown(KeyCode.LeftShift);
                characterInputs.SprintUp = Input.GetKeyUp(KeyCode.LeftShift);



            if (enablePlayer)
            {
                // Apply inputs to character
                Character.SetInputs(ref characterInputs);
            }



            if (enableMonster)
            {
                if(monsterSoundDetector == null){
                    monsterSoundDetector = FindObjectOfType<MonsterSoundDetector>();
                } else {
                    //Monster Detection System
                    if (characterInputs.MoveAxisForward != 0)
                    {
                        if (!characterInputs.CrouchHeld)
                        {
                            monsterSoundDetector.CheckSoundPriority(this.gameObject.tag, character.transform.position);
                        }
                        else { monsterSoundDetector.ChangePlayerTagToIdle(); }

                    }
                    if (characterInputs.MoveAxisRight != 0)
                    {
                        if (!characterInputs.CrouchHeld)
                        {
                            monsterSoundDetector.CheckSoundPriority(this.gameObject.tag, character.transform.position);
                        }
                        else { monsterSoundDetector.ChangePlayerTagToIdle(); }
                    }
                    if (characterInputs.MoveAxisForward == 0 && characterInputs.MoveAxisRight == 0)
                    {
                        monsterSoundDetector.ChangePlayerTagToIdle();
                    }
                }
                
            }
        }
    }
}