using System;
using System.Collections.Generic;

namespace FluentAssert
{
	public class TestGivenClause<T>
	{
		private readonly T _item;
		private readonly IList<Action<T>> _setupActionsForItem = new List<Action<T>>();

		public TestGivenClause(T item)
		{
			_item = item;
		}

		public TestWhenClause<T> When(Action<T> action)
		{
			return new TestWhenClause<T>(_item, action, _setupActionsForItem);
		}

		public TestGivenClause<T> With(Action<T> setupForItem)
		{
			_setupActionsForItem.Add(setupForItem);
			return this;
		}
	}
}