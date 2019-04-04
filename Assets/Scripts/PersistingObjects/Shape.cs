using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    public int MaterialID { get; private set; }

    public int ShapeID
    {
        get { return _shapeID; }
        set
        {
            if (_shapeID == int.MinValue && value != int.MinValue)
                _shapeID = value;
            else
                Debug.LogError("Not allowed to change shape ID!");
        }
    }
    int _shapeID = int.MinValue;

    public void SetMaterial(Material mat, int matID)
    {
        GetComponent<MeshRenderer>().material = mat;
        MaterialID = matID;
    }
}
