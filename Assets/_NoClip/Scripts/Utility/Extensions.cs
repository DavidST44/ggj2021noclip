using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions
{
    public static string Col(this string s, Color32 color)
    {
        string hex = ColorUtility.ToHtmlStringRGB(color);
        return string.Format("<color=#{0}>{1}</color>", hex, s);
    }

    public static string Red(this string s)
    {
        return s.Col(Color.red);
    }
}

public static class ColorExtensions
{
    public static Color Mix(this Color a, Color b, float t = 0.5f)
    {
        return Color.Lerp(a, b, t);
    }

    public static Color WithAlpha(this Color c, float alpha)
    {
        return new Color(c.r, c.g, c.b, alpha);
    }

    public static Color NudgeHSV(this Color c, float hue, float sat, float val)
    {
        Color.RGBToHSV(c, out float h, out float s, out float v);
        h = (h + hue) % 1f;
        s += sat;
        v += val;
        return Color.HSVToRGB(h, s, v);
    }
}

public static class AudioSourceExtensions
{
    public static void RandomPitch(this AudioSource audioSource, float min, float max)
    {
        audioSource.pitch = Random.Range(min, max);
    }

    public static void PitchedOneShot(this AudioSource audioSource, AudioClip audioClip, float minPitch = 0.8f, float maxPitch = 1f, float volumeScale = 1f)
    {
        if (audioClip)
        {
            audioSource.RandomPitch(minPitch, maxPitch);
            audioSource.PlayOneShot(audioClip, volumeScale);
        }
    }
}

public static class ArrayExtensions
{
    private static System.Random rng = new System.Random();

    public static T GetRandomElement<T>(this IList<T> array, int from, int to)
    {
        if (array.Count == 1)
            return array[0];
        if (array.Count == 0)
            return default;
        return array[Random.Range(from, to)];
    }

    public static T GetRandomElement<T>(this IList<T> array)
    {
        return array.GetRandomElement(0, array.Count);
    }

    public static bool IsNullOrEmpty(this ICollection collection)
    {
        return collection == null || collection.Count == 0;
    }

    public static void Fill<T>(this T[] array, T v)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = v;
        }
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static int CountAll<T>(this IList<T> list, System.Predicate<T> match)
    {
        int count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (match(list[i]) == false)
                continue;
            ++count;
        }
        return count;
    }

    public static void RemoveFinal<T>(this IList<T> list)
    {
        list.RemoveAt(list.Count - 1);
    }
}

public static class VectorExtensions
{
    public static Vector2 XY(this Vector3 point)
    {
        return point;
    }
    public static Vector3 XYZ(this Vector2 point)
    {
        return point;
    }
    public static void MoveToFacePoint(this Transform transform, Vector3 point, float speed)
    {
        float targetAngleDeg = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0f, 0f, targetAngleDeg), speed);
    }
    public static void MoveToFaceDirection(this Transform transform, Vector3 direction, float speed)
    {
        transform.MoveToFacePoint(transform.position + direction, speed);
    }
    public static void LerpToFacePoint(this Transform transform, Vector3 point, float speed)
    {
        float targetAngleDeg = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, targetAngleDeg), speed);
    }
    public static void LerpToFaceDirection(this Transform transform, Vector3 direction, float speed)
    {
        transform.LerpToFacePoint(transform.position + direction, speed);
    }

    public static void RollToPoint(this Transform t, Vector2 point, float strength)
    {
        float rollDeg = Vector3.SignedAngle((point - t.position.XY()).normalized, t.up, Vector3.forward);
        t.transform.Rotate(Vector3.up, -rollDeg * strength);
    }
    public static void RollToDirection(this Transform t, Vector2 direction, float strength)
    {
        t.RollToPoint(t.position.XY() + direction, strength);
    }

    public static void FacePoint(this Transform transform, Vector2 point)
    {
        float angleRad = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x);
        float angleDeg = angleRad * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
    }

    public static void FaceDirection(this Transform transform, Vector3 direction)
    {
        transform.FacePoint(transform.position + direction);
    }

    public static float FullAngle(Vector2 a, Vector2 b)
    {
        float signedAngle = Vector2.SignedAngle(a, b);
        if (signedAngle < 0)
        {
            return 360f - Mathf.Abs(signedAngle);
        }
        return signedAngle;
    }
}

public static class Rigidbody2DExtensions
{
    public static bool HasVelocity(this Rigidbody2D rb)
    {
        return Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0;
    }
}
