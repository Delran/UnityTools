using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraShakeBehavior : CM_CameraBehaviour
{
    // Start is called before the first frame update
    public override void Init(BehaviourSettings _cameraSettings, Camera _camera, FollowVectorType _fAxis)
    {
        base.Init(_cameraSettings, _camera, _fAxis);
        OnUpdateBehaviour += CameraShake;
    }

    private void CameraShake()
    {
        //Random 
    }

}
