using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public CarControler carcontroler;
    public UIManager uimanager;

    public float coinCount;

    public void Start()
    {
        coinCount = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (coinCount < 10)
            coinCount++;
            carcontroler.coinSpeed = coinCount * 0.03f;
            uimanager.UpdateCoinCount();
            Destroy(other.gameObject);
        }

        

    }

}
