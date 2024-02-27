using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Workbench : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _outlineMaterial = null;
    [SerializeField] private UIManager _uiManager;
    private Outliner _outliner;

    [SerializeField] private CinemachineVirtualCamera _mainCamera, _workbenchCamera;
    [SerializeField] private Player _player;

    [Header("Workbench Info")]
    [SerializeField] private TextMeshProUGUI[] _caseNameTexts;
    [SerializeField] private TextMeshProUGUI[] _caseInfoTexts;
    [SerializeField] private Image[] _caseSprites;
    [SerializeField] private WorkbenchCasesScriptableObject _workbenchCasesSO;

    private bool _isPlayerCurrentlyOnWorkbench = false;

    private void Awake()
    {
        _outliner = new Outliner(GetComponent<MeshRenderer>(), _outlineMaterial);
    }

    public void Interact()
    {
        SwitchToWorkbenchCamera();
    }

    public void ActivateOutline()
    {
        if (!_isPlayerCurrentlyOnWorkbench)
        {
            _outliner.ActivateOutline();
        }
    }

    public void DisableOutline()
    {
        _outliner.DisableOutline();
    }

    public void SwitchToWorkbenchCamera()
    {
        if (!_isPlayerCurrentlyOnWorkbench)
        {
            _mainCamera.Priority = 10;
            _workbenchCamera.Priority = 11;
            _isPlayerCurrentlyOnWorkbench = true;
            DisableOutline();
        }
    }

    public void SwitchBackToMainCamera()
    {
        if (_isPlayerCurrentlyOnWorkbench)
        {
            _mainCamera.Priority = 11;
            _workbenchCamera.Priority = 10;
            _isPlayerCurrentlyOnWorkbench = false;
        }
    }
}
