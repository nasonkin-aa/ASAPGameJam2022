using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class Chains : Weapon
{
    public List<Link> links = new List<Link>();
   

    public override void LevelUp()
    {
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        links.AddRange(GameObject.FindObjectsOfType<Link>());
        links.OrderBy(x => x.name).ToList();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
