using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private PauseMenu _pauseMenu;
    [SerializeField] public List<Image> Image;
    [SerializeField] public List<Text> Name;
    [SerializeField] public List<Text> Descript;
    [SerializeField] public List<Text> Level;
    [SerializeField] public List<Character> characters;
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

    private void ChangeText(List<(Sprite ,string ,string , int, Character)> list)
    {
        for (int i = 0; i < 3; ++i)
        {
            Image[i].sprite = list[i].Item1;
            Name[i].text = list[i].Item2;
            Descript[i].text = list[i].Item3;
            Level[i].text ="Ур " + list[i].Item4.ToString();
            characters[i] = list[i].Item5;
        }
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

    public void Click1()
    {
        characters[0].LvlUpWeapon(Name[0].text);
    }
    public void Click2()
    {
        characters[0].LvlUpWeapon(Name[1].text);
    }
    public void Click3()
    {
        characters[0].LvlUpWeapon(Name[2].text);
    }
}
