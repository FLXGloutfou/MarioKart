using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemShell", menuName = "Scriptable Objects/ItemShell")]
public class ItemShell : Item
{
    [SerializeField]
    private GameObject _shell;

    public float throwForce = 10f;

    public override void Activation(PlayerItemManager player)
    {
        Vector3 spawnPosition = player.transform.position - player.transform.forward * -3f;
        GameObject thrownObject = Instantiate(_shell, spawnPosition + player.transform.forward, player.transform.rotation);

        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(player.transform.forward * throwForce, ForceMode.Impulse);
        }

        Destroy(thrownObject, 5f);
    }
}
