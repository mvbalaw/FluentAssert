using System.Diagnostics;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public static class Test
	{
		public static TestGivenClause<T> Given<T>(T actionContainer)
		{
			return new TestGivenClause<T>(new ActionContainerSource<T>
				{
					GetActionContainer = () => actionContainer
				});
		}

		public static TestGivenClauseWithoutActionContainerSource<T> Given<T>()
		{
			return new TestGivenClauseWithoutActionContainerSource<T>();
		}

		public static TestGivenStaticClause Static()
		{
			return new TestGivenStaticClause();
		}
	}
}