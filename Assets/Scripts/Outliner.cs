using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner
{
    [SerializeField] private Material _outlineMaterial = null;
    private MeshRenderer _meshRenderer = null;
    private readonly List<Material> _currentMaterialsList = new List<Material>();
    private readonly List<Material> _originalMaterialsList = new List<Material>();
    private bool _isOutlineActivated = false;

    public Outliner(MeshRenderer meshRenderer, Material outlineMaterial)
    {
        this._meshRenderer = meshRenderer;
        this._outlineMaterial = outlineMaterial;
        _meshRenderer.GetMaterials(_originalMaterialsList);
    }

    public void ActivateOutline()
    {
        if (!_isOutlineActivated)
        {
            _meshRenderer.GetMaterials(_currentMaterialsList);
            _currentMaterialsList.Insert(0, _outlineMaterial);
            _meshRenderer.SetMaterials(_currentMaterialsList);
            _isOutlineActivated = true;
        }
    }

    public void DisableOutline()
    {
        if (_isOutlineActivated)
        {
            _meshRenderer.SetMaterials(_originalMaterialsList);
            _isOutlineActivated = false;
        }
    }
}
