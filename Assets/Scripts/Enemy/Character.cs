using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Character : Creature
{
    bool IsSaveCharacter;
    private PlayerInput _playerInput;
    Rigidbody2D rigidbody2D;
    [SerializeField] private BarStatus hpBar;
    public float maxHp;
    public List<Weapon> _weapons = new List<Weapon>();

    public static Action <List<(Sprite, string, string, int, Character)>> onOpen;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = transform.GetComponent<PlayerInput>();
    }

    private void Start()
    {
        //_weapons.AddRange(gameObject.GetComponents<Weapon>());

        _weapons.Add(gameObject.GetComponent<WeaponGunPlayer>());
        //_weapons[0].description = " damege +5";
        var comp = gameObject.GetComponent<WeaponGunPlayer>().enabled = true;
        maxHp = _hp;

        onOpen?.Invoke(GetRandomWeapons());
    }

    private List<(Sprite, string, string, int, Character)> GetRandomWeapons()
    {
        var allWeapons = gameObject.GetComponents<Weapon>();
        var weaponList = new List<(Sprite, string, string, int, Character)>();

        var random = new System.Random();
        var intArray = Enumerable.Range(0, allWeapons.Length).OrderBy(t => random.Next()).Take(2).ToArray();
        //Debug.Log(intArray);

        foreach (var weapon in intArray)
        {
            var weap = allWeapons[weapon];
            weaponList.Add((weap.icon, weap.name, weap.description, weap.level, this));
        }
        return weaponList;
    }

    void Update()
    {
        rigidbody2D.position +=
          (Vector2) _playerInput.Moving * Time.deltaTime * _speed;
        _weapons.ForEach(e=>e.Attack());
    }
    protected override void Attac(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void TackDamege(int damage)
    {
        if (!IsSaveCharacter)
        {
            StartCoroutine(SaveTime());
            base.TackDamege(damage);
        }
        hpBar.SetState(_hp, maxHp);
    }
    IEnumerator SaveTime()
    {
        IsSaveCharacter = true;
        yield return new WaitForSeconds(2f);
        IsSaveCharacter = false;
    }

    public void LvlUpWeapon(string name)
    {
        var weap = _weapons.Find(e=>e.name == name);
        if (weap != null)
        {
            weap.LevelUp();
        }
        else
        {
            var newWeapons = gameObject.GetComponents<Weapon>();
            foreach (var weapon in newWeapons)
            {
                if (weapon.name == name)
                {
                    weapon.LevelUp();
                    _weapons.Add(weapon);
                    
                }
            }
        }
        onOpen?.Invoke(GetRandomWeapons());
    }
}
