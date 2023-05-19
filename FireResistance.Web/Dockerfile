#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FireResistance.Web/FireResistance.Web.csproj", "FireResistance.Web/"]
COPY ["FireResistance.Core/FireResistance.Core.csproj", "FireResistance.Core/"]
COPY ["Logger/FireResistance.Logger.csproj", "Logger/"]
RUN dotnet restore "FireResistance.Web/FireResistance.Web.csproj"
COPY . .
WORKDIR "/src/FireResistance.Web"
RUN dotnet build "FireResistance.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FireResistance.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir ../logger
RUN apt update
RUN apt install nano -y
ENTRYPOINT ["dotnet", "FireResistance.Web.dll"]