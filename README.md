#  Library
A project using .NET Core 2.0, DDD, CQRS, Event Sourcing and RabbitMQ

## Components
![Components](https://github.com/lamondlu/BookLibrary/blob/master/Documents/Architecture/20180108201702.png)

## System Architecture
![System Architecture](https://github.com/lamondlu/BookLibrary/blob/master/Documents/Architecture/20171107104353.png)

## EDA 
![EDA](https://github.com/lamondlu/BookLibrary/blob/master/Documents/Architecture/20171108152513.png)

## Service Discovery 
We will use the Nginx, Consul, Consul Template to create an service discovery and service registeration mechanism.

## Description
There are user service, book inventory service and book rental service in the system.

### User Service
* There are two role in the system, Admin User and Customer.
* Admin user can add/edit/update/delete customer information.
* If assigned customer has unreturned books, admin user can't remove it in the system.
* Admin user and customer can update their information(FirstName, LastName, MiddleName).
* Admin user and customer can update their password.

### Book Inventory Service
* Admin user can add/edit/delete book.
* Admin user can bulk import book inventory.
* Book are the following fields
    *    Book Name(Required)
	*    ISBN(Required, Unique)
	*    Description
	*    IssuedDate(Required)
* There are two book inventory statuses in the system, In/Out.
  
### Book Rental Service
* If one book inventory has been rented by one customer, it can't be rented by others.
* One customer can rent 3 books at most.



