using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using DitzeGames.MobileJoystick;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Joystick joystick;

    private CharacterController characterController;
    private Vector3 movimento;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        if(!isLocalPlayer)
            return;

        /*movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");*/

        //movimento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movimento = new Vector3(joystick.AxisNormalized.x, 0, joystick.AxisNormalized.y);
        movimento = Vector3.ClampMagnitude(movimento, 1f);
        movimento = transform.TransformDirection(movimento);

    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        characterController.SimpleMove(movimento * speed);
    }
}
