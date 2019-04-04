using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : PersistableObject
{
    public PersistentStorage storage;
    public ShapeFactory ShapeFactory;
    public KeyCode CreateKey = KeyCode.C;
    public KeyCode NewGameKey = KeyCode.N;
    public KeyCode SaveGameKey = KeyCode.S;
    public KeyCode LoadGameKey = KeyCode.L;
    List<Shape> _shapes;

    private string savePath;
    private const int saveVersion = 1;

    private void Awake()
    {
        _shapes = new List<Shape>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(CreateKey))
            CreateObject();
        else if (Input.GetKeyDown(NewGameKey))
            StartNewGame();
        else if (Input.GetKeyDown(SaveGameKey))
            storage.Save(this);
        else if (Input.GetKeyDown(LoadGameKey))
            storage.Load(this);
    }

    private void StartNewGame()
    {
        for (int i = 0; i < _shapes.Count; i++)
        {
            Destroy(_shapes[i].gameObject);
        }

        _shapes.Clear();
    }

    void CreateObject()
    {
        Shape instance = ShapeFactory.GetRandomShape();
        Transform t = instance.transform;
        t.localPosition = Random.insideUnitSphere * 5;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1);
        _shapes.Add(instance);
    }

    public override void Save(GameDataWriter writer)
    {
        writer.Write(-saveVersion);
        writer.Write(_shapes.Count);

        for (int i = 0; i < _shapes.Count; i++)
        {
            writer.Write(_shapes[i].ShapeID);
            _shapes[i].Save(writer);
        }
    }

    public override void Load(GameDataReader reader)
    {
        int version = -reader.ReadInt();
        if (version > saveVersion)
        {
            Debug.LogError("Unsupported save version: " + version);
            return;
        }

        int count = version <= 0 ? -version : reader.ReadInt();

        for (int i = 0; i < count; i++)
        {
            int shapeId = version > 0 ? reader.ReadInt() : 0;
            Shape instance = ShapeFactory.GetShape(shapeId);
            instance.Load(reader);
            _shapes.Add(instance);
        }
    }
}
