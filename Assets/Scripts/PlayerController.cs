using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string H_XS = "Horizontal";
    private const string V_XS = "Vertical";

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float lookSpeed;

    Vector3 move = Vector3.zero;
    Vector2 mousePos, mousePosPrev, mousePosDiff;

    private void Start()
    {
        //mousePosPrev = mousePos = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                mousePosPrev = mousePos = Input.mousePosition;
            }

            mousePos = Input.mousePosition;
            if (mousePos != mousePosPrev)
            {
                mousePosDiff = (mousePos - mousePosPrev) * Time.deltaTime * lookSpeed;

                transform.Rotate(Vector3.up, mousePosDiff.x);
                playerCamera.Rotate(Vector3.right, -mousePosDiff.y);
            }

            mousePosPrev = mousePos;
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (!Cursor.visible)
                Cursor.visible = true;
        }

        move.x = Input.GetAxisRaw(H_XS);
        move.z = Input.GetAxisRaw(V_XS);
        move.Normalize();

        if (move != Vector3.zero)
            transform.Translate(move * walkSpeed * Time.deltaTime);

    }
}
