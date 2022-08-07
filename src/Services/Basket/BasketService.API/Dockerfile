FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/BasketService.API/BasketService.API.csproj", "Services/Basket/BasketService.API/BasketService.API.csproj"]
COPY ["Services/Basket/BasketService.Infrastructure/BasketService.Infrastructure.csproj", "Services/Basket/BasketService.Infrastructure/BasketService.Infrastructure.csproj"]
COPY ["Services/Basket/BasketService.Application/BasketService.Application.csproj", "Services/Basket/BasketService.Application/BasketService.Application.csproj"]
COPY ["Services/Basket/BasketService.Domain/BasketService.Domain.csproj", "Services/Basket/BasketService.Domain/BasketService.Domain.csproj"]
RUN dotnet restore "Services/Basket/BasketService.API/BasketService.API.csproj"
COPY . .
WORKDIR "/src/Services/Basket/BasketService.API"
RUN dotnet build "BasketService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketService.API.dll"]