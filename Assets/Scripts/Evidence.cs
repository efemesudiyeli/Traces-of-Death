using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _outlineMaterial = null;
    [SerializeField] private EvidenceScriptableObject _evidenceScriptableObject;
    [SerializeField] private EvidenceManager _evidenceManager;
    [SerializeField] private UIManager _uiManager;
    private bool _isThisEvidenceCollected = false;
    private Outliner _outliner;

    private void Awake()
    {
        _outliner = new Outliner(GetComponent<MeshRenderer>(), _outlineMaterial);
    }

    public void Interact()
    {
        _uiManager.SetEvidenceInfo(_evidenceScriptableObject.evidenceInfo);
        _uiManager.ShowEvidencePanel();

        if (!_isThisEvidenceCollected)
        {
            _evidenceManager.AddEvidenceCount(1);
            _isThisEvidenceCollected = true;
        }

    }

    public void ActivateOutline()
    {
        _outliner.ActivateOutline();
    }

    public void DisableOutline()
    {
        _outliner.DisableOutline();
    }


}
