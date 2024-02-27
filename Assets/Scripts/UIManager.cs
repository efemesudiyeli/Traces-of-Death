using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour
{
    [Header("Evidence Info")]
    [SerializeField] private TextMeshProUGUI _evidenceDescription;
    [SerializeField] private TextMeshProUGUI _evidenceName;
    [SerializeField] private Image _evidenceSprite;
    [SerializeField] private GameObject _evidencePanel;

    [Header("Dialogue Info")]
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _dialoguePersonText;

    [Header("Evidence")]
    [SerializeField] private TextMeshProUGUI _evidenceCountText;
    [SerializeField] private AudioClip _collectSoundFX;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (_evidencePanel != null)
        {
            _audioSource = GetComponent<AudioSource>();
            _evidencePanel.SetActive(false);
        }
    }

    public void SetEvidenceInfo(EvidenceScriptableObject.EvidenceInfo evidenceInfo)
    {
        _evidenceName.text = evidenceInfo.evidenceName;
        _evidenceDescription.text = evidenceInfo.evidenceDescription;
        _evidenceSprite.sprite = evidenceInfo.evidenceSprite;
    }

    public void ShowEvidencePanel()
    {
        PlayOneShotCollectFX();
        _evidencePanel.SetActive(true);
    }

    public void CloseEvidencePanel()
    {
        _evidencePanel.SetActive(false);
    }

    public void SetDialogueLine(string personName, string dialogueText)
    {
        _dialoguePersonText.text = personName;
        _dialogueText.text = dialogueText;
    }

    public void ShowDialoguePanel()
    {
        _dialoguePanel.SetActive(true);
    }
    public void HideDialoguePanel()
    {
        _dialoguePanel.SetActive(false);
    }

    public void UpdateEvidenceCount(int evidenceCount)
    {
        _evidenceCountText.text = $"Evidence {evidenceCount}/3";
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(9);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void PlayOneShotCollectFX()
    {
        _audioSource.pitch = Random.Range(0.9f, 1.1f);
        _audioSource.PlayOneShot(_collectSoundFX);
    }
}
