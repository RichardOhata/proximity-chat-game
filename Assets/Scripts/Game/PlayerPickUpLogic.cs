using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpLogic : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;


    [SerializeField]
    private Transform playerCameraTransform;


    [SerializeField]
    private GameObject pickUpUI;


    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    private RaycastHit hit;

    private void Update()
    {

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);

        }

       
        if (inHandItem != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                if (hit.collider != null)
                {
                    inHandItem.transform.SetParent(null);
                    inHandItem = null;
                    hit.collider.GetComponent<Highlight>().isPickedUp = false;
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false;
                    }
                }


            }
            return;
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
              
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                Debug.Log("Pressed E");
                inHandItem = hit.collider.gameObject;
                inHandItem.transform.position = Vector3.zero;
                inHandItem.transform.rotation = Quaternion.identity;
                inHandItem.transform.SetParent(pickUpParent.transform, false);
                hit.collider.GetComponent<Highlight>().isPickedUp = true;
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                return;
            }
        }
    }
}
