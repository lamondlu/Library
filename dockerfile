FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# 拷贝.csproj到工作目录/app，然后执行dotnet restore恢复所有安装的NuGet包。
COPY BookingLibrary.Service.Inventory ./BookingLibrary.Service.Inventory/
COPY BookingLibrary.Service.Inventory.Domain ./BookingLibrary.Service.Inventory.Domain/
COPY BookingLibrary.Infrastructure.InjectionFramework ./BookingLibrary.Infrastructure.InjectionFramework/
COPY BookingLibrary.Domain.Core ./BookingLibrary.Domain.Core/
COPY BookingLibrary.Infrastructure.Messaging.RabbitMQ ./BookingLibrary.Infrastructure.Messaging.RabbitMQ/
COPY BookingLibrary.Infrastructure.Messaging.SignalR ./BookingLibrary.Infrastructure.Messaging.SignalR/
COPY BookingLibrary.Infrastructure.DataPersistence.Inventory.SQLServer ./BookingLibrary.Infrastructure.DataPersistence.Inventory.SQLServer


WORKDIR /app/BookingLibrary.Service.Inventory
RUN dotnet restore

WORKDIR /app/BookingLibrary.Service.Inventory
RUN dotnet publish -c Release -o out

# 编译Docker镜像
FROM microsoft/aspnetcore:2.0
WORKDIR /app/BookingLibrary.Service.Inventory
COPY --from=build-env /app/BookingLibrary.Service.Inventory/out .
ENV ASPNETCORE_URLS http://0.0.0.0:3721
ENTRYPOINT ["dotnet", "BookingLibrary.Service.Inventory.dll"]