In Oracle, the SELECT ... FOR UPDATE statement is used to lock rows returned by a query to prevent other transactions from modifying or deleting them until the current transaction is completed (committed or rolled back). This is particularly useful in scenarios where you need to ensure data consistency during concurrent access.

Here’s the syntax and an example:

Syntax
Copiar o código
SELECT column1, column2, ...
FROM table_name
WHERE condition
FOR UPDATE;

Example

Suppose you have a table employees and you want to lock the rows of employees in the "HR" department for updates:

Copiar o código
SELECT employee_id, first_name, last_name
FROM employees
WHERE department = 'HR'
FOR UPDATE;

Key Points:
Row Locking: The rows returned by the query are locked, preventing other transactions from updating or deleting them.
NOWAIT Option: Add NOWAIT to avoid waiting if the rows are already locked by another transaction:
Copiar o código
SELECT employee_id, first_name, last_name
FROM employees
WHERE department = 'HR'
FOR UPDATE NOWAIT;

If the rows are locked, an error is raised immediately.
SKIP LOCKED Option: Add SKIP LOCKED to skip rows that are already locked:
Copiar o código
SELECT employee_id, first_name, last_name
FROM employees
WHERE department = 'HR'
FOR UPDATE SKIP LOCKED;

This is useful for implementing work queues.
OF Clause: Use FOR UPDATE OF column_name to specify which columns you intend to update:
Copiar o código
SELECT employee_id, first_name, last_name
FROM employees
WHERE department = 'HR'
FOR UPDATE OF salary;


Remember to always commit or roll back the transaction after using FOR UPDATE to release the locks.