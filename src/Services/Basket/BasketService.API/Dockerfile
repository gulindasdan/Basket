#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Basket/BasketService.API/BasketService.API.csproj", "src/Services/Basket/BasketService.API/"]
COPY ["src/Services/Basket/BasketService.Infrastructure/BasketService.Infrastructure.csproj", "src/Services/Basket/BasketService.Infrastructure/"]
COPY ["src/Services/Basket/BasketService.Application/BasketService.Application.csproj", "src/Services/Basket/BasketService.Application/"]
COPY ["src/Services/Basket/BasketService.Domain/BasketService.Domain.csproj", "src/Services/Basket/BasketService.Domain/"]
RUN dotnet restore "src/Services/Basket/BasketService.API/BasketService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Basket/BasketService.API"
RUN dotnet build "BasketService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketService.API.dll"]