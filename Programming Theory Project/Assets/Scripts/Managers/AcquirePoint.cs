using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquirePoint : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.ScorePoint(5);
        }
        Destroy(this.gameObject);
    }
}
