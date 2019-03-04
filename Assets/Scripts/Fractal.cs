using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Material mat;
    public Mesh mesh;

    public int maxDepth = 4;
    private int depth = 0;
    public float childScale;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = mat;

        if (depth < maxDepth)
            new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this);
    }

    public void Initialize(Fractal parent)
    {
        mesh = parent.mesh;
        mat = parent.mat;
        maxDepth = parent.maxDepth;
        childScale = parent.childScale;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = Vector3.up * (0.5f + 0.5f * childScale);
    }
}
