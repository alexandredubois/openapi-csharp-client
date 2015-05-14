# Cdiscount Open API Client
---------------------------------

* [Presentation](#presentation)
* [Features](#features)
* [Getting started](#getting-started)
* [Contributors](#contributors)
* [How to help](#how-to-help-)
* [Licence](#licence)

## Presentation
---------------

This open source project is here to help people wanting to use the Cdiscount Open API in a .NET powered solution.

This project was designed as a thin C# wrapper on top of the Cdiscount Open API. Packaged as a portable class library, you can use it on different .NET environments (Windows Phone 8+ app, Windows Store App...).

## Features
------------

The library features reflect those offered by the standard Cdiscount open API. eg : 

* search for products
* retrieve product information
* manage a cdiscount shopping cart

For a full list of features, please visit the [Cdiscount Open API documentation](https://dev.cdiscount.com/docs/apiReference).

## Getting started
------------------
### Get your own API key
Want to have some fun with the Cdiscount Open API ? Good news, you're on the right spot ! Before doing magic, the first thing to to is to [sign up on the Cdiscount Open API portal](https://dev.cdiscount.com/register) and create your first app to obtain an API key.

### Add the Cdiscount Open API Client to your project

There are 2 ways to get the job done : declaring a project reference or adding a nuget package. The NuGet package is the recommended and easiest way to go.
To install Cdiscount Open API Client, run the following command in the Package Manager Console
```
PM> Install-Package Cdiscount.OpenApi.ProxyClient
```

### Play with your new toy

Instead of a full punchy and entoushiast talk, just give a look to the following lines of code

**Create a Cdiscount Open API Client instance**
```csharp
OpenApiClient openApiClient = new OpenApiClient(new ProxyClientConfig { ApiKey = "YOUR-BRAND-NEW-API-KEY-HERE" });
```

**Get the 'fincpangfirrnoir' product**
```csharp
var response = openApiClient.GetProduct(new GetProductRequest
            {
                ProductIdList = new List<string> {"fincpangfirrnoir"},
                Scope = new GetProductRequestScope()
            });
```

**Add the 'fincpangfirrnoir' product to a new shopping cart**
```csharp
var response = openApiClient.PushToCart(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });
```

**Get shopping cart details**
```csharp
var response = openApiClient.GetCart(new GetCartRequest
            {
                CartGuid = "YOUR-CART-GUID-HERE"
            });
```

**Search for products related to 'superman'**
```csharp
var response = openApiClient.Search(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance
            });
```

## Contributors
* [Alexandre Dubois](http://www.alexandredubois.com)
* [Adrien Havas](https://github.com/Drenskin)

## How to help ?

Every action is welcome ! You can submit pull request, open issue, write documentation or translate it... Do not hesitate to propose your help !

## Licence
This project is distributed under the MIT licence provided in the dedicated LICENCE.txt file.
