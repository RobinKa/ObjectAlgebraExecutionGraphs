﻿using ObjectAlgebraExecutionGraphs.Behaviors.ExecutionGraph;

namespace ObjectAlgebraExecutionGraphs.Behaviors.CSharpTranslatableGraph
{
    public interface ICSharpTranslatableInputDataPin : IInputDataPin
    {
        /// <summary>
        /// Name of the pin's variable in code.
        /// </summary>
        string VariableName { get; }
    }
}
