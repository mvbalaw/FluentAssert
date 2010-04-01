namespace FluentAssert
{
	public static class Test
	{
		public static TestDefinition<T> For<T>()
		{
			return new TestDefinition<T>();
		}

		public static TestGivenClause<T> Given<T>(T item)
		{
			return new TestGivenClause<T>(item);
		}
	}
}