using System;
using System.Collections.Generic;

namespace FluentAssert
{
	public class TestWhenClause<T>
	{
		private readonly Action<T> _action;
		private readonly T _item;
		private readonly List<Action<T>> _setupActionsForItem;
		private readonly List<Action<T>> _verificationActions = new List<Action<T>>();

		public TestWhenClause(T item, Action<T> action, List<Action<T>> setupActionsForItem)
		{
			_item = item;
			_action = action;
			_setupActionsForItem = setupActionsForItem;
		}

		public TestWhenClause<T> Should(Action<T> verify)
		{
			_verificationActions.Add(verify);
			return this;
		}

		public void Verify()
		{
			foreach (var setupItem in _setupActionsForItem)
			{
				setupItem(_item);
			}

			_action(_item);

			foreach (var verify in _verificationActions)
			{
				verify(_item);
			}
		}
	}
}