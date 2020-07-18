> ## Learning Multi-stage deployments with Azure Functions

> Azure Functions

In here we have developed two Azure functions.

* `CreateNewSalesOrderFunction`

This is an HTTP triggered function. It is the front which the clients will be using to send the new orders. It will validate the new order request and, if it's valid
then it'll publish the request to a queue.



* `ProcessSalesOrderFunction`

This is an queue triggered function.


> Deployment (Multi-stage Azure pipeline)

[IN PROGRESS...]