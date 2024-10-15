using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    InputController _input;
    public float Speed=1;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_input.Move.x, 0, _input.Move.y);
        _characterController.SimpleMove(direction * Speed);

        if(direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            transform.LookAt(target);
        }
    }
}
