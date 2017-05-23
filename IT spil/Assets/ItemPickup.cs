using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour {

    public GameObject axe;
    public Text pickupText;
    private Camera cam;
    private RaycastHit hit;
    private bool axeEquipped = false;
    
    // Use this for initialization
	void Start () {
        cam = gameObject.GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out hit, 10))
        {
            if (hit.collider.tag == "Pickup")
            {
                pickupText.enabled = true;
                if (Input.GetKey(KeyCode.E))
                {
                    axeEquipped = true;
                    axe.SetActive(true);
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                pickupText.enabled = false;
            }
        }
        else
        {
            pickupText.enabled = false;
        }

        if (axeEquipped)
        {
            if (Input.GetMouseButtonDown(0))
            {
                axe.GetComponent<Animation>().Play();

                if (Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out hit, 3))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        LumberjackHealth ljh = hit.transform.gameObject.GetComponent<LumberjackHealth>();
                        ljh.TakeDamage(25);
                        Debug.Log("Enemy hit: " + hit.collider.gameObject.ToString());
                    }
                }
            }
        }
    }
}
