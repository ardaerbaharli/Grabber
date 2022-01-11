using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMoves : MonoBehaviour
{
    public float minRotationZ = -50, maxRotationZ = 50; //hook angles
    public float minPositionY = -4.5f; //length of the rope Y-axis
    public float rotationSpeed = 5f; //hook rotation speed
    public float moveSpeed = 3f; //speed of the rope 

    private float initialPositionY;
    private float initialMoveSpeed;
    private float rotateAngle;

    private bool isRotate;
    private bool rotateLeftSide;
    private bool isMoveDown;

    private RopeRenderer ropeRenderer;
    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }
    void Start()
    {
        initialPositionY = transform.position.y;
        initialMoveSpeed = moveSpeed;
        isRotate = true;
    }

    void Update()
    {
        Rotate();
        ClickScreen();
        MoveRope();
    }
    private void Rotate()
    {
        if (!isRotate)
            return;

        if (rotateLeftSide)
            rotateAngle -= rotationSpeed * Time.deltaTime;
        else
            rotateAngle += rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward); 

        if(rotateAngle<minRotationZ)
            rotateLeftSide = false;
        else if(rotateAngle>= maxRotationZ)
            rotateLeftSide = true;
        
    }
    private void ClickScreen()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isRotate)
            {
                isRotate = false;
                isMoveDown = true;
            }
        }
    }

    private void MoveRope()
    {
        if (isRotate)
            return;
        if(!isRotate)
        {
            Vector3 tempRopePosition = transform.position;
            if (isMoveDown)
                tempRopePosition -= transform.up * Time.deltaTime * moveSpeed; // up->y axis
            else
                tempRopePosition += transform.up * Time.deltaTime * moveSpeed;

            transform.position = tempRopePosition;

            if (tempRopePosition.y <= minPositionY)
                isMoveDown = false;
            else if (tempRopePosition.y > initialPositionY)
            {
                isRotate = true;
                ropeRenderer.RenderLine(tempRopePosition, false);
                moveSpeed = initialMoveSpeed;
            }
            ropeRenderer.RenderLine(tempRopePosition, true);
        }
    }
}
