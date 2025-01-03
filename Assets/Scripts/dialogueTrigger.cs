using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class dialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private playerMovement player;

    void Start()
    {
        player = FindObjectOfType<playerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueRunner.StartDialogue("Orc");
            player.canMove = false;
        }

    }
}