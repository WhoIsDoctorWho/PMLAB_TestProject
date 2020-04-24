# My solution of WebApi + Swagger UI Calculator
## Using NCalc for evaluating string requests

### Calculator

path: https://localhost:44302/api/Calculator?expression={YourExpression}
method: Get
Possible operators: +, -, *, /, (, ), %, Sin, Cos, Tan, Log 
returns: result (if input is correct), 400 otherwise



### History

path: https://localhost:44302/api/History
method: Get
returns: all stored history or message "History is empty"

path: https://localhost:44302/api/History
method: Delete
returns: 200 if history was cleared, 500 otherwise

path: https://localhost:44302/api/History/search?request={YourRequest}
method: Get
returns: 200 and matching strings if any, 404 otherwise

![](https://user-images.githubusercontent.com/31898055/80204202-1ad66880-8631-11ea-9a62-c72da01db427.png)
![](https://user-images.githubusercontent.com/31898055/80204492-a51ecc80-8631-11ea-9115-b674b272d29e.png)
![](https://user-images.githubusercontent.com/31898055/80204583-d0a1b700-8631-11ea-9da1-bd345b14468b.png)
