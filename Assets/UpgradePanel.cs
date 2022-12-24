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
        //Character.onOpen -= ChangeText;
    }

    private void Awake()
    {
        _pauseMenu = GetComponent<PauseMenu>();
    }

    private void ChangeText(List<(Sprite ,string ,string , int)> list)
    {
        Debug.Log(list.Count + " lkbyf!!!!!!!!!!!!!!!!!!");
        Debug.Log(list);
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
