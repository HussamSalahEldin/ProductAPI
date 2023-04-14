# Product API using .NET Core

This is a simple RESTful API built with .NET Core that allows users to perform CRUD operations on a list of products. 

## Functionality

The API implements the following endpoints:

1. GET `/api/products` - retrieves a list of all products
2. GET `/api/products/{id}` - retrieves a single product by ID
3. POST `/api/products` - adds a new product to the list
4. PUT `/api/products/{id}` - updates an existing product by ID
5. DELETE `/api/products/{id}` - deletes a product by ID

## Usage

To use this API, you can make requests to the above endpoints using a tool like cURL or Postman. Here are some example requests:

1. GET `/api/products` - returns a JSON array of all products in the list
2. GET `/api/products/1` - returns a JSON object representing the product with ID 1
3. POST `/api/products` with a JSON body containing product information - adds a new product to the list and returns the newly created product with an assigned ID
4. PUT `/api/products/1` with a JSON body containing updated product information - updates the product with ID 1 and returns the updated product
5. DELETE `/api/products/1` - deletes the product with ID 1 from the list

## Development

To run this API locally, you will need to have .NET Core installed on your machine. You can then clone this repository, navigate to the project directory, and run the following command to start the API:

`dotnet run`

The API will be available at `http://localhost:5000`. You can also run the tests by running the following command:

`dotnet test`


## Contribution

If you find any issues with the API or would like to contribute, please feel free to create a pull request or file an issue in this repository. We welcome your feedback and contributions to make this API better!
