using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Material mat;
    public Mesh mesh;

    public int maxDepth = 4;
    public float childScale;
    private int depth = 0;

    private Material[] materials;

    private static Vector3[] childDirections = 
    {Vector3.up,
    Vector3.right,
    Vector3.left,
    Vector3.forward,
    Vector3.back};
    private static Quaternion[] childRotations =
    {Quaternion.identity,
    Quaternion.Euler(0,0,-90),
    Quaternion.Euler(0,0,90),
    Quaternion.Euler(90,0,0),
    Quaternion.Euler(-90,0,0)};

    void Start()
    {
        if(materials == null)
        {
            InitializeMaterials();
        }

        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = materials[depth];


        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1];
        for(int i = 0; i <= maxDepth; i++)
        {
            float t = i / (maxDepth - 1);
            t *= t;
            materials[i] = new Material(mat);
            materials[i].color =
                Color.Lerp(Color.white, Color.yellow, t);
        }
        materials[maxDepth].color = Color.magenta;
    }

    private IEnumerator CreateChildren()
    {
        for(int i = 0; i < childDirections.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
            new GameObject("Fractal Child").AddComponent<Fractal>().
            Initialize(this, i);
        }
    }

    public void Initialize(Fractal parent, int childIndex)
    {
        mesh = parent.mesh;
        mat = parent.mat;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;

        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition =
        childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childRotations[childIndex];
    }
}
