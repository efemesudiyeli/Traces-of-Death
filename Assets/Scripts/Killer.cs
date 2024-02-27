using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Soul
{
    [SerializeField] private DialogueManager _dialogueManager;

    void Start()
    {
        _dialogueManager.OnDialogueEnded += () => { base.isSoulGatherable = true; };
    }


}
