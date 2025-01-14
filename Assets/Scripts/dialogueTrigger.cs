using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class dialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private playerMovement player;
    private NPCMovement orc;
    [YarnCommand("camera_look")]

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

    public void Awake()
    {
        dialogueRunner.AddCommandHandler<GameObject>("camera_look", CameraLookAtTarget);
    }

    private void CameraLookAtTarget(GameObject Target)
    {
       
        Camera.main.transform.LookAt(Target.transform);
        
    }

    public void onDialogueComplete()
    {
        player.canMove = true;
        orc.NPCcanMove = true;
    }
}

