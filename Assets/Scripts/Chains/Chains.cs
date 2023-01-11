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
    public GameObject chain3;
    public GameObject chain4;
    List<Vector2> list1 = new List<Vector2>();

    public List<Transform> ChainList = new List<Transform> ();
    void Start()
    {
        links.AddRange(FindObjectsOfType<Link>());
        links.OrderBy(x => x.name).ToList();
    }
    public void Update()
    {
        for (var i = 0; i < ChainList.Count; i++)
        {
            list1.Add(ChainList[i].localPosition);
        }
        transform.GetComponent<EdgeCollider2D>().SetPoints(list1);
        list1.Clear();
    }
    public override void Attack()
    {
       
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TackDamege(damage);
        }
        Debug.Log(damage + " ~!!!!!!!!!!!!!!!!");
    }
 
    public override void LevelUp()
    {
        switch (level)
        {
            case 0:

                gameObject.GetComponent<EdgeCollider2D>().enabled = true;
                block.SetActive(true);
                description = "link + 1";
              
                break;
            case 1:
                chain1.SetActive(true);
                description = "link + 1";
                ChainList.Add(chain1.transform);
                break;
            case 2:
                chain2.SetActive(true);
                description = "link + 1";
                ChainList.Add(chain2.transform);
                break;
            case 3:
                chain3.SetActive(true);
                description = "link + 1";
                ChainList.Add(chain3.transform);
                break;
            case 4:
                chain4.SetActive(true);
                description = "damage + 1";
                ChainList.Add(chain4.transform);
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
