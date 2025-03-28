using UnityEngine;

[CreateAssetMenu(fileName = "ItemCoin", menuName = "Scriptable Objects/ItemCoin")]
public class ItemCoin : Item
{
    [SerializeField]
    private GameObject _coin;

    public float throwForce = 10f;
    public override void Activation(PlayerItemManager player)
    {
        GameObject ItemCoin = Instantiate(_coin, player.transform.position + player.transform.forward, player.transform.rotation);

        player.coinManager.Addcoin();

        Rigidbody rb = ItemCoin.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(player.transform.up * throwForce, ForceMode.Impulse);
        }

        Destroy(ItemCoin, 1f);
    }
}
