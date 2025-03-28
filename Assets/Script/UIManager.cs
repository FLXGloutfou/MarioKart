using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CarControler carcontroler;
    public LapManager lapmanager;
    public CoinManager coinmanager;
    public PlayerItemManager playeritemmanager;

    public GameObject newLapPanel;

    public Text playerPlaceUI;
    public Text coinCountUI;
    public Text lapCountUI;

    public Text UseitemCount;
    public Image ItemImage;


    public IEnumerator UpdateLapUi()
    {
        lapCountUI.text = "Lap " + lapmanager._lapNumber + "/3";
        newLapPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        newLapPanel.SetActive(false);

    }

    public void UpdateCoinCount()
    {
        coinCountUI.text = coinmanager.coinCount.ToString();
    }

}
