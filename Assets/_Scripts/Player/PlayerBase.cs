using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NoSurrender
{
	public abstract class PlayerBase : MonoBehaviour, IPlay
	{
		public int Score { get; protected set; }

		public virtual void AddForce(Vector3 dir, ForceType forceType)
		{

		}

		public virtual void AddScore(int scoreAmount)
		{

		}

		public virtual void AddSpeed(float speedAmount, float duration)
		{

		}
	}
}
