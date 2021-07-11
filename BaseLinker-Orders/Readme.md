# BaseLinker-Orders Lite


> This project aims to create basic integration with BaseLinker e-commerce workflow platform [baselinker.com](https://baselinker.com/en-US/home/) specifically in order management.

The entire project has been set up as a Console Application with .NET Framework 4.7.2 with logging output (application progress) both to console and file. It also uses WebClient specifically as a communication layer with BaseLinker API


## Access to BaseLinker API

Each BaseLinker account provides you a 14-day trial account with access to its API. You have to create your account to get an access token that is needed for every request.
[BaseLinker API docs](https://api.baselinker.com/index.php)

### Key functionalities implemented:

1. Get orders (invoking `getOrders` method)
2. Create new order (invoking `addOrder` method)

Application progress logging is configured to show messages in console and file (file can be found in `bin\[Project Confugration]` folder inside project for example
`BaseLinker-Orders\BaseLinker-Orders\bin\Debug\Logs\baselinker-orders.log`

## Tools configured
1. Ninject 3.3 - an Open source dependency injector for .NET
2. WebClient - creating requests to BaseLinker API
3. Newtonsoft.Json - a popular high-performance JSON framework for .NET
4. Log4net - for implementing log messages in your application