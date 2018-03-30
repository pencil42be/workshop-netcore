FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Pencil42.PakjesDienst.sln ./
COPY Pencil42.PakjesDienst.Web/Pencil42.PakjesDienst.Web.csproj Pencil42.PakjesDienst.Web/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Pencil42.PakjesDienst.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pencil42.PakjesDienst.Web.dll"]
