using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;
    [Range(10, 100)]
    public int Resolution = 10;

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
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            var position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}