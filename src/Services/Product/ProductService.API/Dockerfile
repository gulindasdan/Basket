#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Product/ProductService.API/ProductService.API.csproj", "src/Services/Product/ProductService.API/"]
COPY ["src/Services/Product/ProductService.Application/ProductService.Application.csproj", "src/Services/Product/ProductService.Application/"]
COPY ["src/Services/Product/ProductService.Domain/ProductService.Domain.csproj", "src/Services/Product/ProductService.Domain/"]
COPY ["src/Services/Product/ProductService.Infrastructure/ProductService.Infrastructure.csproj", "src/Services/Product/ProductService.Infrastructure/"]
RUN dotnet restore "src/Services/Product/ProductService.API/ProductService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Product/ProductService.API"
RUN dotnet build "ProductService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.API.dll"]