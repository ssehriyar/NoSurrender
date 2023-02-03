using TMPro;
using UnityEngine;

namespace NoSurrender
{
	public class Player : PlayerBase
	{
		private bool _coroutine;
		[SerializeField] private int _growLimit;
		[SerializeField] private Vector3 _growAmount;
		[SerializeField] private PlayerMovement _playerMovement;
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
			_playerMovement.AddForce(dir, forceType);
		}

		public override void AddSpeed(float speedAmount, float duration)
		{
			if (_coroutine == false)
			{
				_coroutine = true;
				StartCoroutine(_playerMovement.AddSpeed(speedAmount, duration,
					callback => _coroutine = callback));
			}
		}

		public string GameScore()
		{
			return EnemyManager.Instance.YourScore(Score).ToString();
		}
	}
}
