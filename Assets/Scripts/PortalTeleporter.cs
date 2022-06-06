using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform reciever;

    private bool playerOverlapping = false;

    void Update()
    {
        if (playerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOverlapping = false;
        }
    }
}
