# Part 02: Collections & Extension Methods

## Task 2.1 — Research: IReadOnlyDictionary & SortedDictionary

**IReadOnlyDictionary vs Dictionary:**
`IReadOnlyDictionary` is a generic collection that stores key-value pairs but doesn't allow modifications, unlike an ordinary `Dictionary`. A public method would return an `IReadOnlyDictionary` if it wants to prevent outer modifications to the dictionary, choosing to preserve and maintain it internally. This allows the class to enforce encapsulation and validation.

**SortedDictionary vs Dictionary:**
A `SortedDictionary` differs from an ordinary `Dictionary` in that it automatically sorts key-value pairs by their keys, whereas a regular `Dictionary` does not preserve order. 

**Lookup Speed:**
Regarding lookup speed, a `SortedDictionary` takes logarithmic time (O(log n)) because it uses a binary search tree (specifically a red-black tree) data structure. An ordinary `Dictionary` uses arrays with hashing functions that provide constant (O(1)) lookup operations. 

**When to choose SortedDictionary:**
You would choose a `SortedDictionary` when you need to frequently iterate over the elements in a sorted order, and you are willing to trade off the faster O(1) lookup speed of a regular `Dictionary` for that automatic sorting.

## Task 2.2 — Pick the Collection

- **S1:** `Dictionary` — It provides constant O(1) time lookups which is necessary for searching thousands of times a day.
- **S2:** `HashSet` — It provides constant time insertions and lookups, and automatically prevents duplicate tags.
- **S3:** `List` — It preserves the exact order the grades were entered and allows duplicate values.
- **S4:** `IReadOnlyDictionary` — It maps courses to prices (key-value) and prevents callers from adding or changing any of the prices.
- **S5:** `SortedDictionary` — It automatically sorts the sessions by their start time (the key) as they are added.
- **S6:** `IEnumerable` — It allows the use of `yield return` (lazy evaluation) so the caller can loop over it and stop early without generating all results.
