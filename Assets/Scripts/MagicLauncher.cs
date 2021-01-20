using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicLauncher : MonoBehaviour
{
    public TextMeshProUGUI fire_amount_text;
    public int fireAmount = 5;

    public Transform firePoint;
    public GameObject firePrefab;
    public GameObject bloodArrowPrefab;

    // Update is called once per frame
    void Update()
    {
        fire_amount_text.text = "" + fireAmount.ToString();

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (fireAmount > 0)
        {
            fireAmount--;
            //GetComponent<Player>().TakeDamage(20);
            Instantiate(firePrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void BloodArrowShoot()
    {
        GetComponent<Player>().TakeDamage(20);
        Instantiate(bloodArrowPrefab, firePoint.position, firePoint.rotation);
    }
}
