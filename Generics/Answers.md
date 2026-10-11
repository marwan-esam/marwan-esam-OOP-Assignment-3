# Part 03: Generics

## Step 2
**What is the same between the two stores, and what is different?**
The logic and structure of the two stores are completely identical (the methods to add an item, loop through to find an ID, and remove an item are exactly the same). The only difference is the specific data type they operate on (`Student` vs `Course`).

## Step 3
**Compiler error and explanation:**
Error: `CS1061: 'T' does not contain a definition for 'Id'` (and returning null might fail if `T` is a value type).
The compiler rejects the code because `T` is an unconstrained generic type, meaning it could be literally any type in C# (an `int`, a `string`, a custom class). The compiler has no guarantee that whatever type `T` ends up being will actually have an `Id` property. Furthermore, if `T` is a value type (like a struct), it cannot be returned as `null`.

## Step 7
**Why does `new Store<string>()` not compile?**
It refuses to compile because of the generic constraint `where T : class, IHasId`. The `string` type does not implement our `IHasId` interface, so the compiler safely prevents us from creating a store of strings.

**What is the common name for the kind of class you built in Steps 4 and 5?**
This is known as the **Repository Pattern** (specifically, a **Generic Repository**). It acts as an in-memory collection-like interface for accessing and managing data objects, hiding the underlying storage mechanism (like our `Dictionary`) from the rest of the application.
