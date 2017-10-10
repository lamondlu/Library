FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# 拷贝.csproj到工作目录/app，然后执行dotnet restore恢复所有安装的NuGet包。
COPY BookingLibrary.Service.Repository ./BookingLibrary.Service.Repository/
COPY BookingLibrary.Service.Repository.Domain ./BookingLibrary.Service.Repository.Domain/
COPY BookingLibrary.Domain.Core ./BookingLibrary.Domain.Core/

WORKDIR /app/BookingLibrary.Service.Repository
RUN dotnet restore

WORKDIR /app/BookingLibrary.Service.Repository
RUN dotnet publish -c Release -o out

# 编译Docker镜像
FROM microsoft/aspnetcore:2.0
WORKDIR /app/BookingLibrary.Service.Repository
COPY --from=build-env /app/BookingLibrary.Service.Repository/out .
ENV ASPNETCORE_URLS http://0.0.0.0:3721
ENTRYPOINT ["dotnet", "BookingLibrary.Service.Repository.dll"]