using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    private int _collectedEvidenceCount = 0;
    [SerializeField] private List<Evidence> _evidenceList;
    [SerializeField] private DialogueScriptableObject _repetitiveSO;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private UIManager _uiManager;

    public void AddEvidenceCount(int evidenceCount)
    {
        if (_collectedEvidenceCount + evidenceCount > _evidenceList.Count) return;
        _collectedEvidenceCount += evidenceCount;
        _uiManager.UpdateEvidenceCount(_collectedEvidenceCount);
        if (CheckAllEvidencesCollected())
        {
            _dialogueManager.StartDialogue(0, _repetitiveSO);
        };
    }

    public bool CheckAllEvidencesCollected()
    {
        if (_collectedEvidenceCount >= _evidenceList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
