using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventoryController inv_c;
    public Text txt;
    // Update is called once per frame
    void Update()
    {
        //this code is temporary
        string tmp = "Inventory\n";
        txt.text = tmp;
        for (int i = 0; i< inv_c.items.Length;i++)
        {
            if (inv_c.items[i] != null)
            {
                txt.text = txt.text + inv_c.items[i].name + "\n";
            }
        }
    }
}
