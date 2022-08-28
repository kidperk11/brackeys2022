using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;

public class ScriptedAudioSequence : MonoBehaviour
{
    public Animator anim;
    public AudioSource [] soundClips;
    private int index;
    public GameObject player;
    private bool soundPlaying;
    public GameObject walkie;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        player.GetComponentInChildren<MyPlayer>().EnablePlayer = false;
        //anim.SetTrigger("startWalkieTalkie");
        walkie.SetActive(true);
        soundClips[index].Play();
        soundPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!soundPlaying){
            index++;
            if(index == soundClips.Length){
            Debug.Log("End of Audio Sequence");
            //anim.SetTrigger("endWalkieTalkie");
            player.GetComponentInChildren<MyPlayer>().EnablePlayer = true;
            walkie.SetActive(false);
            this.gameObject.SetActive(false);
            
            }else{
                soundClips[index].Play();
                soundPlaying = true;
            }
        }

        if(!soundClips[index].isPlaying){
            soundPlaying = false;
            Debug.Log("Sound is no longer playing");
        }
    }
}
