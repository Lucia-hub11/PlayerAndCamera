using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float TurnSpeed = 1;
    InputController _input;

    void Start()
    {
        _input = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    private void Turn()
    {
        var localInput = transform.right * _input.Look.x + transform.forward * _input.Look.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z);
        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            Vector3 current = transform.position + transform.forward;
            Vector3 look = Vector3.Lerp(current, target, TurnSpeed * Time.deltaTime);
            transform.LookAt(look);
        }
    }
}
