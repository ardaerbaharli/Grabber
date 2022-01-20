using System;
using System.Collections;
using UnityEngine;

public class HookMoves : MonoBehaviour
{
    private readonly float minRotationZ = -50; //hook angles
    private readonly float maxRotationZ = 50; //hook angles
    private readonly float minPositionY = -4.5f; //length of the rope Y-axis
    private readonly float rotationSpeed = 60f; //hook rotation speed
    private readonly float verticalMoveSpeed = 3f; //speed of the rope 

    private float initialPositionY;
    private int hookWeight;
    private float moveSpeed;
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
        moveSpeed = verticalMoveSpeed;
        isRotate = true;
        hookWeight = 0;
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

        if (rotateAngle < minRotationZ)
            rotateLeftSide = false;
        else if (rotateAngle >= maxRotationZ)
            rotateLeftSide = true;
    }

    private void ClickScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isRotate) return;

            isRotate = false;
            isMoveDown = true;
        }
    }

    private void MoveRope()
    {
        if (isRotate)
            return;

        var tempRopePosition = transform.position;
        if (isMoveDown)
        {
            moveSpeed = verticalMoveSpeed;
            tempRopePosition -= transform.up * (Time.deltaTime * moveSpeed); // up->y axis
        }
        else
            tempRopePosition += transform.up * (Time.deltaTime * moveSpeed);

        transform.position = tempRopePosition;

        if (tempRopePosition.y <= minPositionY)
            isMoveDown = false;
        else if (tempRopePosition.y > initialPositionY)
        {
            isRotate = true;
            ropeRenderer.RenderLine(tempRopePosition, false);
        }

        ropeRenderer.RenderLine(tempRopePosition, true);
    }

    public void PullBack(Transform item = null)
    {
        // If item is not null
        // pull the item with the rope
        if (item != null)
        {
            var parent = item.parent;
            print(item.name);
            hookWeight += item.GetComponent<Item>().weight;
            item.SetParent(transform);
            StartCoroutine(DestroyItem(item.gameObject));
        }

        moveSpeed = verticalMoveSpeed * ((100f - hookWeight) / 100);
        print($"{moveSpeed} = {verticalMoveSpeed} * ((100 - {hookWeight}) / 100);");
        isMoveDown = false;
    }

    private IEnumerator DestroyItem(GameObject item)
    {
        yield return new WaitUntil(() => Math.Abs(transform.position.y - initialPositionY) < 0.05f);
        Destroy(item);
        hookWeight = 0;
    }
}