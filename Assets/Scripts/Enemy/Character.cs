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

    public GameObject Chains;
    private PlayerInput _playerInput;
    Rigidbody2D rigidbody2D;
    [SerializeField] private BarStatus hpBar;
    public float maxHp;
    public List<Weapon> _weapons = new List<Weapon>();
    public int hpRegenerationColldown = 4;
    public float hpRegenerationTimer = 4f;
    public float hpRegeneration = 1f;
    public List<pickUp> links = new List<pickUp>();

    public GameObject EndGAmemennu;

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
        List<Weapon> allWeapons = new List<Weapon>();
        allWeapons.AddRange(gameObject.GetComponents<Weapon>());
        allWeapons.Add(Chains.GetComponent<Weapon>());

        var weaponList = new List<(Sprite, string, string, int, Character)>();

        var random = new System.Random();
        var intArray = Enumerable.Range(0, allWeapons.Count).OrderBy(t => random.Next()).Take(3).ToArray();

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
          (Vector2) _playerInput.Moving.normalized * Time.deltaTime * _speed;
        _weapons.ForEach(e=>e.Attack());

        hpBar.SetState(_hp, maxHp);
        HpRegeneration();
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
        yield return new WaitForSeconds(0.5f);
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

            List<Weapon> newWeapons = new List<Weapon>();
            newWeapons.AddRange(gameObject.GetComponents<Weapon>());
            newWeapons.Add(Chains.GetComponent<Weapon>());
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

    public void HpBoost(int hp)
    {
        maxHp += hp;
        _hp += hp;
    }
    public void SpeedBoost(float speed)
    {
        _speed += speed;
    }

    private void HpRegeneration()
    {
        hpRegenerationTimer -= Time.deltaTime;
        if (hpRegenerationTimer < 0)
        {           
            hpRegenerationTimer = hpRegenerationColldown;
            if (_hp + hpRegeneration > maxHp)
                _hp = maxHp;
            else
                _hp += hpRegeneration;
        }
    }
    public override void Die(GameObject creature)
    {
        EndGAmemennu.SetActive(true);
        
        links.AddRange(GameObject.FindObjectsOfType<pickUp>());
        foreach (var link in links)
        {
            Debug.Log(link.name);
            Destroy(link.gameObject);
        }
        //base.Die(creature);
        Time.timeScale = 0;

    }
    public void HpRegenerationUp (float hpRegenerationBoost)
    {
        hpRegeneration += hpRegenerationBoost;
    }

}
