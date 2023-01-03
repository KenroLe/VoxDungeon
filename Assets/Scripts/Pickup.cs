using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public InventoryItemData iData;
    // Update is called once per frame
    private void Start()
    {
        GameObject item = Instantiate(iData.prefab,transform);
        item.AddComponent<Rigidbody>();
        item.GetComponent<Collider>().isTrigger = false;
    }
}
