using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform otherPortal;


    private void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCamDir = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
    }
}
