using UnityEngine;
using TMPro;

namespace NoSurrender
{
	public class Timer : MonoBehaviour
	{
		[SerializeField] private float _countdownTime;
		[SerializeField] private TMP_Text _text;

		private void Start()
		{
			GameStateManager.OnGameStateChange += StateChange;
			UpdateTimer(_countdownTime - 1);
			enabled = false;
		}

		private void Update()
		{
			if (_countdownTime > 0)
			{
				_countdownTime -= Time.deltaTime;
				UpdateTimer(_countdownTime);
			}
			else
			{
				_countdownTime = 0;
				GameStateManager.SetState(GameState.TimesUp);
			}
		}

		private void UpdateTimer(float currentTime)
		{
			currentTime += 1;

			float min = Mathf.FloorToInt(currentTime / 60);
			float sec = Mathf.FloorToInt(currentTime % 60);

			_text.text = string.Format("{0:00} : {1:00}", min, sec);
		}

		private void StateChange(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Countdown:
					break;
				case GameState.Play:
					enabled = true;
					break;
				case GameState.Pause:
					enabled = false;
					break;
				case GameState.Fail:
					enabled = false;
					break;
				case GameState.Win:
					enabled = false;
					break;
			}
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChange -= StateChange;
		}
	}
}
