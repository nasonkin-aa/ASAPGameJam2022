using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private PauseMenu _pauseMenu;
    [SerializeField] private Text textMenu;

    private void OnEnable()
    {
        Character.onOpen += ChangeText;
    }

    private void OnDisable()
    {
        Character.onOpen -= ChangeText;
    }

    private void Awake()
    {
        _pauseMenu = GetComponent<PauseMenu>();
    }

    private void ChangeText(Sprite I,string S,string SS, int II)
    {
        Debug.Log(I);
        Debug.Log(II);
        Debug.Log(S);
        Debug.Log(SS);
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
