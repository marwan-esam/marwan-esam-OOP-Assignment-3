# Part 03: Generics

## Step 2
**What is the same between the two stores, and what is different?**
The logic and structure of the two stores are completely identical (the methods to add an item, loop through to find an ID, and remove an item are exactly the same). The only difference is the specific data type they operate on (`Student` vs `Course`).

## Step 3
**Compiler error and explanation:**
Error: `CS1061: 'T' does not contain a definition for 'Id'` (and returning null might fail if `T` is a value type).
The compiler rejects the code because `T` is an unconstrained generic type, meaning it could be literally any type in C# (an `int`, a `string`, a custom class). The compiler has no guarantee that whatever type `T` ends up being will actually have an `Id` property. Furthermore, if `T` is a value type (like a struct), it cannot be returned as `null`.
