FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src/*.csproj ./
RUN dotnet restore -r linux-musl-x64

# copy everything else and build app
COPY src/. ./
RUN dotnet publish -r linux-musl-x64 -c Release -o out --self-contained false --no-restore


FROM mcr.microsoft.com/dotnet/core/runtime:3.1.2-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["./Rstolsmark.EncryptionTool"]
