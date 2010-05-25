using System;
using System.Diagnostics;

namespace FluentAssert
{
	internal interface IParameterActionWrapper
	{
		string Description { get; }

		[DebuggerNonUserCode]
		void Setup();
	}

	internal class ParameterActionWrapper : IParameterActionWrapper
	{
		private readonly Action _setup;

		internal ParameterActionWrapper(Action setup)
		{
			_setup = setup;
		}

		[DebuggerNonUserCode]
		public void Setup()
		{
			_setup();
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}

	internal class ParameterActionWrapper<T> : IParameterActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T> _setup;

		internal ParameterActionWrapper(T actionContainer, Action<T> setup)
		{
			_actionContainer = actionContainer;
			_setup = setup;
		}

		[DebuggerNonUserCode]
		public void Setup()
		{
			_setup(_actionContainer);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}

	internal class ParameterActionWrapper<T, TContext> : IParameterActionWrapper
	{
		private readonly T _actionContainer;
		private readonly TContext _context;
		private readonly Action<T, TContext> _setup;

		internal ParameterActionWrapper(T actionContainer, TContext context, Action<T, TContext> setup)
		{
			_actionContainer = actionContainer;
			_context = context;
			_setup = setup;
		}

		[DebuggerNonUserCode]
		public void Setup()
		{
			_setup(_actionContainer, _context);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}
}