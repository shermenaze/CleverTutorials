using UnityEngine;

public class Graph : MonoBehaviour
{
    public GraphFunctionName function;
    [Range(10, 100)]
    public int Resolution = 10;
    public Transform PointPrefab;

    static GraphFunction[] functions =
        { SineFunction, Sine2DFunction, MultiSine2DFunction,
        MultiSineFunction, RippleFunction, CylinderFunction,
        SphereFunction};
    Transform[] points;

    private const float pi = Mathf.PI;

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[Resolution * Resolution];

        float step = 2f / Resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(PointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    private void Update()
    {
        float t = Time.time;
        GraphFunction f = functions[(int)function];

        float step = 2f / Resolution;
        for (int i = 0, z = 0; z < Resolution; z++)
        {
            float v = (z + 0.5f) * step - 1;
            for (int x = 0; x < Resolution; x++, i++)
            {
                float u = (x + 0.5f) * step - 1;
                points[i].localPosition = f(u, v, t);
            }
        }
    }

    static Vector3 SineFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.z = v;
        return p;
    }

    static Vector3 MultiSineFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(2f * pi * (u + 2f * t)) / 2f;
        p.y *= 2f / 3f;
        p.z = v;
        return p;
    }

    static Vector3 Sine2DFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(pi * (v + t));
        p.y *= 0.5f;
        p.z = v;
        return p;
    }

    static Vector3 MultiSine2DFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = 4f * Mathf.Sin(pi * (u + v + t * 0.5f));
        p.y += Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(2f * pi * (v + 2f * t)) * 0.5f;
        p.y *= 1f / 5.5f;
        p.z = v;
        return p;
    }

    static Vector3 RippleFunction(float u, float v, float t)
    {
        Vector3 p;
        float d = Mathf.Sqrt(u * u + v * v);
        p.x = u;
        p.y = Mathf.Sin(4f * pi * d - t);
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

    static Vector3 CylinderFunction(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi *(6f * u + 2f * v + t)) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 SphereFunction(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        r += Mathf.Sin(pi * (4f * v + t)) * 0.1f;
        float s = r * Mathf.Cos(pi * 0.5f * v);
        p.x = s * Mathf.Sin(pi * u);
        p.y = r * Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }
}