using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private Quaternion rotationValues;
    private Vector3 newPosition;
    private Vector3 position;
    private bool rotation = false;
    // Start is called before the first frame update
    void Start()
    {
        rotationValues = transform.rotation;
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (rotation == true)
        {
            transform.Rotate(new Vector3(0f, 15f, 15f) * Time.deltaTime);
        }
        else
        {
            transform.rotation = rotationValues;
        }
    }

    public void ObjectInteract()
    {
        newPosition = new Vector3(-0.3f, 0.3f, -0.5f) + transform.position;
        rotation = !rotation;
        Debug.Log(newPosition == transform.position);
        transform.position = rotation == false ? position : newPosition;
    }
}
