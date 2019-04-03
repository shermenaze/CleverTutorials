using System.Collections;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Material mat;
    public Mesh[] meshs;

    public int maxDepth = 4;
    public float childScale;
    public float spawnProbability;
    public float maxRotationSpeed;
    public float maxTwist;


    private float rotationSpeed;
    private Material[,] materials;
    private int depth = 0;

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

        gameObject.AddComponent<MeshFilter>().mesh = meshs[Random.Range(0, meshs.Length)];
        gameObject.AddComponent<MeshRenderer>().material =
            materials[depth, Random.Range(0, 2)];


        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }

        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0, 0);
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime , 0);
    }

    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1, 2];
        for(int i = 0; i <= maxDepth; i++)
        {
            float t = i / (maxDepth - 1);
            t *= t;
            materials[i, 0] = new Material(mat);
            materials[i, 0].color =
                Color.Lerp(Color.white, Color.yellow, t);
            materials[i, 1] = new Material(mat);
            materials[i, 1].color =
                Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[maxDepth, 0].color = Color.magenta;
        materials[maxDepth, 1].color = Color.red;
    }

    private IEnumerator CreateChildren()
    {
        for(int i = 0; i < childDirections.Length; i++)
        {
            if (Random.value < spawnProbability)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<Fractal>().
                Initialize(this, i);
            }
        }
    }

    public void Initialize(Fractal parent, int childIndex)
    {
        meshs = parent.meshs;
        mat = parent.mat;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        spawnProbability = parent.spawnProbability;
        maxRotationSpeed = parent.maxRotationSpeed;
        maxTwist = parent.maxTwist;

        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition =
        childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childRotations[childIndex];
    }
}
