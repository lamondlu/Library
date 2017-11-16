FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# 拷贝.csproj到工作目录/app，然后执行dotnet restore恢复所有安装的NuGet包。
COPY BookLibrary.Service.Inventory ./BookLibrary.Service.Inventory/
COPY BookLibrary.Service.Inventory.Domain ./BookLibrary.Service.Inventory.Domain/
COPY BookLibrary.Infrastructure.InjectionFramework ./BookLibrary.Infrastructure.InjectionFramework/
COPY BookLibrary.Domain.Core ./BookLibrary.Domain.Core/
COPY BookLibrary.Infrastructure.Messaging.RabbitMQ ./BookLibrary.Infrastructure.Messaging.RabbitMQ/
COPY BookLibrary.Infrastructure.Messaging.SignalR ./BookLibrary.Infrastructure.Messaging.SignalR/
COPY BookLibrary.Infrastructure.DataPersistence.Inventory.SQLServer ./BookLibrary.Infrastructure.DataPersistence.Inventory.SQLServer


WORKDIR /app/BookLibrary.Service.Inventory
RUN dotnet restore

WORKDIR /app/BookLibrary.Service.Inventory
RUN dotnet publish -c Release -o out

# 编译Docker镜像
FROM microsoft/aspnetcore:2.0
WORKDIR /app/BookLibrary.Service.Inventory
COPY --from=build-env /app/BookLibrary.Service.Inventory/out .
ENV ASPNETCORE_URLS http://0.0.0.0:3721
ENTRYPOINT ["dotnet", "BookLibrary.Service.Inventory.dll"]