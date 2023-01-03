using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class InventoryController : MonoBehaviour
{
    public InventoryItemData[] items = new InventoryItemData[34];
    public ItemSlot R_HandSlot, L_HandSlot;
    public LayerMask ignoreLayer;
    // Start is called before the first frame update
    public void AddToInventory(Pickup item)
    {
        
        for (int i = 0; i<items.Length; i++) // find an empty cell
        {
            if (items[i] == null) // add item
            {
                items[i] = item.iData; // save the data of pickup
                Destroy(item.gameObject); // destroy pickup
                return;
            }
        }
    }
    public void UseAtIndex(int index)
    {
        if (R_HandSlot.IsItemEquipped())
        {
            R_HandSlot.UnEquip();
            
        } else
        {
            R_HandSlot.Equip(items[index]);
        }
    }
    void Start()
    {
        // getting handles for itemslots
        ItemSlot[] itemSlots = GetComponentsInChildren<ItemSlot>();
        for (int i = 0; i<itemSlots.Length; i++)
        {
            Debug.Log("found " + itemSlots[i]);
            switch (itemSlots[i].itemSlotType)
            {
                case ITEM_SLOT_TYPE.L_HAND:
                    L_HandSlot= itemSlots[i];
                    break;
                case ITEM_SLOT_TYPE.R_HAND:
                    R_HandSlot= itemSlots[i];
                    break;
            }
        }
    }
}
