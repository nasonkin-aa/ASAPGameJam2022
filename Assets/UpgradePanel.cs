using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private PauseMenu _pauseMenu;

    private void OnEnable()
    {
        Character.onOpen += OpenPanel;
    }

    private void OnDisable()
    {
        Character.onOpen -= OpenPanel;
    }

    private void Awake()
    {
        _pauseMenu = GetComponent<PauseMenu>();
    }

    public void OpenPanel()
    {
        _pauseMenu.Pause();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        _pauseMenu.Resume();
        panel.SetActive(false);
    }
}
