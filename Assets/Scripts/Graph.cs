using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [Range(0, 1)]
    public int function;
    [Range(10, 100)]
    public int Resolution = 10;
    public Transform PointPrefab;

    Transform[] points;

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[Resolution];

        float step = 2f / Resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        for (int i = 0; i < points.Length; i++)
        {
            var point = Instantiate(PointPrefab);
            points[i] = point;

            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;

            point.SetParent(transform, false);
        }
    }

    private void Update()
    {
        float t = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            if (function == 0)
            {
                position.y = SineFunction(position.x, t);
            }
            else
            {
                position.y = MultiSineFunction(position.x, t);
            }
            point.localPosition = position;
        }
    }

    static float SineFunction(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    static float MultiSineFunction(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }
}