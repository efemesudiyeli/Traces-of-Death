using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsBehaviour : MonoBehaviour
{

    [SerializeField] private RectTransform _slidingPanel;
    [SerializeField] private TextMeshProUGUI _lastShownPanel;
    [SerializeField] private float SlideCreditsDuration = 5f;
    [SerializeField] private float ThanksForPlayingDuration = 5f;

    [SerializeField] private RectTransform creditsCanvas;

    private void Awake()
    {
        _lastShownPanel.gameObject.SetActive(false);
        _slidingPanel.gameObject.SetActive(false);
    }

    void Start()
    {
        ShowThanks();
    }

    private void ShowThanks()
    {
        _lastShownPanel.gameObject.SetActive(true);
        DOTween.To(() => _lastShownPanel.color.a, x => _lastShownPanel.color = new Color(_lastShownPanel.color.r, _lastShownPanel.color.g, _lastShownPanel.color.b, x), 1, ThanksForPlayingDuration).onComplete += () =>
        {
            _lastShownPanel.gameObject.SetActive(false);
            _slidingPanel.gameObject.SetActive(true);
            Debug.Log(creditsCanvas.rect.height);
            _slidingPanel.DOMoveY(creditsCanvas.rect.height + 100, SlideCreditsDuration, true).onComplete += () => SceneManager.LoadScene(0);
        };
    }
}
