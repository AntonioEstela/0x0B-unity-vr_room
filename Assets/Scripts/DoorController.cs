using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {   
        Animator.SetBool("character_nearby", !Animator.GetBool("character_nearby"));
        Debug.Log("The door is open");
    }
}
