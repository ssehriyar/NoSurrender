using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace NoSurrender
{
	public class EnemyMovement : MonoBehaviour
	{
		private Vector3 _dir;
		private Transform _target;
		private float _velocity;
		private float _currentVelocity;
		private Tweener _tweener;
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private EnemySC _enemySC;

		private void Start()
		{
			_velocity = _enemySC.moveSpeed;
			GameStateManager.OnGameStateChange += StateChange;
			enabled = false;
		}

		private void Update()
		{
			if (IsGrounded())
			{
				_target = CollactableManager.Instance.GetClosestCollectable(transform).transform;
				_dir = (_target.position - transform.position).normalized;
				Move();
				Rotate();
			}
			else
			{
				_rigidbody.velocity = Vector3.down * _enemySC.fallSpeed;
			}
		}

		private void Move()
		{
			_rigidbody.velocity = _velocity * _dir;
		}

		private void Rotate()
		{
			float targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _enemySC.rotationDuration);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);
		}

		private bool IsGrounded()
		{
			if (Physics.CheckSphere(transform.position, 0.3f, _enemySC.ground))
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
					_rigidbody.AddForce(dir * _enemySC.smallForce, ForceMode.Impulse);
					break;
				case ForceType.Medium:
					_rigidbody.AddForce(dir * _enemySC.mediumForce, ForceMode.Impulse);
					break;
				case ForceType.Huge:
					_rigidbody.AddForce(dir * _enemySC.hugeForce, ForceMode.Impulse);
					break;
			}
		}

		public IEnumerator AddSpeed(float speedAmount, float duration, Action<bool> callback)
		{
			_velocity += speedAmount;
			yield return new WaitForSeconds(duration);
			_velocity -= speedAmount;
			callback(false);
		}

		public IEnumerator Stun()
		{
			enabled = false;
			if (_tweener.IsActive() == false)
			{
				_tweener = transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), _enemySC.stunDuration * 0.5f);
			}
			yield return new WaitForSeconds(_enemySC.stunDuration);
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
