using UnityEngine;

public class CM_MathTools
{
    public static Vector3 Lerp(Vector3 _v0, Vector3 _v1, float _t)
    {
        return (1 - _t) *_v0 +_t * _v1;
    }

    public static Vector3 GetNormalize(Vector3 _v)
    {
        if (_v == Vector3.zero) return Vector3.zero;
        float _mag = GetMagnitude(_v);
        float _x = _v.x / _mag;
        float _y = _v.y / _mag;
        float _z = _v.z / _mag;
        return new Vector3(_x, _y, _z);
    }

    public static float GetMagnitude(Vector3 _v)
    {
        float _x = _v.x;
        float _y = _v.y;
        float _z = _v.z;
        return Mathf.Sqrt(_x*_x + _y*_y + _z*_z);
    }

    public static Vector3 GetVector3Substract(Vector3 _a, Vector3 _b)
    {
        return new Vector3(_a.x - _b.x, _a.y - _b.y, _a.z - _b.z);
    }

    public static Vector3 GetVector3CrossProduct(Vector3 _a, Vector3 _b)
    {
        float _x = _a.y * _b.z - _a.z * _b.y;
        float _y = _a.z * _b.x - _a.x * _b.z;
        float _z = _a.x * _b.y - _a.y * _b.x;
        return new Vector3(_x, _y, _z);
    }

    public static Vector3 GetRotateAround(Vector3 _target, float _range, ref float _angle, float _speed, float _time, float _y = 0)
    {
        _angle += _time * _speed;
        _angle = _angle % 360;
        float _x = Mathf.Cos(_angle) * _range;
        float _z = Mathf.Sin(_angle) * _range;
        return _target + new Vector3(_x, _y, _z);
    }

    public static Vector3 GetRotateAround(Vector3 _target, float _range, float _angle, float _y = 0)
    {

        //_angle += _time * _speed;
        //_angle = _angle % 360;
        float _x = Mathf.Cos(_angle) * _range;
        float _z = Mathf.Sin(_angle) * _range;
        return _target + new Vector3(_x, _y, _z);
    }

    public static Vector3 GetOscilation(Vector3 _pos, float _range, ref float _delta, float _speed, float _time)
    {
        _delta += _time * 10;
        _delta = _delta % (Mathf.PI*2);
        float _y = Mathf.Cos(_delta);
        //Debug.Log(_y);
        return _pos + new Vector3(0, _y, 0);
    }

    public static float FromRadiansToDegrees(float _rad)
    {
        return _rad * 180 / Mathf.PI;
    }

    public static float FromDegreesToRadians(float _degrees)
    {
        return _degrees / 180 / Mathf.PI;
    }

    public void test ()
    {
        MV_Vector3 vec = new MV_Vector3(1, 1, 1);

        Vector3 test = vec;
    }
}
