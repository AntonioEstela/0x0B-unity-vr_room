using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeTimerController : MonoBehaviour
{
    public float TotalTime = 2f;
    public Image ReticleLoaderImage;
    bool GVRStatus = false;
    float GVRTimer = 0;
    private RaycastHit _hit;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Just for testing
        Debug.DrawRay(Player.transform.position, Player.transform.TransformDirection(Vector3.forward) * 6f, Color.yellow);

        // A ray that points just 6 units
        // Just 4.5 because it's kinda weird to interact whit an object that is too far away
        if (Physics.Raycast(ray, out _hit, 6f))
        {
            if (GVRStatus == true)
            {
                GVRTimer += Time.deltaTime;
                ReticleLoaderImage.fillAmount = GVRTimer / TotalTime;
            }

            if (ReticleLoaderImage.fillAmount == 1)
            {
                // When the user look at a teleport GameObject
                if (_hit.transform.CompareTag("Teleport"))
                    _hit.transform.gameObject.GetComponent<TeleportController>().Teleport();

                // When the user look at a Door GameObject
                if (_hit.transform.CompareTag("Door"))
                    _hit.transform.gameObject.GetComponent<DoorController>().OpenDoor();

                // When the user look at an interactable object
                if (_hit.transform.CompareTag("Interactable"))
                    _hit.transform.gameObject.GetComponent<InteractController>().ObjectInteract();
            }
        }
    }

    public void GVROn()
    {
        GVRStatus = true;
    }

    public void GVROff()
    {
        GVRStatus = false;
        GVRTimer = 0;
        ReticleLoaderImage.fillAmount = 0;
    }
}
