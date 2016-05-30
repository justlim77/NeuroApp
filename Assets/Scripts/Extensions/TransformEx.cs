using UnityEngine;
using System.Collections;

public static class TransformEx {
    /// <summary>
    /// Clears all children under this Transform.
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static Transform Clear(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        return transform;
    }
}
