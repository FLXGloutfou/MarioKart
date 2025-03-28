using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemCarapace", menuName = "Scriptable Objects/ItemCarapace")]
public class ItemCarapace : Item
{
    [SerializeField]
    private GameObject _carapace;

    public float throwForce = 10f;

    public override void Activation(PlayerItemManager player)
    {
        GameObject thrownObject = Instantiate(_carapace, player.transform.position + player.transform.forward, player.transform.rotation);

        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(player.transform.forward * throwForce, ForceMode.Impulse);
        }

        Destroy(thrownObject, 5f);
    }
}
