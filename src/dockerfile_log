FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# 拷贝.csproj到工作目录/app，然后执行dotnet restore恢复所有安装的NuGet包。
COPY Library.Service.Logs ./Library.Service.Logs/
COPY Library.Infrastructure.InjectionFramework ./Library.Infrastructure.InjectionFramework/
COPY Library.Infrastructure.Core ./Library.Infrastructure.Core/
COPY Library.Infrastructure.Logger.SQLServer ./Library.Infrastructure.Logger.SQLServer/
COPY Library.Infrastructure.Operation.Consul ./Library.Infrastructure.Operation.Consul/
COPY Library.Infrastructure.Operation.Core ./Library.Infrastructure.Operation.Core/
COPY Library.Domain.Core ./Library.Domain.Core/
COPY Library.Infrastructure.DataPersistence.Core.SQLServer ./Library.Infrastructure.DataPersistence.Core.SQLServer/


WORKDIR /app/Library.Service.Logs
RUN dotnet restore

WORKDIR /app/Library.Service.Logs
RUN dotnet publish -c Release -o out

# 编译Docker镜像
FROM microsoft/aspnetcore:2.0
WORKDIR /app/Library.Service.Logs
COPY --from=build-env /app/Library.Service.Logs/out .
ENTRYPOINT ["dotnet", "Library.Service.Logs.dll"]