using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : PersistableObject
{
    public PersistentStorage storage;
    public PersistableObject prefab;
    public KeyCode CreateKey = KeyCode.C;
    public KeyCode NewGameKey = KeyCode.N;
    public KeyCode SaveGameKey = KeyCode.S;
    public KeyCode LoadGameKey = KeyCode.L;
    List<PersistableObject> objects;

    private string savePath;

    private void Awake()
    {
        objects = new List<PersistableObject>();
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
        for (int i = 0; i < objects.Count; i++)
        {
            Destroy(objects[i].gameObject);
        }

        objects.Clear();
    }

    void CreateObject()
    {
        PersistableObject o = Instantiate(prefab);
        Transform t = o.transform;
        t.localPosition = Random.insideUnitSphere * 5;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1);
        objects.Add(o);
    }

    public void Save(GameDataWriter writer)
    {
        writer.Write(objects.Count);

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].Save(writer);
        }
    }
}
