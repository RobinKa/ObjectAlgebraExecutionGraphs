# Object Algebra Execution Graphs
Using object algebras ([original paper](https://www.cs.utexas.edu/~wcook/Drafts/2012/ecoop2012.pdf), [good introductory video](https://www.infoq.com/presentations/object-algebras/)) to create execution graphs similar to [NetPrints](https://github.com/RobinKa/netprints). The graph nodes are created by the object algebras. Object algebras are just abstract factories with type parameters for the types returned by them. These type parameters will be behaviors which are interfaces for specifying the operations possible on them. Implementations then implement these object algebras for specific behaviors, so one implementation for each combination of variant and behavior is necessary (but other ones could be reused through composition or inheritance). The advantage of this approach is that a method can be created that uses the abstract factory with type parameters instead of a concrete implementation so it can be reused with any concrete implementation of it. It allows for extending both in the "variant" plane by adding methods to the abstract factory as well as in the "behavior" plane by creating new interfaces that can be plugged into the factory type parameters later.

In this project an execution graph consists of nodes that have input / output data pins and input / output execution pins on them which can be connected to each other. Execution flows along the execution pins and data is passed along the data pins. To represent this with object algebras an abstract factory is created with type parameters for the types of the four types of pins (`(Input | Output) (Data | Execution)`) as well as the node. Interfaces are created for each of them. The basic pin interfaces do not do anything. The basic node interface holds a list of all types of pins. As an example a few methods were created on the factory to create different variants of nodes. With this basic functionality we can already write a method with the abstract factory as parameter and type parameters to go into it to construct an execution graph that will work with any concrete implementation of the factory as well as the type parameters replaced by anything (although here we restricted the node type parameter to inherit from `IExecutionNode` to allow accessing the nodes' pins, a better design without this restriction is probably possible by putting more methods on the factory).
As the graph does not have any behavior right now because its pin types don't have any methods we extend them to translate the execution graph into C#. For this the same abstract factory is used but we created new interfaces with pins and nodes that can be translated to C#. The same function used to create a graph before can now be reused with it, but its nodes can be translated to C#.
Besides the C# translation behavior there also exists a behavior and implementation for generating (DOT graphs)[https://en.wikipedia.org/wiki/DOT_(graph_description_language)] for visualization out of the same graph.

# TODO List
- Add more variants of nodes
- Add type pins to allow for generics (see [NetPrints](https://github.com/RobinKa/netprints))
- Create behavior that allows mutating the node connections
- Experiment with translating to functional languages (using only data and type pins, no execution pins)