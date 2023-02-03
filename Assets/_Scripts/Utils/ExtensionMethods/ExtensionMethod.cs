using UnityEngine;

namespace NoSurrender
{
    public static class ExtensionMethod
    {
        public static Vector3 RandomCircle(this GameObject go, Vector3 center, float radius)
		{
			float ang = Random.value * 360;
			Vector3 pos;
			pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
			pos.y = center.y;
			pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);

			return pos;
		}
	}
}
