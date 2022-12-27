using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private const int enemyLayer = 6;

    private void Start()
    {
        Invoke("destroyBullet", 3);
    }

    public void destroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == enemyLayer)
        {
            col.gameObject.GetComponent<Creature>().TackDamege(damage);
            Destroy(gameObject);
        }
    }
}
