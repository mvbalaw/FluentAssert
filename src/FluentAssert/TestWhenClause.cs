using System;
using System.Collections.Generic;

namespace FluentAssert
{
	public class TestWhenClause<T>
	{
		private readonly Action<T> _action;
		private readonly IList<Action<T>> _assertions = new List<Action<T>>();
		private readonly T _item;
		private readonly IList<Action<T>> _setupActionsForItem;

		public TestWhenClause(T item, Action<T> action, IList<Action<T>> setupActionsForItem)
		{
			_item = item;
			_action = action;
			_setupActionsForItem = setupActionsForItem;
		}

		public TestWhenClause<T> Should(Action<T> verify)
		{
			_assertions.Add(verify);
			return this;
		}

		public void Verify()
		{
			foreach (var arrange in _setupActionsForItem)
			{
				arrange(_item);
			}

			_action(_item);

			foreach (var assert in _assertions)
			{
				assert(_item);
			}
		}
	}
}