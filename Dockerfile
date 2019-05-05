FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Memo/Memo.Api.csproj", "Memo/"]
COPY ["Memo.Infrastructure/Memo.Infrastructure.csproj", "Memo.Infrastructure/"]
COPY ["Memo.Domain/Memo.Domain.csproj", "Memo.Domain/"]
COPY ["Memo.Dto/Memo.Dto.csproj", "Memo.Dto/"]
COPY ["Memo.Core/Memo.Core.csproj", "Memo.Core/"]
RUN dotnet restore "Memo/Memo.Api.csproj"
COPY . .
WORKDIR "/src/Memo"
RUN dotnet build "Memo.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Memo.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Memo.Api.dll"]