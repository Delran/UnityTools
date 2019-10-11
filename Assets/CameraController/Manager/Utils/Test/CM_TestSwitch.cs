using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_TestSwitch : MonoBehaviour
{
    [SerializeField, Header("Cam id")] string id;
    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(id)) return;
        CM_CameraManager.Instance.SwitchCamera(id);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
