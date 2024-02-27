using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private int dialogueIndex;
    [SerializeField] private DialogueScriptableObject _optionalDialogueScriptableObject;
    [SerializeField] private bool _startOnAwake = false;
    [SerializeField] private bool _startOnTriggerEnter = false;

    private void Start()
    {
        if (_startOnAwake)
        {
            _dialogueManager.StartDialogue(dialogueIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (_startOnTriggerEnter && other.TryGetComponent(out Player player))
        {
            _dialogueManager.StartDialogue(dialogueIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_startOnTriggerEnter && other.TryGetComponent(out Player player))
        {
            Destroy(this.gameObject);
        }
    }
}
