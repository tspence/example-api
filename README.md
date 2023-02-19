# Example DotNet API
This example API demonstrates a variety of techniques used in designing a maintainable and
resilient API.

# Developer Setup
To set up this API on a development computer:
* Install DotNet 7.0 and Docker Desktop
* Build the API solution
```shell
> dotnet build
```
* Construct the database using Docker (replace the security credentials with your chosen ones)
```shell
> docker pull postgres
> docker run -p 5432:5432 --name some-postgres -e POSTGRES_PASSWORD=apipassword -e POSTGRES_USER=apiuser -d postgres
```
* Execute the database migration script
```shell
> dotnet ef database update --project .\ExampleDataLayer\ExampleDataLayer.csproj
```
* Launch the API
```shell
> dotnet run --project .\ExampleApi\ExampleApi.csproj
```

# Articles
* [Part 1: Designing an API with DotNet and Postgres](https://tedspence.com/part-1-designing-an-api-with-dotnet-and-postgres-4fbefb898e68)
* [Part 2: Developing a data layer for your DotNet API](https://tedspence.com/part-2-developing-a-data-layer-for-your-dotnet-api-79a697ac1b1d)
