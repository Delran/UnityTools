using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Camera Manager/Component")]
public class CM_CameraComponent : MonoBehaviour
{
    [SerializeField, Header("Camera Component")]
    private string id = "id";
    public string ID => id;

    [SerializeField, Header("Camera Type")]
    private CM_CameraType type = CM_CameraType.TPS;

    [SerializeField, Header("Camera Axis")]
    CM_CameraBehaviour.FollowVectorType fAxis = CM_CameraBehaviour.FollowVectorType.Up;

    [SerializeField, Header("Camera enabled")]
    protected bool enabling = true;
    public bool IsEnabled
    {
        get => enabling;
        set => enabling = value;
    }

    [ContextMenu("Do Something")]
    void DoSomething()
    {
        Debug.Log("Perform operation");
    }

    [SerializeField, Header("Camera Settings")]
    private BehaviourSettings behaviourSettings = new BehaviourSettings();


    private CM_CameraBehaviour cameraBehaviour;

    public CM_CameraBehaviour CameraBehaviour
    {
        get
        {
            if (!cameraBehaviour) throw new CM_CameraManagerMissingBehaviourException(gameObject.name);
            return cameraBehaviour;
        }
    }

    private new Camera camera;
    public bool IsValid => !string.IsNullOrEmpty(id) && this;

    private void Start() => RegisterCamera();

    private void OnDestroy() => UnRegisterCamera();

    void RegisterCamera()
    {
        if (!CM_CameraManager.Instance) return;

        if (!camera)
        {
            camera = GetComponent<Camera>();
            if (!camera) throw new CM_CameraManagerMissingCameraException(gameObject.name);
        }
        CM_CameraManager.Instance.AddCamera(this);
        name += "[CM]";
        InitBehaviour();
    }

    void UnRegisterCamera()
    {
        if (!CM_CameraManager.Instance) return;
        CM_CameraManager.Instance.RemoveCamera(this);
    }

    public void SwitchView(bool _enable)
    {
        if (!IsValid) return;
        camera.enabled = _enable;
    }

    void InitBehaviour()
    {
        switch (type)
        {
            case CM_CameraType.RTS:
                break;
            case CM_CameraType.TPS:
                cameraBehaviour = gameObject.AddComponent<CM_CameraTpsBehaviour>();
                fAxis = CM_CameraBehaviour.FollowVectorType.Backward;
                break;
            case CM_CameraType.FPS:
                break;
            case CM_CameraType.ROTATE_AROUND:
                cameraBehaviour = gameObject.AddComponent<CM_RotateAroundBehaviour>();
                break;
            case CM_CameraType.OSCILATE:
                cameraBehaviour = gameObject.AddComponent<CM_OscilateBehaviour>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        if (cameraBehaviour)
            cameraBehaviour.Init(behaviourSettings, camera, fAxis);
        
            
    }

    private void OnValidate()
    {
        if(!CM_CameraManager.Instance) return;
        if (enabling)
        {
            CM_CameraManager.Instance.EnableCamera(ID);
        }
        else
        {
            CM_CameraManager.Instance.DisableCamera(ID);
        }    
    }


}

[Serializable]
public class BehaviourSettings
{
    [SerializeField, Header("CameraTarget")]
    protected Transform cameraTarget;

    [SerializeField, Header("Camera Speed"), UnityEngine.Range(-10, 10)]
    protected float speed = 1;

    [SerializeField, Header("Camera distance"), UnityEngine.Range(.1f, 100f)]
    protected float distance = 10;

    [SerializeField, Header("Camera Shake")]
    protected bool shake = false;

    [SerializeField, Header("Camera Oscilation")]
    protected bool oscilation = false;


    public Transform CameraTarget => cameraTarget;
    public float CameraSpeed => speed;
    public float CameraDistance => distance;
    public bool CameraShake => shake;
    public bool CameraOscilation => oscilation;

}

public enum CM_CameraType
{
    RTS,
    TPS,
    FPS,
    ROTATE_AROUND,
    OSCILATE
}