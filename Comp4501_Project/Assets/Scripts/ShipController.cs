﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ShipController : MonoBehaviour {

    public LayerMask movementMask;

    Camera cam;
    ShipMotor motor;

    public bool isSelected;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        motor = GetComponent<ShipMotor>();

        isSelected = false;
    }

    // Update is called once per frame
    void Update() {
        // Left mouse
        if (Input.GetMouseButton(1)) {
            if (isSelected) {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 1000, movementMask)) {
                    motor.MoveToPoint(hit.point);
                }
            }
        }
    }

    private void OnMouseDown() {
        //if (!isSelected) { isSelected = true; }

        ToggleSelection();
    }

    public void ToggleSelection() {
        isSelected = !isSelected;
    }
}
