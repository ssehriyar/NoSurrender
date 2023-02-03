using TMPro;
using UnityEngine;

namespace NoSurrender
{
	public class Enemy : PlayerBase
	{
		private bool _coroutine;
		[SerializeField] private int _growLimit;
		[SerializeField] private Vector3 _growAmount;
		[SerializeField] private EnemyMovement _enemyMovement;
		[SerializeField] private TMP_Text _scoreText;

		private void Start()
		{
			_scoreText.text = Score.ToString();
		}

		public override void AddScore(int scoreAmount)
		{
			transform.localScale += _growAmount * (scoreAmount / _growLimit);
			Score += scoreAmount;
			_scoreText.text = Score.ToString();
		}

		public override void AddForce(Vector3 dir, ForceType forceType)
		{
			_enemyMovement.AddForce(dir, forceType);
		}

		public override void AddSpeed(float speedAmount, float duration)
		{
			if (_coroutine == false)
			{
				_coroutine = true;
				StartCoroutine(_enemyMovement.AddSpeed(speedAmount, duration,
					callback => _coroutine = callback));
			}
		}
	}
}
