using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CoinManager coinManager = other.GetComponent<CoinManager>();
        if (other.CompareTag("Player"))
        {
            coinManager.RemoveCoins();
            Destroy(this.gameObject);
        }
    }
}
