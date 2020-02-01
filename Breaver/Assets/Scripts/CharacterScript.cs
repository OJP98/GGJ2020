﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public bool lookingLeft = true;
    public float rotateSpeedGrounded = 3.0f;
    private Vector3 moveDirection = Vector3.zero;
    private ObjectDetection objectDetection;
    private Holder holder;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        objectDetection = GetComponent<ObjectDetection>();
        holder = GetComponent<Holder>();
    }
    void Update()
    {
        Move();
        ChangeDirection();
        if (Input.GetKeyDown(KeyCode.LeftShift)) GrabObject();
    }

    void Move()
    {
        if(characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;
            if (Input.GetAxis("Vertical") > 0) moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal")*speed, moveDirection.y, 0.0f);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);


    }

    void GrabObject()
    {
        Object currentObj = objectDetection.GetSelected();

        if (!holder.HasMovable())
        {
            if (currentObj != null)
            {
                holder.SetMovable(currentObj);
                currentObj.NewParent();
            }
        }

        else if (holder.HasMovable())
        {
            Object obj = holder.GetObject();
            obj.Unparent();
            holder.RemoveMovable();
        }
    }

    void ChangeDirection()
    {
        float axis = Input.GetAxis("Horizontal");
        if (axis < 0) transform.eulerAngles = new Vector3(0, -180, 0);
        else if (axis > 0) transform.eulerAngles = new Vector3(0, 0, 0);
    }

}
