FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TesteDigipix/TesteDigipix.csproj", "TesteDigipix/"]
COPY ["DigipixServices/DigipixServices.csproj", "DigipixServices/"]
COPY ["DigipixDomain/DigipixDomain.csproj", "DigipixDomain/"]
RUN dotnet restore "TesteDigipix/TesteDigipix.csproj"
COPY . .
WORKDIR "/src/TesteDigipix"
RUN dotnet build "TesteDigipix.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TesteDigipix.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TesteDigipix.dll"]
