using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueAreaExit : MonoBehaviour
{
    public GameObject clueArea;
    public EncounterManager encounterManager;
    public PaperPickup paperPickup;
    public GameObject nextPaper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            encounterManager.DeactivateEncounter(clueArea, paperPickup);
            nextPaper.SetActive(true);           
        }
    }
}
