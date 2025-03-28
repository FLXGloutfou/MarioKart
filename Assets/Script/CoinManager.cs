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
            {
                coinCount++;
                carcontroler.coinSpeed = coinCount * 0.03f;
                uimanager.UpdateCoinCount();
                Destroy(other.gameObject);
            }
            
        }

    }

    public void Addcoin()
    {
        if (coinCount < 10)
        {
            coinCount++;
            carcontroler.coinSpeed = coinCount * 0.03f;
            uimanager.UpdateCoinCount();
        }
    }

    public void RemoveCoins()
    {
        if (coinCount <= 5)
        {
            coinCount = 0;
        }
        else
        {
            coinCount = coinCount - 5;
        }
        uimanager.UpdateCoinCount();
    }

}
