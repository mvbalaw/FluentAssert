namespace FluentAssert
{
	public class TestDefinition<T>
	{
		public TestGivenClause<T> Given(T item)
		{
			return new TestGivenClause<T>(item);
		}
	}
}