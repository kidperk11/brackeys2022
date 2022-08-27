using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;

public class FootSteps : MonoBehaviour
{
    //[SerializeField] private List<AudioClip> m_FootstepSounds = new List<AudioClip>();

    [SerializeField] [Range(0f, 1f)] private float m_RunStepLengthen;
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    [SerializeField] private AudioClip m_JumpSound;
    [SerializeField] private AudioClip m_LandSound;

    private KinematicCharacterMotor playerMotor;
    private MyCharacterController characterController;

    private Vector2 m_Input;
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_PreviouslyGrounded;
    private AudioSource m_AudioSource;
    

    private void Awake()
    {
        playerMotor = GetComponent<KinematicCharacterMotor>();
        characterController = GetComponent<MyCharacterController>();
    }

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!m_PreviouslyGrounded && playerMotor.GroundingStatus.IsStableOnGround)
        {
            PlayLandingSound();
        }

        m_PreviouslyGrounded = playerMotor.GroundingStatus.IsStableOnGround;
    }

    private void FixedUpdate()
    {
        float speed = characterController.IsWalking ? characterController.MaxStableMoveSpeed 
            : characterController.MaxStableMoveSpeed * characterController.sprintSpeedModifier;

        if (playerMotor.GroundingStatus.IsStableOnGround)
        {
            if (characterController._jumpConsumed)
            {
                PlayJumpSound();
            }
        }

        ProgressStepCycle(speed);
    }


    private void PlayLandingSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
        m_NextStep = m_StepCycle + .5f;
    }

    private void PlayJumpSound()
    {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }


    private void ProgressStepCycle(float speed)
    {

        if (characterController.PlayerVelocity.sqrMagnitude > 0 
            && (characterController.PlayerVelocity.x != 0 || characterController.PlayerVelocity.y != 0))
        {
            m_StepCycle += (characterController.PlayerVelocity.magnitude + (speed * (characterController.IsWalking ? 1f : m_RunStepLengthen))) *
             Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!playerMotor.GroundingStatus.IsStableOnGround)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;

    }
}