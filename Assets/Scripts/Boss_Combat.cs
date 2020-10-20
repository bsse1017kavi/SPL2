using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Combat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask attackLayer;

    public Vector3 attackOffset = new Vector3(-1.5f,0.35f,0f);

    public float attackRange = 1.45f;
    public int attackDamage = 20;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackLayer);

        if(colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackLayer);

        if (colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage*2);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
