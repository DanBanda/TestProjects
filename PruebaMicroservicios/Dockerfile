#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PruebaMicroservicios/PruebaMicroservicios.csproj", "PruebaMicroservicios/"]
COPY ["PruebaMicroservicios.BE/PruebaMicroservicios.BE.csproj", "PruebaMicroservicios.BE/"]
COPY ["PruebaMicroservicios.BL/PruebaMicroservicios.BL.csproj", "PruebaMicroservicios.BL/"]
COPY ["PruebaMicroservicios.DAL/PruebaMicroservicios.DAL.csproj", "PruebaMicroservicios.DAL/"]
RUN dotnet restore "PruebaMicroservicios/PruebaMicroservicios.csproj"
COPY . .
WORKDIR "/src/PruebaMicroservicios"
RUN dotnet build "PruebaMicroservicios.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaMicroservicios.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaMicroservicios.dll"]