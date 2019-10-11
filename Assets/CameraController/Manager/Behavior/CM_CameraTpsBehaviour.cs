using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraTpsBehaviour : CM_CameraBehaviour
{
    #region f/p

    private Vector2 input;
    
    #endregion

    #region unity methods

    private void Start()
    { 
        //CM_InputManager.Instance.OnMouse += InputManagerOnMouse;
    }

    #endregion

    #region custom methods

    public override void Init(BehaviourSettings _cameraSettings, Camera _camera, CM_CameraBehaviour.FollowVectorType _fAxis)
    {
        base.Init(_cameraSettings, _camera, _fAxis);
        debugColor = Color.green;
        OnUpdateBehaviour += FollowTarget;
        OnUpdateBehaviour += LookAtTarget;
    }

    private void InputManagerOnMouse(float _fxValue, float _fyValue, float _fWheelValue)
    {
        input += new Vector2(_fxValue, _fyValue);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void FollowTarget()
    {
        base.FollowTarget();
    }

    protected override void LookAtTarget()
    {
        //transform.localRotation = Quaternion.Euler(input.y, input.x, 0);
        //transform.localPosition = cameraSettings.CameraTarget.transform.position - (transform.localRotation * Vector3.forward * cameraSettings.CameraDistance);
        base.LookAtTarget();
    }

    #endregion
}