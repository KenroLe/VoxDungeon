using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ITEM_SLOT_TYPE
{
    R_HAND,
    L_HAND
}
public class ItemSlot : MonoBehaviour
{
    [Tooltip("Required, object which will be the parent of the instantiated object")]
    public Transform targetObj;
    [Tooltip("Item slot type, used to separate between different item slots in for example InventoryController")]
    public ITEM_SLOT_TYPE itemSlotType;
    private GameObject equipped;
    public void Equip(InventoryItemData itemData)
    {
        equipped = Instantiate(itemData.prefab, targetObj);
    }
    public void UnEquip()
    {
        Destroy(equipped);
    }
    public bool IsItemEquipped()
    {
        if (equipped == null)
        {
            return false;
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
