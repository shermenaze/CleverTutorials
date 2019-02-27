using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public GraphFunctionName function;
    [Range(10, 100)]
    public int Resolution = 10;
    public Transform PointPrefab;

    static GraphFunction[] functions =
        { SineFunction, MultiSineFunction };
    Transform[] points;

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[Resolution * Resolution];

        float step = 2f / Resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        for (int i = 0, z = 0; z < Resolution; z++)
        {
            for (int x = 0; x < points.Length; x++, i++)
            {
                var point = Instantiate(PointPrefab);
                points[i] = point;

                position.x = (x + 0.5f) * step - 1f;
                position.z = (z + 0.5f) * step - 1f;
                point.localPosition = position;
                point.localScale = scale;

                point.SetParent(transform, false);
            }
        }
    }

    private void Update()
    {
        float t = Time.time;
        GraphFunction f = functions[(int)function];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = f(position.x, position.z, t);
            point.localPosition = position;
        }
    }

    static float SineFunction(float x, float z, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    static float MultiSineFunction(float x, float z, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }
}