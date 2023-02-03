using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

namespace NoSurrender
{
	public class PlayerMovement : MonoBehaviour
	{
		private Vector3 _input;
		private float _currentVelocity;
		private Tweener _tweener;
		[SerializeField] private Joystick _joystick;
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private float _moveSpeed;
		[SerializeField] private float _fallSpeed;
		[SerializeField] private float _rotationDuration;
		[SerializeField] private float _smallForce;
		[SerializeField] private float _mediumForce;
		[SerializeField] private float _hugeForce;
		[SerializeField] private float _stunDuration;
		[SerializeField] private LayerMask _ground;

		private void Start()
		{
			GameStateManager.OnGameStateChange += StateChange;
			enabled = false;
		}

		private void FixedUpdate()
		{
			if (IsGrounded())
			{
				_input = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
				Move();
				Rotate();
			}
			else
			{
				_rigidbody.velocity = Vector3.down * _fallSpeed;
			}
		}

		private void Move()
		{
			_rigidbody.velocity = _moveSpeed * transform.forward;
		}

		private void Rotate()
		{
			if (_joystick.Vertical != 0 && _joystick.Horizontal != 0)
			{
				float targetAngle = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _rotationDuration);
				transform.rotation = Quaternion.Euler(0f, angle, 0f);
			}
		}

		private bool IsGrounded()
		{
			if (Physics.CheckSphere(transform.position, 0.3f, _ground))
			{
				return true;
			}
			return false;
		}

		public void AddForce(Vector3 dir, ForceType forceType)
		{
			StartCoroutine(Stun());
			switch (forceType)
			{
				case ForceType.Small:
					_rigidbody.AddForce(dir * _smallForce, ForceMode.Impulse);
					break;
				case ForceType.Medium:
					_rigidbody.AddForce(dir * _mediumForce, ForceMode.Impulse);
					break;
				case ForceType.Huge:
					_rigidbody.AddForce(dir * _hugeForce, ForceMode.Impulse);
					break;
			}
		}

		public IEnumerator AddSpeed(float speedAmount, float duration, Action<bool> callback)
		{
			_moveSpeed += speedAmount;
			_rigidbody.velocity = Vector3.zero;
			yield return new WaitForSeconds(duration);
			_moveSpeed += -speedAmount;
			callback(false);
		}

		public IEnumerator Stun()
		{
			enabled = false;
			if (_tweener.IsActive() == false)
			{
				_tweener = transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), _stunDuration * 0.5f);
			}
			yield return new WaitForSeconds(_stunDuration);
			enabled = true;
		}

		private void StateChange(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Play:
					enabled = true;
					break;
				case GameState.Pause:
					enabled = false;
					break;
				case GameState.TimesUp:
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
