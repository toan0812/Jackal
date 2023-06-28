using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : JackalMono
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector2 MinPos;
    [SerializeField] private Vector2 MaxPos;
    [SerializeField] private float smothTrans = 0.1f;
    void FixedUpdate()
    {
        FlowTarget();
    }
    private void FlowTarget()
    {
        Vector3 desiredPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, MinPos.x, MaxPos.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, MinPos.y, MaxPos.y);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smothTrans);
    }


}
