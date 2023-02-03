using System;
using UnityEngine;

namespace NoSurrender
{
	public interface ICollectable
	{
		void Collect(IPlay player);
	}
}
