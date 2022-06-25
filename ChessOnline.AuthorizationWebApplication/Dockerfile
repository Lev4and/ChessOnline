#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChessOnline.AuthorizationWebApplication/ChessOnline.AuthorizationWebApplication.csproj", "ChessOnline.AuthorizationWebApplication/"]
COPY ["ChessOnline.Model.Common/ChessOnline.Model.Common.csproj", "ChessOnline.Model.Common/"]
RUN dotnet restore "ChessOnline.AuthorizationWebApplication/ChessOnline.AuthorizationWebApplication.csproj"
COPY . .
WORKDIR "/src/ChessOnline.AuthorizationWebApplication"
RUN dotnet build "ChessOnline.AuthorizationWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChessOnline.AuthorizationWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChessOnline.AuthorizationWebApplication.dll"]