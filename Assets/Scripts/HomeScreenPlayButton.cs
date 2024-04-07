using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenPlayButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private GameObject _selectionPanel;
    [SerializeField] private Button _selectionSceneBackButton;

    void Start()
    {
        _playButton.onClick.AddListener(ShowSelectionPanel);
        _selectionSceneBackButton.onClick.AddListener(DisableSelectionScene);
    }

    private void ShowSelectionPanel()
    {
        _selectionPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void DisableSelectionScene()
    {
        _selectionPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
