> ## Learning Multi-stage deployments with Azure Functions

> Azure Functions

In here we have developed two Azure functions.

* `CreateNewSalesOrderFunction`

This is an HTTP triggered function. It is the front which the clients will be using to send the new orders. It will validate the new order request and, if it's valid
then it'll publish the request to a queue. Then it'll create a new entry in the Azure table with the status as `new`.



* `ProcessSalesOrderFunction`

This is an queue triggered function. This function will inspect the order and, classify whether it's an `VIP` or an `Ordinary` order. It will then call the `ShipOrderFunction`.
Upon succeful response it will update the order setting the order to be `in progress`.


* `ShipOrderFunction`

This is an HTTP triggered function.


> Deployment (Multi-stage Azure pipeline)

[IN PROGRESS...]