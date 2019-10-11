using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraFpsBehaviour : CM_CameraBehaviour
{
    #region unity methods
    #endregion

    #region custom methods

    public override void Init(BehaviourSettings _cameraSettings, Camera _camera, CM_CameraBehaviour.FollowVectorType _fAxis)
    {
        base.Init(_cameraSettings, _camera, _fAxis);
        debugColor = Color.green;
        OnUpdateBehaviour += FollowTarget;
        OnUpdateBehaviour += LookAtTarget;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void FollowTarget()
    {
        Vector3 _finalPos = cameraSettings.CameraTarget.position + (GetFollowAxis() * cameraSettings.CameraDistance);
;        cameraTransform.position = CM_MathTools.Lerp(cameraTransform.position, cameraSettings.CameraTarget.position, Time.deltaTime * cameraSettings.CameraSpeed);
    }

    protected override void LookAtTarget()
    {
        base.LookAtTarget();
    }
    
    #endregion
}
