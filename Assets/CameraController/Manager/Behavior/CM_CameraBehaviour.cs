using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraBehaviour : MonoBehaviour
{
    #region f/p

    public Action OnUpdateBehaviour = null;
    
    
    private new Camera camera;
    protected Transform cameraTransform;

    protected BehaviourSettings cameraSettings;

    // Accesseur
    public bool IsValid => cameraSettings.CameraTarget && camera;

   

    protected float x;
    protected float y;
    protected float z;

    public enum FollowVectorType
    {
        Left,
        Right,
        Up,
        Down,
        Forward,
        Backward
    }

    private FollowVectorType fAxis;

    #endregion

    #region unity methods
    protected virtual void OnDestroy()
    {
        OnUpdateBehaviour = null;
    }
    
    #endregion

    #region custom methods
    
    public virtual void Init(BehaviourSettings _cameraSettings, Camera _camera, CM_CameraBehaviour.FollowVectorType _fAxis)
    {
        if (!_camera) return;
        camera = _camera;
        cameraSettings = _cameraSettings;
        cameraTransform = _camera.transform;
        fAxis = _fAxis;
    }

    protected virtual void FollowTarget()
    {
        if (!IsValid) return;
        x = (.9f * x) + (0.10f * cameraSettings.CameraTarget.position.x);
        y = (.9f * y) + (0.10f * cameraSettings.CameraTarget.position.y);
        z = (.9f * z) + (0.10f * cameraSettings.CameraTarget.position.z);
        Vector3 _offset = GetFollowAxis() * cameraSettings.CameraDistance;
        cameraTransform.position = new Vector3(x, y, z) + _offset;
    }

    protected virtual void LookAtTarget()
    {
        if (!IsValid) return;
        Matrix4x4 _orientation = Matrix4x4.identity;
        Matrix4x4 _translation = Matrix4x4.identity;
        Vector3 _pos = cameraTransform.position;
        Vector3 _target = cameraSettings.CameraTarget.position;

        Vector3 _zAxis = CM_MathTools.GetNormalize(CM_MathTools.GetVector3Substract(_target, _pos));

        Vector3 _xAxis = CM_MathTools.GetNormalize( CM_MathTools.GetVector3CrossProduct(Vector3.up, _zAxis));
        Vector3 _yAxis = CM_MathTools.GetVector3CrossProduct(_zAxis, _xAxis);
        _orientation = new Matrix4x4(new Vector4(_xAxis.x, _xAxis.y, _xAxis.z, 0), 
                                     new Vector4(_yAxis.x, _yAxis.y, _yAxis.z, 0), 
                                     new Vector4(_zAxis.x, _zAxis.y, _zAxis.z, 0), 
                                     new Vector4(0, 0, 0, 1));

        _translation= new Matrix4x4(new Vector4(1, 0, 0, 0),
                                    new Vector4(0, 1, 0, 0),
                                    new Vector4(0, 0, 1, 0),
                                    new Vector4(-_pos.x, -_pos.y, -_pos.z, 1));


        Matrix4x4 _multiplied = _orientation * _translation;

        cameraTransform.rotation = _multiplied.rotation;

        //Debug.Log($"{CM_MathTools.GetVector3CrossProduct(Vector3.up, _zAxis)} - {Vector3.Cross(Vector3.up, _zAxis)}");
        //Debug.Log($"{_zAxis}-{_direction.normalized}");
        //cameraTransform.rotation.SetLookRotation(_zAxis);
    }

    

    protected Vector3 GetFollowAxis()
    {
        switch (fAxis)
        {
            case FollowVectorType.Left:
                return -cameraSettings.CameraTarget.right;
            case FollowVectorType.Right:
                return cameraSettings.CameraTarget.right;
            case FollowVectorType.Up:
                return cameraSettings.CameraTarget.up;
            case FollowVectorType.Down:
                return -cameraSettings.CameraTarget.up;
            case FollowVectorType.Forward:
                return cameraSettings.CameraTarget.forward;
            case FollowVectorType.Backward:
                return -cameraSettings.CameraTarget.forward;
        }

        return Vector3.zero;
    }
    #endregion
    
    #region debug

    protected Color debugColor = Color.white;

    [SerializeField, Range(.1f, 1f), Header("DEBUG - GIZMO SIZE")]
    private float size = 1;

    private void OnDrawGizmos()
    {
        if (!IsValid) return;
        Gizmos.color = debugColor;
        Gizmos.DrawSphere(transform.position + Vector3.up *2, size);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, cameraSettings.CameraTarget.position);
    }
    #endregion
}