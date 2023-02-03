using UnityEngine;

namespace NoSurrender
{
	[CreateAssetMenu(fileName = "CollectableSC", menuName = "Scriptables/CollectableSC")]
	public class CollectableSC : ScriptableObject
	{
		public GameObject[] collectables;

		public GameObject GetRandomCollectable()
		{
			if(collectables == null) return null;

			return collectables[Random.Range(0, collectables.Length)];
		}
	}
}
