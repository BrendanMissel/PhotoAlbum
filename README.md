# Photo Album
## Summary
This program is a console application that retrieves and displays photo IDs and titles from an album. The photos are available through the following online web service: https://jsonplaceholder.typicode.com/photos

---

## Prerequisites

This program was created with .NET 7.0 and requires the .NET SDK to be installed.

## How to Build


To build this solution, run the following command in a terminal from the top level folder:

`dotnet build`


## How to Test
This solution contains an xUnit project containing the unit tests. 

To run the unit tests, run the following command in a terminal from the top level folder:

`dotnet test`


## How to Run
This project expects one command line argument: the album id shown below as `X`. `X` should a positive numeric value.

To run this project, run the following command in a terminal from the top level folder:

`dotnet run --project PhotoAlbum.App/PhotoAlbum.App.csproj X`
