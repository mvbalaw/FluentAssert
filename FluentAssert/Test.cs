namespace FluentAssert
{
	public static class Test
	{
		public static TestDefinition<T> For<T>()
		{
			return new TestDefinition<T>();
		}
	}
}