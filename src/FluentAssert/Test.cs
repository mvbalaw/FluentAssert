using System.Diagnostics;

namespace FluentAssert
{
	public static class Test
	{
		[DebuggerNonUserCode]
		public static TestGivenClause<T> Given<T>(T actionContainer)
		{
			return new TestGivenClause<T>(new ActionContainerSource<T>
				{
					GetActionContainer = () => actionContainer
				});
		}

		[DebuggerNonUserCode]
		public static TestGivenClauseWithoutActionContainerSource<T> Given<T>()
		{
			return new TestGivenClauseWithoutActionContainerSource<T>();
		}

		[DebuggerNonUserCode]
		public static TestGivenStaticClause Static()
		{
			return new TestGivenStaticClause();
		}
	}
}