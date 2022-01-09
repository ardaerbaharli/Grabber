using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMoves : MonoBehaviour
{
    public float minRotationZ = -50, maxRotationZ = 50;
    public float minPositionY = -4.5f;
    public float rotationSpeed = 5f;
    public float moveSpeed = 3f;

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

    // Update is called once per frame
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
            Vector3 temp = transform.position;
            if (isMoveDown)
                temp -= transform.up * Time.deltaTime * moveSpeed; // up->y axis
            else
                temp += transform.up * Time.deltaTime * moveSpeed;

            transform.position = temp;

            if (temp.y <= minPositionY)
                isMoveDown = false;
            else if (temp.y > initialPositionY)
            {
                isRotate = true;
                ropeRenderer.RenderLine(temp, false);
                moveSpeed = initialMoveSpeed;
            }
            ropeRenderer.RenderLine(temp, true);
        }
    }
}
