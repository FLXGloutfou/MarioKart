using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public CarControler carcontroler;
    private float _currentspeed;
    private int _speedboost = 2 ;
    private bool _isboosting = false;

    private void Start()
    {
        _currentspeed = carcontroler.speedMax;
    }
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost"))
        {
            if (_isboosting == false)
            {
                StartCoroutine(Boostspeed());
            }
        }
        
    }
    public void ItemBoost()
    {
        StartCoroutine(Boostspeed());
    }
    public IEnumerator Boostspeed()
    {

        _isboosting=true;
        carcontroler.speedMax = carcontroler.speedMax * _speedboost;
        yield return new WaitForSeconds(1f);
        carcontroler.speedMax = _currentspeed;
        _isboosting =false;
    }
}
