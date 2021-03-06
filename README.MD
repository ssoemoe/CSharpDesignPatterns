# C# Design Patterns  

# Gang of Four 23 Design Patterns  
Practicing 23 Gang of Four object oriented design patterns.   
Some of the design patterns (such as Adapter design pattern) are less relevant for modern web applications.   
## Creational Design Patterns   
1. Factory Method  - conditionally produces an object using polymorphism   
2. Abstract Factory Method - includes multiple factory methods in an abstract class  
3. Singleton - thread-safe single self-contained instance is shared across the program  
4. Builder - A director controls the builder to build various products of the similar construction process  
5. Prototype - A prototype (a new instance with the same properties) can be easily created (can be done with ICloneable interface) without affecting the original object when changes are made to the cloned object.   

## Structural Design Patterns  
1. Decorator - used as an alternative for subclassing/inheritance when inhertiance heirarchy becomes complicated and needs multiple layers.   
2. Adapter - used to make two incompatible systems work together. There are two types of adapter design patterns - object adapter and class adapter design patterns.   
3. Facade - executes the methods of multiple subsystems. Facade class is just an executor class of multiple systems for the client.   
4. Bridge - decouples but bridge the abstraction and implementation of classes with different purposes.  
5. Composite - builds a hierarchy tree which treats each node as a composite object and contains leaves.   
6. Proxy - proxy means "on behalf of". Three types of proxies - virtual (for expensive object creation. Creates objects only for the first time), remote (local representation for remote addresses) and protection (used for security purposes)    
7. Flyweight - factory pattern which returns the same reference if the same product type with the same properties is requested and already created. Intrinsic state and extrinsic states are necessary to be determined first.    

# Other Popular C# Design Patterns  
Other than the above 23 design patterns, there are some useful misc design patterns in OOP.  
1. Fluent interface design - Method chaining is the most popular. The design is also used in LINQ queries.  