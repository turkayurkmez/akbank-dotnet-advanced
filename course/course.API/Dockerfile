#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["course.API/course.API.csproj", "course.API/"]
COPY ["course.Application/course.Application.csproj", "course.Application/"]
COPY ["course.Infrastructure/course.Infrastructure.csproj", "course.Infrastructure/"]
COPY ["course.Entities/course.Entities.csproj", "course.Entities/"]
RUN dotnet restore "course.API/course.API.csproj"
COPY . .
WORKDIR "/src/course.API"
RUN dotnet build "course.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "course.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "course.API.dll"]