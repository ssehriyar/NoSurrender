using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoSurrender
{
	public class EnemyManager : Singleton<EnemyManager>
	{
		private List<Enemy> _enemies;
		[SerializeField] private int _enemyNumber;
		[SerializeField] private float _maxSpawnRadius;
		[SerializeField] private float _minSpawnRadius;
		[SerializeField] private Vector3 _spawnCenter;

		private void Awake()
		{
			Init();
		}

		private void Start()
		{
			_enemies = new List<Enemy>();
			for (int i = 0; i < _enemyNumber; i++)
			{
				CreateEnemies();
			}
		}

		private void CreateEnemies()
		{
			var go = Instantiate(
				ScriptableContainer.Instance.enemySC.enemy,
				gameObject.RandomCircle(_spawnCenter, Random.Range(_minSpawnRadius, _maxSpawnRadius)),
				Quaternion.identity,
				transform);

			_enemies.Add(go.GetComponent<Enemy>());
		}

		public void DestroyEnemy(Enemy enemy)
		{
			_enemies.Remove(enemy);
			Destroy(enemy.gameObject);
			if (_enemies.Count == 0)
			{
				GameStateManager.SetState(GameState.Win);
			}
		}

		public int YourScore(int score)
		{
			if (_enemies.Count > 0)
			{
				_enemies = _enemies.OrderByDescending(t => t.Score).ToList();
				for (int i = 0; i < _enemies.Count; i++)
				{
					if (_enemies[i].Score < score)
					{
						return (i + 1);
					}
				}
				return _enemies.Count + 1;
			}
			return 1;
		}
	}
}
