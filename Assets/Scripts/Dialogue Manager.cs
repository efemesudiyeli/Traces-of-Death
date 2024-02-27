using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private DialogueScriptableObject _currentDialogueSO;
    [SerializeField] private DialogueScriptableObject _defaultScriptableObject;
    [SerializeField] private Player _player;

    [SerializeField] private AudioClip _typeFX;
    private AudioSource _audioSource;

    private int _dialogueIndex;
    private int _dialogueLineIndex = 0;
    private bool _isDialogueActive = false;

    public event Action OnDialogueEnded;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(int dialogueIndex)
    {
        if (_isDialogueActive) return;
        _currentDialogueSO = _defaultScriptableObject;
        this._dialogueIndex = dialogueIndex;
        _isDialogueActive = true;
        _player.DisableMovement();
        SetDialogueUI();
        PlayOneShotTypeFX();
    }

    public void StartDialogue(int dialogueIndex, DialogueScriptableObject optionalScriptableObject)
    {
        if (_isDialogueActive) return;

        _currentDialogueSO = optionalScriptableObject;
        this._dialogueIndex = dialogueIndex;
        _isDialogueActive = true;
        _player.DisableMovement();
        SetDialogueUI();
        PlayOneShotTypeFX();
    }

    private void SetDialogueUI()
    {
        _uiManager.SetDialogueLine(
                _currentDialogueSO.dialogueLines[_dialogueIndex].lines[_dialogueLineIndex].person,
               _currentDialogueSO.dialogueLines[_dialogueIndex].lines[_dialogueLineIndex].line);
        _uiManager.ShowDialoguePanel();
    }

    public void EndDialogue()
    {
        if (!_isDialogueActive) return;

        _uiManager.HideDialoguePanel();
        _isDialogueActive = false;
        _dialogueLineIndex = 0;
        _player.EnableMovement();
        OnDialogueEnded?.Invoke();

    }

    public void NextLine()
    {
        if (_dialogueLineIndex - (_currentDialogueSO.dialogueLines[_dialogueIndex].lines.Length - 1) == 0)
        {
            EndDialogue();
            return;
        }

        _dialogueLineIndex++;
        PlayOneShotTypeFX();
        _uiManager.SetDialogueLine(_currentDialogueSO.dialogueLines[_dialogueIndex].lines[_dialogueLineIndex].person, _currentDialogueSO.dialogueLines[_dialogueIndex].lines[_dialogueLineIndex].line);
    }

    public void SetDialogueIndex(int newDialogueIndex)
    {
        _dialogueIndex = newDialogueIndex;
    }

    private void PlayOneShotTypeFX()
    {
        _audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        _audioSource.PlayOneShot(_typeFX);
    }
}
