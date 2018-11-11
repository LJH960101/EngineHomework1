﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FSMManager 전역에 대한 내용을 처리하는 클래스
// 기즈모에 대한 처리가 있음.
public class FSMManager : MonoBehaviour
{
    private Camera _sight;
    public Camera Sight { get { return _sight; } }
    public int sightAspect = 3;
    private Color _gizmoColor;
    protected void SetGizmoColor(Color color) { _gizmoColor = color; }

    protected virtual void Awake()
    {
        _sight = GetComponentInChildren<Camera>();
        _sight.aspect = sightAspect;
    }

    private void OnDrawGizmos()
    {
        if (_sight != null)
        {
            Gizmos.color = _gizmoColor;
            Matrix4x4 temp = Matrix4x4.identity;

            Gizmos.matrix = Matrix4x4.TRS(
                _sight.transform.position,
                _sight.transform.rotation,
                Vector3.one
                );

            Gizmos.DrawFrustum(
                Vector3.zero,
                _sight.fieldOfView,
                _sight.farClipPlane,
                _sight.nearClipPlane,
                _sight.aspect
                );

            Gizmos.matrix = temp;
        }
    }

    public virtual void NotifyTargetKilled() { }

    public virtual void SetDeadState() { }
}