using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCrimeScene : Door
{
    [SerializeField] private Soul _soul;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private DialogueScriptableObject _repetitiveDialogueSO;
    [SerializeField] private EvidenceManager _evidenceManager;

    [SerializeField] private GameStateManager.GameState _gameStateToSwitch;


    public override void Interact()
    {
        if (_soul.isSoulGathered && _evidenceManager != null && _evidenceManager.CheckAllEvidencesCollected())
        {
            GameStateManager.Instance.ChangeCaseState(_gameStateToSwitch);
            SceneManager.LoadScene(_sceneBuildIndexToLoad);
        }
        else if (_soul.isSoulGathered && _evidenceManager == null)
        {
            GameStateManager.Instance.ChangeCaseState(_gameStateToSwitch);
            SceneManager.LoadScene(_sceneBuildIndexToLoad);
        }
        else
        {
            _dialogueManager.StartDialogue(1, _repetitiveDialogueSO);

        }
    }
}
