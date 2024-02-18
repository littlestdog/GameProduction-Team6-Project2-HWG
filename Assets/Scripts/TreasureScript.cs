using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            Player.GetComponent<PlayerInteraction>().TreasureCollected += 1;
            Destroy(gameObject);
        }
    }
}
