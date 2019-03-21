using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public static class Utility
    {
        public static List<Vector3> Points(this Bounds bounds)
        {
            List<Vector3> corners = new List<Vector3>();
            corners.Add(bounds.center);
            corners.Add(bounds.min);
            corners.Add(bounds.max);
            corners.Add(new Vector3(bounds.min.x, bounds.max.y, bounds.max.z));
            corners.Add(new Vector3(bounds.min.x, bounds.min.y, bounds.max.z));
            corners.Add(new Vector3(bounds.min.x, bounds.max.y, bounds.min.z));
            corners.Add(new Vector3(bounds.max.x, bounds.min.y, bounds.min.z));
            corners.Add(new Vector3(bounds.max.x, bounds.min.y, bounds.max.z));
            corners.Add(new Vector3(bounds.max.x, bounds.max.y, bounds.min.z));
            return corners;
        }
    }
}