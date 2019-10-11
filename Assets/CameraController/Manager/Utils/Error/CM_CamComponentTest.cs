using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CamComponentTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetDelay(float _t)
    {
        Debug.Log("Files Loading");
        yield return new WaitForSeconds(_t);
        bool _cond = false;
        while(_cond)
        {
            yield return null;
        }
        Debug.Log("ok");
        yield break;
    }
}
