using UnityEngine;

namespace NoSurrender
{
	public class EnemyHitDetector : MonoBehaviour
	{
		private PlayerBase _lastPlayerHit;
		[SerializeField] private Enemy _enemy;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.GetComponent<IPlay>() != null)
			{
				var player = collision.gameObject.GetComponent<PlayerBase>();
				_lastPlayerHit = player;
				if (player.Score > _enemy.Score)
				{
					_enemy.AddForce(transform.position - player.transform.position, ForceType.Medium);
				}
				else
				{
					_enemy.AddForce(transform.position - player.transform.position, ForceType.Small);
				}
			}

			if (collision.gameObject.GetComponent<DeadZone>() != null)
			{
				_lastPlayerHit?.AddScore(_enemy.Score);
				EnemyManager.Instance.DestroyEnemy(_enemy);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<ICollectable>() != null)
			{
				other.GetComponent<ICollectable>().Collect(_enemy);
			}

			if (other.GetComponent<WeakPoint>() != null)
			{
				other.GetComponent<WeakPoint>().AddForce(other.transform.position - transform.position, ForceType.Huge);
				//_enemy.AddForce(transform.position - other.transform.position, ForceType.Huge);
			}
		}
	}
}
