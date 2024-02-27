using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Soul : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _outlineMaterial = null;
    [SerializeField] public bool isSoulGathered = false;


    [SerializeField] private CinemachineVirtualCamera _mainCamera, _soulCamera;
    [SerializeField] private Player _player;
    public bool isSoulGatherable = true;

    [SerializeField] private AudioClip _gatherSoundFX;
    private AudioSource _audioSource;


    private Outliner _outliner;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _outliner = new Outliner(GetComponent<MeshRenderer>(), _outlineMaterial);
    }

    public void ActivateOutline()
    {
        if (isSoulGathered || !isSoulGatherable) return;
        _outliner.ActivateOutline();
    }

    public void DisableOutline()
    {
        _outliner.DisableOutline();
    }

    public void Interact()
    {
        if (isSoulGathered || !isSoulGatherable) return;
        GatherSoul();
    }

    private void GatherSoul()
    {
        _player.DisableMovement();
        SwitchToSoulCamera();
        PlayOneShotCollectFX();
        isSoulGathered = true;
        transform.DOMoveY(transform.position.y + 0.5f, 1f).onComplete += () =>
        {

            transform.DOShakeRotation(5f, 5, fadeOut: false, randomnessMode: ShakeRandomnessMode.Harmonic).onComplete += () =>
            {
                transform.DOMoveY(transform.position.y - 0.5f, 1f).onComplete += () =>
                {
                    SwitchBackToMainCamera();
                    _player.EnableMovement();
                };
            };
        };
    }

    public void SwitchToSoulCamera()
    {

        _mainCamera.Priority = 10;
        _soulCamera.Priority = 11;
    }

    public void SwitchBackToMainCamera()
    {

        _mainCamera.Priority = 11;
        _soulCamera.Priority = 10;
    }

    private void PlayOneShotCollectFX()
    {
        _audioSource.pitch = Random.Range(0.9f, 1.1f);
        _audioSource.PlayOneShot(_gatherSoundFX);
    }
}
