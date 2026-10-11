# Part 03 — answers

---

## BlockedUsers

- Time complexity before: O(N * M) (where N is the number of blocked users and M is the number of requests, because `List.Contains` is an O(N) linear search).
- Time (ms) before: 11 ms
- What did you change?
  Converted the `List<int>` into a `HashSet<int>` before the loop. This changes the `.Contains()` check from an O(N) search into an O(1) hash table lookup.
- Time complexity after: O(N + M) (It takes O(N) to build the HashSet once, and then O(1) for each of the M requests).
- Time (ms) after: 3 ms

---

## Students

- What was the problem?
  The method `GetAllStudents()` eagerly created a `List` of 1,000,000 student objects and stored them all in memory before returning. Even though the caller (`Program.cs`) only needed the first 3 students, the program still wasted a massive amount of memory and CPU cycles creating the other 999,997.
- What did you change?
  Changed the return type from `List<Student>` to `IEnumerable<Student>` and used `yield return` inside the loop to make the method lazy (deferred execution). Now, the method only generates and yields a student object exactly when the `foreach` loop in the caller asks for the next one. Since the caller breaks out of the loop after 3 iterations, only 3 student objects are ever created!
