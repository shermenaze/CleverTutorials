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

    static MaterialPropertyBlock _sharedPropertyBlock;
    private int colorPropertyID = Shader.PropertyToID("_Color");
    private Color _color;
    private int _shapeID = int.MinValue;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetMaterial(Material mat, int matID)
    {
        _meshRenderer.material = mat;
        MaterialID = matID;
    }

    public void SetColor(Color color)
    {
        _color = color;
        if(_sharedPropertyBlock == null)
        {
            _sharedPropertyBlock = new MaterialPropertyBlock();
        }
        
        _sharedPropertyBlock.SetColor(colorPropertyID, _color);
        _meshRenderer.SetPropertyBlock(_sharedPropertyBlock);
    }

    public override void Save(GameDataWriter writer)
    {
        base.Save(writer);
        writer.Write(_color);
    }

    public override void Load(GameDataReader reader)
    {
        base.Load(reader);
        SetColor(reader.Version > 0 ? reader.ReadColor() : Color.white);
    }
}
