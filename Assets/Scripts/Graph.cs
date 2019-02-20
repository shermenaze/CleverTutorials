using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 scale = Vector3.one / 5f;
        Vector3 position = Vector3.zero;

        for (int i = 0; i < 10; i++)
        {
            var point = Instantiate(PointPrefab);
            position.x = (i + 0.5f) / 5f - 1f;
            position.y = position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    }
}