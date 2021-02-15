Flyweight pattern is primarily used to reduce the number of objects created and to decrease memory footprint and increase performance.

Under structural pattern as this pattern provides ways to decrease object count thus improving the object structure of application.

Flyweight pattern tries to reuse already existing similar kind objects by storing them and creates new object when no matching object is found.

The client must use the Factory instead of the new operator to request objects.

The client (or a third party) must look-up or compute the non-shareable state, and supply that state to class methods.