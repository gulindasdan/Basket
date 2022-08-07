FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Product/ProductService.API/ProductService.API.csproj", "Services/Product/ProductService.API/ProductService.API.csproj"]
COPY ["Services/Product/ProductService.Application/ProductService.Application.csproj", "Services/Product/ProductService.Application/ProductService.Application.csproj"]
COPY ["Services/Product/ProductService.Domain/ProductService.Domain.csproj", "Services/Product/ProductService.Domain/ProductService.Domain.csproj"]
COPY ["Services/Product/ProductService.Infrastructure/ProductService.Infrastructure.csproj", "Services/Product/ProductService.Infrastructure/ProductService.Infrastructure.csproj"]
RUN dotnet restore "Services/Product/ProductService.API/ProductService.API.csproj"
COPY . .
WORKDIR "/src/Services/Product/ProductService.API"
RUN dotnet build "ProductService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.API.dll"]