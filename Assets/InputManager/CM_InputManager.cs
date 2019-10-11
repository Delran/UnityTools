using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.PlayerLoop;

public class CM_InputManager : MonoBehaviour
{
    #region f/p

    private static CM_InputManager instance = null;

    public static CM_InputManager Instance => instance;

    #endregion


    #region input
    [SerializeField, Header("Jump input")] KeyCode jumpValue = KeyCode.Space;
    [SerializeField, Header("Jump feedback")] bool jumpPressed;
    public bool GetJumpValue => jumpPressed = Input.GetKey(jumpValue);
    public bool GetJumpValueUp => jumpPressed = Input.GetKeyUp(jumpValue);
    public bool GetJumpValueDown => jumpPressed = Input.GetKeyDown(jumpValue);
    #endregion


    #region inupt axis
    [SerializeField, Header("Vertical Axis")] string vAxis = "Vertical";
    [SerializeField, Header("Feedback vAxis"), Range(-1, 1)] float vAxisValue;
    [SerializeField, Header("Horizontal Axis")] string hAxis = "Horizontal";
    [SerializeField, Header("Feedback hAxis"), Range(-1, 1)] float hAxisValue;
    [SerializeField, Header("Mouse X Axis")] string  xAxis = "Mouse X";
    [SerializeField, Header("Feedback Mouse X")] float xMouseValue;
    [SerializeField, Header("Mouse Y Axis")] string yAxis = "Mouse Y";
    [SerializeField, Header("Feedback Mouse X")] float yMouseValue;

    
    public float GetVertical => vAxisValue = Input.GetAxis(vAxis);
    public float GetHorizontal => hAxisValue = Input.GetAxis(hAxis);
    public float GetMouseX => xMouseValue = Input.GetAxis(xAxis);
    public float GetMouseY => yMouseValue = Input.GetAxis(yAxis);
    #endregion

    #region events
    public static event Action<float> OnVerticalAxis = null;
    #endregion


    #region debug
    #if UNITY_EDITOR
    [SerializeField, Header("Debug Color")] Color color = Color.white;
    [SerializeField, Header("Debug Height"), Range(0.1f,1)] float height = 1;
    [SerializeField, Header("Debug Size"), Range(0.1f,10)] float size = 1;
    #endif
    #endregion

    #region unity methods

    private void Awake()
    {
        InitSingleton();
    }


    private void Update()
    {
        OnVerticalAxis?.Invoke(GetVertical);
    }
    #endregion


    #region custom methods
    private void InitSingleton()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject.GetComponent<CM_InputManager>());
            return;
        }
        instance = this;
        name += "[CM_InputManager]";
        DontDestroyOnLoad(this);
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position +Vector3.up * height, size);
    }
}
