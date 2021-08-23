using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagic : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!="Player" && collision.tag!="Coins")
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            Boss boss = collision.GetComponent<Boss>();

            if (enemy!=null)
            {
                enemy.TakeDamage(damage);
            }

            if (boss != null)
            {
                boss.TakeDamage(damage);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

}
