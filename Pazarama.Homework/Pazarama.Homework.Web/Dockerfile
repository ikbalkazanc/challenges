#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pazarama.Homework.Web/Pazarama.Homework.Web.csproj", "Pazarama.Homework.Web/"]
COPY ["Pazarama.Homework.Services/Pazarama.Homework.Services.csproj", "Pazarama.Homework.Services/"]
COPY ["Pazarama.Homework.Core/Pazarama.Homework.Core.csproj", "Pazarama.Homework.Core/"]
COPY ["Pazarama.Homework.Data/Pazarama.Homework.Data.csproj", "Pazarama.Homework.Data/"]
RUN dotnet restore "Pazarama.Homework.Web/Pazarama.Homework.Web.csproj"
COPY . .
WORKDIR "/src/Pazarama.Homework.Web"
RUN dotnet build "Pazarama.Homework.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pazarama.Homework.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pazarama.Homework.Web.dll"]