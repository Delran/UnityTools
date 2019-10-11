using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_InputTester : MonoBehaviour
{
    [SerializeField, Header("CameraTarget")]
    private Transform cameraTarget;
    [SerializeField, Header("Camera")]
    private Camera cam;

    private Transform cameraTransform; 

    float angle = 0;
    private void Awake()
    {
        //CM_InputManager.OnVerticalAxis += UpdateAngle;
        //cameraTransform = cam.transform;
    }

    private void Start()
    {
        Vector3 _testVec = new Vector3(0, 1, 0);
        Vector3 _testVec2 = new Vector3(1, 0, 0);
        MV_Vector3 _testMVVec = new MV_Vector3(0, 1, 0);
        MV_Vector3 _testMVVec2 = new MV_Vector3(1, 0, 0);
        //Debug.Log(_testVec);
        //Debug.Log(_testMVVec);
        //Debug.Log(_testVec[1]);
        //Debug.Log(_testMVVec[1]);
        //Debug.Log(Vector3.Angle(_testVec, _testVec2));
        //Debug.Log(MV_Vector3.Angle(_testMVVec, _testMVVec2));

    }

    private void OnDestroy()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!CM_InputManager.Instance) return;
        float a = CM_InputManager.Instance.GetVertical;
        float b = CM_InputManager.Instance.GetHorizontal;
        float c = CM_InputManager.Instance.GetMouseX;
        float d = CM_InputManager.Instance.GetMouseY;
        bool ja = CM_InputManager.Instance.GetJumpValue;
        bool jb = CM_InputManager.Instance.GetJumpValueUp;
        bool jc = CM_InputManager.Instance.GetJumpValueDown;
    }

}
