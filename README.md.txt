My solution of WebApi + Swagger UI Calculator
Using NCalc for evaluating string requests

Calculator

path: https://localhost:44302/api/Calculator?expression={YourExpression}
method: Get
Possible operators: +, -, *, /, (, ), %, Sin, Cos, Tan, Log 
returns: result (if input is correct), 400 otherwise



History

path: https://localhost:44302/api/History
method: Get
returns: all stored history or message "History is empty"

path: https://localhost:44302/api/History
method: Delete
returns: 200 if history was cleared, 500 otherwise

path: https://localhost:44302/api/History/search?request={YourRequest}
method: Get
returns: 200 and matching strings if any, 404 otherwise

