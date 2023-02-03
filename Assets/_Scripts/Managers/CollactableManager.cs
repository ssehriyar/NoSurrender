using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoSurrender
{
	public class CollactableManager : Singleton<CollactableManager>
	{
		private List<GameObject> _collectables;
		[SerializeField] private int _totalCollectableAmount;
		[SerializeField] private float _maxSpawnRadius;
		[SerializeField] private float _minSpawnRadius;
		[SerializeField] private Vector3 _spawnCenter;

		private void Awake()
		{
			Init();
		}

		private void Start()
		{
			_collectables = new List<GameObject>();
			for (int i = 0; i < _totalCollectableAmount; i++)
			{
				CreateCollectable();
			}
		}

		private void Update()
		{
			if (_totalCollectableAmount > _collectables.Count)
			{
				CreateCollectable();
			}
		}

		private void CreateCollectable()
		{
			var go = Instantiate(
				ScriptableContainer.Instance.collectableSC.GetRandomCollectable(),
				gameObject.RandomCircle(_spawnCenter, Random.Range(_minSpawnRadius, _maxSpawnRadius)),
				Quaternion.identity,
				transform);

			_collectables.Add(go);
		}

		public void DestroyCollectable(GameObject go)
		{
			_collectables.Remove(go);
			Destroy(go);
		}

		public GameObject GetClosestCollectable(Transform trans) =>
			_collectables
			.OrderBy(t => Vector3.Distance(trans.position, t.transform.position))
			.FirstOrDefault();

		
	}
}
