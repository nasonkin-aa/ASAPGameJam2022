using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFollow : MonoBehaviour
{
    public GameObject Exp;


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<Character>())
        {
           Exp.transform.position = Vector2.Lerp(transform.position, collision.transform.position, Time.deltaTime * 2);
           
        }
    }
    public IEnumerable follow()
    {

        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
