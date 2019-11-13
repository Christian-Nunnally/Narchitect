
Support updating the image?

use href to add ngsource links?

add cardinality support

find places where objects are created via new. I do not think we need to look for factory object creation unless we care about object lifecycle.

Extensibility points:

- `IDependencyAnalyzer` - To add a new strategy for finding dependencies.
- `IDependencyFilterer` - To add a new strategy for filtering dependencies out of the view.
- `ISyntaxParsingStrategy` - To create a strategy used by `SyntaxTreeParser` to examine a particular kind of syntax node within a tree.

