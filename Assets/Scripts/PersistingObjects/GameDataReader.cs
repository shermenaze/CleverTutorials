using System.IO;
using UnityEngine;

public class GameDataReader
{
    public int Version { get; }
    
    BinaryReader reader;

    public GameDataReader(BinaryReader reader, int version)
    {
        this.reader = reader;
        Version = version;
    }

    public int ReadInt()
    {
        return reader.ReadInt32();
    }

    public float ReadFloat()
    {
        return reader.ReadSingle();
    }

    public Vector3 ReadVector3()
    {
        Vector3 v;

        v.x = reader.ReadSingle();
        v.y = reader.ReadSingle();
        v.z = reader.ReadSingle();

        return v;
    }

    public Quaternion ReadQuaternion()
    {
        Quaternion q;

        q.x = reader.ReadSingle();
        q.y = reader.ReadSingle();
        q.z = reader.ReadSingle();
        q.w = reader.ReadSingle();

        return q;
    }

    public Color ReadColor()
    {
        Color value;

        value.r = reader.ReadSingle();
        value.g = reader.ReadSingle();
        value.b = reader.ReadSingle();
        value.a = reader.ReadSingle();

        return value;
    }
}
