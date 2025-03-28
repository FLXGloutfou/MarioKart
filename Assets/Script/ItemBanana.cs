using UnityEngine;

[CreateAssetMenu(fileName = "ItemBanana", menuName = "Scriptable Objects/ItemBanana")]
public class ItemBanana : Item
{
    [SerializeField]
    private GameObject _banana;
    public override void Activation(PlayerItemManager player)
    {
        Vector3 spawnPosition = player.transform.position - player.transform.forward * 2.5f;
        Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);
        GameObject Banana = Instantiate(_banana, spawnPosition, spawnRotation);

    }
}
