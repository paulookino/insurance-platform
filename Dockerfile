FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Contratacao.Domain/Contratacao.Domain.csproj Contratacao.Domain/
COPY Contratacao.Application/Contratacao.Application.csproj Contratacao.Application/
COPY Contratacao.Infrastructure/Contratacao.Infrastructure.csproj Contratacao.Infrastructure/
COPY Contratacao.Api/Contratacao.Api.csproj Contratacao.Api/

RUN dotnet restore Contratacao.Api/Contratacao.Api.csproj

COPY . .

RUN dotnet publish Contratacao.Api/Contratacao.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Contratacao.Api.dll"]
