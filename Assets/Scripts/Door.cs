using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _outlineMaterial = null;
    [SerializeField] private bool _isDoorDisabled = true;
    [SerializeField] protected int _sceneBuildIndexToLoad = 0;
    private Outliner _outliner;

    private void Awake()
    {
        _outliner = new Outliner(GetComponent<MeshRenderer>(), _outlineMaterial);
    }

    public void ActivateOutline()
    {
        if (_isDoorDisabled) return;
        _outliner.ActivateOutline();
    }

    public void DisableOutline()
    {
        if (_isDoorDisabled) return;
        _outliner.DisableOutline();
    }

    public virtual void Interact()
    {
        if (_isDoorDisabled) return;
        SceneManager.LoadScene(_sceneBuildIndexToLoad);
    }
}
