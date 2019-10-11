using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PE_PathManager : MonoBehaviour
{
    [SerializeField] public List<PE_Path> AllPaths = new List<PE_Path>();

    public int NbPaths => AllPaths.Count;

    public void AddPath()
    {
        AllPaths.Add(new PE_Path());
    }
    public void RemovePath(int _i) => AllPaths.RemoveAt(_i);
    public void Clear() => AllPaths.Clear();

}

[System.Serializable]
public class PE_Path
{

    public bool ShowPaths { get; set; } = true;
    public bool ShowPoints { get; set; } = true;

    public bool IsEdit { get; set; } = false;

    [SerializeField] public string Id = "Path1";
    [SerializeField] public Color pathColor = Color.white;
    [SerializeField] public List<Vector3> PathPoints = new List<Vector3>();

    public int NbPoints => PathPoints.Count;

    public void AddPoint()
    {
        int _count = PathPoints.Count;
        if (_count < 1)
            PathPoints.Add(Vector3.zero);
        else
            PathPoints.Add(PathPoints[_count - 1] + Vector3.forward);
    }

    public void RemovePoint(int _i) => PathPoints.RemoveAt(_i);
    public void Clear() => PathPoints.Clear();
}