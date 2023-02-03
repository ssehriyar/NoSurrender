using UnityEngine;

namespace NoSurrender
{
	public class PlayerHitDetector : MonoBehaviour
	{
		private PlayerBase _lastPlayerHit;
		[SerializeField] private Player _player;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.GetComponent<Enemy>() != null)
			{
				var enemy = collision.gameObject.GetComponent<PlayerBase>();
				_lastPlayerHit = enemy;
				if (_player.Score < enemy.Score)
				{
					_player.AddForce(transform.position - enemy.transform.position, ForceType.Medium);
				}
				else
				{
					_player.AddForce(transform.position - enemy.transform.position, ForceType.Small);
				}
			}

			if (collision.gameObject.GetComponent<DeadZone>() != null)
			{
				_lastPlayerHit?.AddScore(_player.Score);
				GameStateManager.SetState(GameState.Fail);
				Destroy(gameObject);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<ICollectable>() != null)
			{
				other.GetComponent<ICollectable>().Collect(_player);
			}

			if (other.GetComponent<WeakPoint>() != null)
			{
				other.GetComponent<WeakPoint>().AddForce(other.transform.position - transform.position, ForceType.Huge);
				//_player.AddForce(transform.position - other.transform.position, ForceType.Huge);
			}
		}
	}
}
