using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionCamera : MonoBehaviour
{
    private bool transitioning = false;
    private Vector3 _endPosition;
    private const float cameraSpeed = 4f;

    public Vector3 EndPosition
    {
        private get {
            return _endPosition;
        }

        set {
            _endPosition = value;
            _endPosition.z = transform.position.z; // Don't move the z axis
            _endPosition.y = value.y - 3.5f;
            transitioning = true;
        }
    }

    void Start()
    {
        //EndPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (transitioning) {
            if (transform.position == EndPosition)
            {
                transitioning = false;
                return;
            }
            transform.position = Vector3.MoveTowards(
                transform.position,
                EndPosition,
                Time.deltaTime * cameraSpeed
            );
        }

    }
}
