using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MagicLauncher : MonoBehaviour
{
    public TextMeshProUGUI fire_amount_text;
    public static int fireAmount = 5;

    public Transform firePoint;
    public GameObject firePrefab;
    public GameObject bloodArrowPrefab;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        fire_amount_text.text = "" + fireAmount.ToString();

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            fireAmount = 5;
        }
    }

    public void Shoot()
    {
        if (fireAmount > 0)
        {
            fireAmount--;
            animator.SetTrigger("FireShot");
            //GetComponent<Player>().TakeDamage(20);
            Instantiate(firePrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void BloodArrowShoot()
    {
        GetComponent<Player>().TakeDamage(20);
        animator.SetTrigger("ArrowShot");
        Instantiate(bloodArrowPrefab, firePoint.position, firePoint.rotation);
    }
}
