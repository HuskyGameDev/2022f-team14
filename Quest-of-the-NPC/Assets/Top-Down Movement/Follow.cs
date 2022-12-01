using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Range(0f, 1f)] private float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Animator animator;

    private void FixedUpdate()
    {
        if (target.position.x < 0)
        {
            offset *= -1;
        }
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        animator.SetFloat("Horizontal", target.position.x);
    }
}
