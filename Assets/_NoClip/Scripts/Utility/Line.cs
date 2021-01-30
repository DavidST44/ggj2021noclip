using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    private readonly float[] distances;
    private Vector2[] points;
    private readonly float length;

    public Line(params Vector2[] ps)
    {
        distances = new float[ps.Length];
        points = ps;
        distances[0] = 0;
        for (int i = 1; i < points.Length; i++)
        {
            length += (points[i] - points[i - 1]).magnitude;
            distances[i] = length;
        }
    }

    public Vector2 GetNormalisedPoint(float n, Vector2 offset = default)
    {
        n = Mathf.Clamp01(n);
        float t = length * n;
        int i = 1;
        while (t > distances[i])
        {
            ++i;
        }

        Vector2 s = (points[i] - points[i - 1]).normalized;
        float sd = t - distances[i - 1];
        return points[i - 1] + s * sd + offset;
    }
}
