namespace FluentAssert
{
	public static class Test
	{
		public static TestGivenClause<T> Given<T>(T actionContainer)
		{
			return new TestGivenClause<T>(actionContainer);
		}
	}
}