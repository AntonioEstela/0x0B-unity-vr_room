using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{
    public GameObject Player;
    public GameObject TransitionImage;
    private Animator Animator;


    void Start()
    {
        Animator = TransitionImage.GetComponent<Animator>();
    }
    public void Teleport()
    {
        Animator.Play("TeleportTransition", -1, 0f);
        // yield return new WaitForSeconds(1f);
        Player.transform.position = new Vector3(transform.position.x, (transform.position.y + 1.8f), transform.position.z);

    }
}
