using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_OscilateBehaviour : CM_CameraBehaviour
{
    float delta = 0;
    public override void Init(BehaviourSettings _cameraSettings, Camera _camera, FollowVectorType _fAxis)
    {
        base.Init(_cameraSettings, _camera, _fAxis);
        OnUpdateBehaviour += OscilateCamera;
    }

    private void OscilateCamera()
    {
        if (!IsValid) return;
        cameraTransform.position = CM_MathTools.GetOscilation(cameraTransform.position, cameraSettings.CameraDistance, ref delta, cameraSettings.CameraSpeed, Time.deltaTime);
    }

    public void TestFunc()
    {
        while (IsValid)
        {

        }
    }
}
