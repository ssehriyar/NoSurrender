using System.Collections;
using UnityEngine;
using TMPro;

namespace NoSurrender
{
	public class CountdownUI : UIBase
	{
		[SerializeField] private int _countdownTime;
		[SerializeField] private TMP_Text _text;

		protected override void Start()
		{
			base.Start();
			StartCoroutine(StartCountdown());
		}

		private IEnumerator StartCountdown()
		{
			while (_countdownTime > 0)
			{
				_text.text = _countdownTime.ToString();
				yield return new WaitForSeconds(1f);
				_countdownTime--;
			}
			_text.text = "GO!";
			yield return new WaitForSeconds(0.5f);
			GameStateManager.SetState(GameState.Play);
		}
	}
}
