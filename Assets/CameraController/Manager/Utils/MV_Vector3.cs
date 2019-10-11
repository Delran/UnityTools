using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MV_Vector3
{

    private float x;
    private float y;
    private float z;
    public float magnitude { get; private set; }
    public float sqrtMagnitude { get; private set; }

   

    public float X
    {
        get { return x; }
        set { x = value; }
    }
    public float Y
    {
        get { return y; }
        set { y = value; }
    }
    public float Z
    {
        get { return z; }
        set { z = value; }
    }

    public MV_Vector3(float _x, float _y, float _z = 0)
    {
        x = _x;
        y = _y;
        z = _z;
        magnitude = x * x + y * y + z * z;
        sqrtMagnitude = Mathf.Sqrt(magnitude);
    }


    #region MathFunctions

    public void Scale(MV_Vector3 _v)
    {
        x *= _v.x;
        y *= _v.y;
        z *= _v.z;
    }

    public float this[int index]
    {
        get
        {
            switch(index)
            {
                case 0:
                    return this.x;
                case 1:
                    return this.y;
                case 2:
                    return this.z;
                default:
                    return 0;
            }
        }
        set
        {
            switch(index)
            {
                case 0:
                    this.x = value;
                    break;
                case 1:
                    this.y = value;
                    break;
                case 2:
                    this.z = value;
                    break;
            }
        }
    }

    public MV_Vector3 Normalize()
    {
        return new MV_Vector3(x/magnitude, y / magnitude, z / magnitude);
    }

    public MV_Vector3 Cross(MV_Vector3 _a)
    {
        float _x = _a.y * z - _a.z * y;
        float _y = _a.z * x - _a.x * z;
        float _z = _a.x * y - _a.y * x;
        return new MV_Vector3(_x, _y, _z);
    }

    public float Dot(MV_Vector3 _a)
    {
        return _a.x * this.x + _a.y * this.y + _a.z * this.z;
    }
    #endregion

    #region StaticFunctions
    public static MV_Vector3 GetNormalize(MV_Vector3 _v)
    {
        float _mag = GetMagnitude(_v);
        float _x = _v.x / _mag;
        float _y = _v.y / _mag;
        float _z = _v.z / _mag;
        return new MV_Vector3(_x, _y, _z);
    }

    public static MV_Vector3 GetCross(MV_Vector3 _a, MV_Vector3 _b)
    {
        float _x = _a.y * _b.z - _a.z * _b.y;
        float _y = _a.z * _b.x - _a.x * _b.z;
        float _z = _a.x * _b.y - _a.y * _b.x;
        return new MV_Vector3(_x, _y, _z);
    }

    public static float GetMagnitude(MV_Vector3 _v)
    {
        float _x = _v.x;
        float _y = _v.y;
        float _z = _v.z;
        return Mathf.Sqrt(_x * _x + _y * _y + _z * _z);
    }

    public static MV_Vector3 GetScaled(MV_Vector3 _a, MV_Vector3 _b)
    {
        return new MV_Vector3(_a.X * _b.X, _a.Y * _b.Y, _a.Z * _b.Z);
    }

    public static MV_Vector3 Max(MV_Vector3 a, MV_Vector3 b)
    {
        float _x = a.x > b.x ? a.x : b.x;
        float _y = a.y > b.y ? a.y : b.y;
        float _z = a.z > b.z ? a.z : b.z;
        return new MV_Vector3(_x, _y, _z);
    }

    public static MV_Vector3 Min(MV_Vector3 a, MV_Vector3 b)
    {
        float _x = a.x < b.x ? a.x : b.x;
        float _y = a.y < b.y ? a.y : b.y;
        float _z = a.z < b.z ? a.z : b.z;
        return new MV_Vector3(_x, _y, _z);
    }

    public static float Dot(MV_Vector3 _a, MV_Vector3 _b)
    {
        return _a.x* _b.x + _a.y * _b.y + _a.z * _b.z;
    }

    public static float Angle(MV_Vector3 _a, MV_Vector3 _b)
    {
        return CM_MathTools.FromRadiansToDegrees(Mathf.Acos(Dot(_a,_b)/GetMagnitude(_a)*GetMagnitude(_b)));
    }

    public override string ToString()
    {
        return $"({this.x},{this.y},{this.z})";
    }


    //
    // Summary:
    //     Shorthand for writing MV_Vector3(0, 0, 0).
    public static MV_Vector3 zero { get; } = new MV_Vector3(0, 0, 0);

    // Summary:
    //     Shorthand for writing MV_Vector3(1, 1, 1).
    public static MV_Vector3 one { get; } = new MV_Vector3(1, 1, 1);
    //
    // Summary:
    //     Shorthand for writing MV_Vector3(0, 0, 1).
    public static MV_Vector3 forward { get; } = new MV_Vector3(0, 0, 1);
    //
    // Summary:
    //     Shorthand for writing MV_Vector3(0, 0, -1).
    public static MV_Vector3 back { get; } = new MV_Vector3(0, 0, -1);
    //
    // Summary:
    //     Shorthand for writing MV_Vector3(1, 0, 0).
    public static MV_Vector3 right { get; } = new MV_Vector3(1, 0, 0);
    //
    // Summary:
    //     Shorthand for writing MV_Vector3(0, -1, 0).
    public static MV_Vector3 down { get; } = new MV_Vector3(0, -1, 0);
    //
    // Summary:
    //     Shorthand for writing MV_Vector3(-1, 0, 0).
    public static MV_Vector3 left { get; } = new MV_Vector3(-1, 0, 0);
    //
    // Summary:
    //     Shorthand for writing MV_Vector3(0, 1, 0).
    public static MV_Vector3 up { get; } = new MV_Vector3(0, 1, 0);


    public override bool Equals(object other)
    {
        MV_Vector3 _casted = (MV_Vector3)other;
        float _x = _casted.X;
        float _y = _casted.Y;
        float _z = _casted.Z;
        return x == _x && y == _y && z == _z;
    }

    //public override int GetHashCode()
    //{

    //}
    #endregion

    #region Operators
    public static MV_Vector3 operator +(MV_Vector3 a, MV_Vector3 b)
    {
        return new MV_Vector3((a.x + b.x), (a.y + b.y), (a.z + b.z));
    }
    public static MV_Vector3 operator -(MV_Vector3 a, MV_Vector3 b)
    {
        return new MV_Vector3((a.x - b.x), (a.y - b.y), (a.z - b.z));
    }
    public static MV_Vector3 operator -(MV_Vector3 a)
    {
        return new MV_Vector3(0,0,0) - a;
    }
    public static MV_Vector3 operator *(MV_Vector3 a, float d)
    {
        return new MV_Vector3((a.x * d), (a.y * d), (a.z * d));
    }
    public static MV_Vector3 operator *(float d, MV_Vector3 a)
    {
        return new MV_Vector3((a.x * d), (a.y * d), (a.z * d));
    }
    public static MV_Vector3 operator /(MV_Vector3 a, float d)
    {
        return new MV_Vector3((a.x / d), (a.y / d), (a.z / d));
    }
    public static bool operator ==(MV_Vector3 a, MV_Vector3 b)
    {
        return ((a.x == b.x) && (a.y == b.y) && (a.z == b.z));
    }
    public static bool operator !=(MV_Vector3 a, MV_Vector3 b)
    {
        return ((a.x != b.x) || (a.y != b.y) || (a.z != b.z));
    }

    public static implicit operator MV_Vector3(Vector3 a)
    {
        return new MV_Vector3(a.x, a.y, a.z);
    }
    public static implicit operator Vector3(MV_Vector3 a)
    {
        return new Vector3(a.x, a.y, a.z);
    }
    #endregion
}
