using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Chains : Weapon
{
    public List<Link> links = new List<Link>();
    public GameObject block;
    public GameObject chain1;
    public GameObject chain2;
    // Start is called before the first frame update
    void Start()
    {
        links.AddRange(GameObject.FindObjectsOfType<Link>());
        links.OrderBy(x => x.name).ToList();
 
    }
    public override void Attack()
    {
        return;
    }

    public override void LevelUp()
    {
        switch (level)
        {
            case 0:
                block.SetActive(true);
                description = "link + 1";
                break;
            case 1:
                chain1.SetActive(true);
                description = "link + 1";
                break;
            case 2:
                chain2.SetActive(true);
                description = "damage + 1";
                break;
            default:
                foreach (Link link in links)
                {
                    link.damage += 1;
                }
                description = "damage +1";
                break;
        }
        level++;
    }
}
