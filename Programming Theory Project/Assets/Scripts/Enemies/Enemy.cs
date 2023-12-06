using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int enemyHealth = 1;

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        CalculateHealth();
        this.transform.Rotate(-75, 0, 0);

        if (enemyHealth < 0)
        {
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }

            StartCoroutine(Die());
        }
     
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    private void CalculateHealth()
    {
        enemyHealth =- 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(1);
        }
    }

}
