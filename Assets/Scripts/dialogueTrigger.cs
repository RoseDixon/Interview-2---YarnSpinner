using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class dialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private playerMovement player;
    private NPCMovement orc;

    [YarnCommand("NPCJump")]
    public void NPCJump()
    {
        Debug.Log($"Orc is jumping!");
    }

    void Start()
    {
        player = FindObjectOfType<playerMovement>();
        orc = FindObjectOfType<NPCMovement>();
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueRunner.StartDialogue("Orc");
            player.canMove = false;
            orc.NPCcanMove = false;
        }
    }

    public void onDialogueComplete()
    {
        player.canMove = true;
        orc.NPCcanMove = true;
    }
}

