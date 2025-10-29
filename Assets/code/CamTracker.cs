using System;
using UnityEngine;

public class CamTracker : MonoBehaviour
{
    public Transform CameraPosition;

    private void Update()
    {
        transform.position = CameraPosition.position;
    }
}
