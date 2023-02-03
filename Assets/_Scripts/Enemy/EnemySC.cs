using UnityEngine;

namespace NoSurrender
{
	[CreateAssetMenu(fileName = "EnemySC", menuName = "Scriptables/Enemy")]
	public class EnemySC : ScriptableObject
	{
		public GameObject enemy;
		public float moveSpeed;
		public float fallSpeed;
		public float rotationDuration;
		public float smallForce;
		public float mediumForce;
		public float hugeForce;
		public float stunDuration;
		public LayerMask ground;
	}
}
