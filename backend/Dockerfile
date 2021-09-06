FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY ["Api.Capiflix/Api.Capiflix.csproj", "Api.Capiflix/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["BusinessApi/BusinessApi.csproj", "BusinessApi/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["ImportData/ImportData.csproj", "ImportData/"]

COPY . .

WORKDIR /src/Api.Capiflix

RUN dotnet restore "Api.Capiflix.csproj"
RUN dotnet build "Api.Capiflix.csproj" -c Realase -o /app

FROM build AS publish
RUN dotnet publish "Api.Capiflix.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:5.0

WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "Api.Capiflix.dll", "--urls", "http://0.0.0.0:5000"]