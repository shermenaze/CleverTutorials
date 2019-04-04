using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShapeFactory : ScriptableObject
{
    [SerializeField] private Shape[] _prefabs;
    [SerializeField] private Material[] _materials;

    public Shape GetShape(int shapeId = 0, int matID = 0)
    {
        Shape instance = Instantiate(_prefabs[shapeId]);
        instance.ShapeID = shapeId;
        instance.SetMaterial(_materials[matID], matID);
        return instance;
    }

    public Shape GetRandomShape()
    {
        return GetShape(Random.Range(0, _prefabs.Length));
    }
}