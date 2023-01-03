using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Handles player input
public class PlayerInputController : MonoBehaviour
{
    Camera cam;
    MovementController mc;
    HandController L_handController;
    HandController R_handController;
    InventoryController inv_c;
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        mc = GetComponent<MovementController>();
        inv_c= GetComponentInChildren<InventoryController>(); 
        HandController[] handControllers= GetComponentsInChildren<HandController>();
        for (int i = 0; i< handControllers.Length; i++)
        {
            if (handControllers[i].GetComponent<ItemSlot>().itemSlotType == ITEM_SLOT_TYPE.L_HAND)
            {
                L_handController = handControllers[i];
            }
            if (handControllers[i].GetComponent<ItemSlot>().itemSlotType == ITEM_SLOT_TYPE.R_HAND)
            {
                R_handController = handControllers[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            movement += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            movement += -cam.transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Rotate the sprite about the Y axis in the positive direction
            movement += cam.transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Rotate the sprite about the Y axis in the negative direction
            movement += -cam.transform.right;
        }
        mc.setMovement(movement);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inv_c.UseAtIndex(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inv_c.UseAtIndex(1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000f, ~inv_c.ignoreLayer))
            {
                Transform objectHit = hit.transform;
                Debug.Log(objectHit);
                Pickup pickup = objectHit.GetComponentInParent<Pickup>();
                Debug.Log(pickup);
                if (pickup != null)
                {
                    inv_c.AddToInventory(pickup);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            L_handController.Punch();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            R_handController.Punch();
        }
    }
}
