using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstacleCheck : MonoBehaviour
{
    public Transform player;
    public LayerMask obstacleLayer;

    private List<ObjectFade> fadedObjects = new List<ObjectFade>();

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        float distance = Vector3.Distance(transform.position, player.position);

        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, distance, obstacleLayer);

        foreach (var faded in fadedObjects)
        {
            faded.FadeIn();
        }

        fadedObjects.Clear();

        foreach (var hit in hits)
        {
            ObjectFade objectFade = hit.collider.GetComponent<ObjectFade>();
            if (objectFade != null && !fadedObjects.Contains(objectFade))
            {
                objectFade.FadeOut();
                fadedObjects.Add(objectFade);
            }
        }
    }
}
