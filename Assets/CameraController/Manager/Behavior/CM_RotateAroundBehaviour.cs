using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_RotateAroundBehaviour : CM_CameraBehaviour
{
    float angle = 0;
    public override void Init(BehaviourSettings _cameraSettings, Camera _camera, FollowVectorType _fAxis)
    {
        base.Init(_cameraSettings, _camera, _fAxis);
        OnUpdateBehaviour += LookAtTarget;
        OnUpdateBehaviour += RotateAround;
    }
    
    private void RotateAround()
    {
        if (!IsValid) return;
        cameraTransform.position = CM_MathTools.GetRotateAround(cameraSettings.CameraTarget.position, cameraSettings.CameraDistance, ref angle, cameraSettings.CameraSpeed, Time.deltaTime);
    }
}
