# Quản Lý Đơn Hàng Nội Bộ

Đây là backend API cho hệ thống quản lý đơn hàng nội bộ, mô phỏng một quy trình OMS gồm quản lý tenant, người dùng, khách hàng, sản phẩm, kho, tồn kho, đơn hàng, đóng gói, giao hàng, COD, hoàn trả, dashboard và thông báo realtime.

Dự án được xây dựng theo hướng tách lớp rõ ràng để dễ bảo trì, dễ mở rộng và dễ trình bày khi đưa lên GitHub.

## 1. Mục tiêu của bài

Bài làm tập trung xây dựng phần backend cho một hệ thống quản lý đơn hàng nội bộ. Các mục tiêu chính:

- Xây dựng REST API cho các nghiệp vụ quản lý đơn hàng.
- Tổ chức mã nguồn theo kiến trúc nhiều lớp: API, Application, Domain, Infrastructure.
- Tách controller khỏi xử lý nghiệp vụ chính.
- Có đăng nhập bằng JWT và phân quyền bằng permission policy.
- Có dữ liệu mẫu để test nhanh sau khi chạy ứng dụng.
- Có cấu hình Entity Framework Core và migration cho SQL Server.
- Có Postman collection để kiểm thử API.
- Có middleware xử lý lỗi, logging request và correlation id.
- Có SignalR hub để mô phỏng realtime notification.

## 2. Công nghệ sử dụng

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / SQL Server Express / LocalDB
- JWT Bearer Authentication
- Authorization Policy
- SignalR
- Postman
- C#

## 3. Cấu trúc dự án sau khi hoàn thành

```text
QuanLyDonHangNoiBo
|-- QuanLyDonHangNoiBo.Api
|   |-- Controllers
|   |-- Hubs
|   |-- Middleware
|   |-- Security
|   |-- Properties
|   |-- Program.cs
|   |-- appsettings.json
|   `-- appsettings.Development.json
|
|-- QuanLyDonHangNoiBo.Application
|   |-- Common
|   |-- Features
|   |-- Interfaces
|   |-- DependencyInjection.cs
|   `-- GlobalUsings.cs
|
|-- QuanLyDonHangNoiBo.Domain
|   |-- Entities
|   `-- Enums
|
|-- QuanLyDonHangNoiBo.Infrastructure
|   |-- Persistence
|   |   |-- Configurations
|   |   |-- DbContext
|   |   |-- InMemory
|   |   `-- Migrations
|   `-- DependencyInjection.cs
|
|-- postman
|   `-- QuanLyDonHangNoiBo.postman_collection.json
|
|-- QuanLyDonHangNoiBo.sln
|-- QuanLyDonHangNoiBo.slnx
`-- README.md
```

## 4. Quá trình hoàn thành bài

### Bước 1: Khởi tạo và tổ chức lại solution

Ban đầu dự án được tổ chức lại thành nhiều project thay vì để toàn bộ code trong một project Web API duy nhất.

Các project chính được tạo:

- `QuanLyDonHangNoiBo.Api`: nhận request HTTP, định nghĩa controller, middleware, JWT, SignalR hub.
- `QuanLyDonHangNoiBo.Application`: xử lý nghiệp vụ, DTO, command, query, service và interface repository.
- `QuanLyDonHangNoiBo.Domain`: chứa entity và enum nghiệp vụ.
- `QuanLyDonHangNoiBo.Infrastructure`: triển khai persistence, seed data, EF Core DbContext, configuration và migration.

Lý do thay đổi:

- Controller không nên chứa quá nhiều logic nghiệp vụ.
- Entity và enum nên được gom vào Domain để dễ quản lý.
- Infrastructure được tách riêng để sau này có thể thay đổi cách lưu trữ dữ liệu.
- Application là nơi điều phối nghiệp vụ và chuyển dữ liệu ra DTO.

### Bước 2: Xác định các module nghiệp vụ

Sau khi phân tích đề tài quản lý đơn hàng nội bộ, hệ thống được chia thành các module:

- Đăng nhập và phân quyền.
- Quản lý tenant.
- Quản lý người dùng và vai trò.
- Quản lý khách hàng.
- Quản lý sản phẩm và SKU.
- Quản lý kho.
- Quản lý tồn kho.
- Quản lý đơn hàng.
- Pick-pack và đóng gói.
- Giao hàng.
- Proof of Delivery.
- COD và đối soát.
- Hoàn trả.
- Dashboard và thông báo.
- Import sản phẩm và export báo cáo.
- AI insight demo.

Từ các module này, em tiếp tục xác định entity, enum, API endpoint và request/response DTO tương ứng.

### Bước 3: Xây dựng Domain layer

Domain layer được dùng để lưu các đối tượng cốt lõi của hệ thống.

Các entity chính đã thêm:

- `Tenant`: thông tin đơn vị sử dụng hệ thống.
- `AppUser`: người dùng trong tenant.
- `Customer`: khách hàng.
- `Product`: sản phẩm.
- `ProductSku`: biến thể SKU của sản phẩm.
- `Warehouse`: kho hàng.
- `InventoryStock`: số lượng tồn kho theo kho và SKU.
- `InventoryTransaction`: lịch sử nhập, xuất, điều chỉnh kho.
- `Order`: đơn hàng.
- `OrderItem`: chi tiết sản phẩm trong đơn.
- `OrderStatusHistory`: lịch sử thay đổi trạng thái đơn.
- `PickList`: danh sách nhặt hàng.
- `PickListItem`: chi tiết item cần nhặt.
- `Package`: kiện hàng sau khi đóng gói.
- `Shipment`: thông tin giao hàng.
- `ProofOfDelivery`: bằng chứng giao hàng.
- `CodCollection`: thông tin thu hộ COD.
- `ReturnRequest`: yêu cầu hoàn trả.
- `NotificationItem`: thông báo trong hệ thống.
- `AuditLog`: log nghiệp vụ.
- `AiInsight`: insight demo.
- `ExportJob`: tác vụ export báo cáo.

Các enum đã thêm:

- `OrderStatus`
- `ShipmentStatus`
- `PackageStatus`
- `PickListStatus`
- `ReturnStatus`
- `CodStatus`
- `ExportJobStatus`
- `PaymentMethod`
- `UserRole`
- `TenantStatus`
- `InventoryTransactionType`
- `NotificationSeverity`

Thay đổi quan trọng ở bước này:

- Tách entity khỏi file tổng hợp cũ để mỗi entity nằm trong file riêng.
- Tách enum khỏi file tổng hợp cũ để dễ tìm và dễ mở rộng.
- Chuẩn hóa tên entity theo nghiệp vụ thực tế của OMS.

### Bước 4: Xây dựng Application layer

Application layer là nơi xử lý nghiệp vụ chính.

Các nhóm code đã thêm:

- DTO dùng để trả dữ liệu ra API.
- Request model dùng cho các thao tác create/update.
- Command và command handler cho thao tác ghi dữ liệu.
- Query và query handler cho thao tác đọc dữ liệu.
- `OmsApplicationService` làm service điều phối nghiệp vụ.
- `IOmsRepository` làm interface truy cập dữ liệu.
- `PagedResult` dùng cho các API danh sách có phân trang.
- `PasswordHasher` dùng để hash và verify mật khẩu.

Một số nghiệp vụ đã triển khai:

- Đăng nhập theo tenant code, email và mật khẩu.
- Lấy danh sách permission theo role.
- Tạo, sửa, xóa khách hàng.
- Tạo, sửa, xóa sản phẩm.
- Tạo, sửa, xóa kho.
- Tạo, sửa, xóa tenant.
- Tạo, sửa, khóa/mở khóa người dùng.
- Tạo đơn hàng.
- Xác nhận đơn hàng.
- Hủy đơn hàng.
- Cập nhật trạng thái đơn hàng.
- Nhập kho.
- Xuất kho thủ công.
- Điều chỉnh tồn kho.
- Tạo pick list.
- Scan item trong pick list.
- Tạo package.
- Phân công shipment cho tài xế.
- Cập nhật trạng thái shipment.
- Upload proof of delivery.
- Tạo và cập nhật trạng thái hoàn trả.
- Đối soát COD.
- Lấy dashboard, metadata và notification.
- Import sản phẩm.
- Tạo export job.
- Hỏi AI demo và trả insight liên quan.

Thay đổi quan trọng ở bước này:

- Logic không viết trực tiếp trong controller nữa.
- Các thao tác được chia theo command/query để dễ đọc và dễ test.
- `OmsApplicationService` được tách thành nhiều file partial theo từng nghiệp vụ để tránh một file quá dài.

### Bước 5: Xây dựng Infrastructure layer

Infrastructure layer được dùng để triển khai dữ liệu và kết nối database.

Các phần đã hoàn thành:

- `InMemoryOmsRepository`: repository chạy bằng dữ liệu trong bộ nhớ, phục vụ demo và test nhanh.
- `ApplicationDbContext`: DbContext cho Entity Framework Core.
- `ApplicationDbContextFactory`: hỗ trợ chạy lệnh migration bằng `dotnet ef`.
- Các file configuration cho từng entity.
- Migration khởi tạo database.
- Migration bổ sung dữ liệu/luồng pick-pack, POD, export demo.

Thay đổi quan trọng ở bước này:

- Thêm seed data mô phỏng dữ liệu thật.
- Thêm nhiều kho, sản phẩm, SKU, khách hàng, đơn hàng, shipment, COD, notification.
- Chuẩn bị sẵn database schema để có thể chuyển sang SQL Server.

### Bước 6: Xây dựng API layer

API layer nhận request từ client và gọi xuống Application layer.

Các controller đã thêm:

- `AuthController`
- `TenantsController`
- `UsersController`
- `CustomersController`
- `ProductsController`
- `WarehousesController`
- `InventoryController`
- `OrdersController`
- `PickPackController`
- `DeliveryController`
- `FinanceController`
- `ReturnsController`
- `DashboardController`
- `ImportExportController`
- `DemoController`
- `AiController`

Một số endpoint chính:

```text
POST   /api/auth/login
POST   /api/auth/logout
GET    /api/auth/permissions

GET    /api/orders
GET    /api/orders/{orderId}
POST   /api/orders
POST   /api/orders/{orderId}/confirm
POST   /api/orders/{orderId}/cancel
POST   /api/orders/{orderId}/status

GET    /api/inventory/stocks
GET    /api/inventory/transactions
POST   /api/inventory/stock-in
POST   /api/inventory/stock-out
POST   /api/inventory/adjustments

GET    /api/picklists
POST   /api/picklists
POST   /api/picklists/{pickListId}/scan
GET    /api/packages
POST   /api/packages

GET    /api/delivery/shipments
POST   /api/delivery/shipments/{shipmentId}/assign
POST   /api/driver/shipments/{shipmentId}/status
POST   /api/delivery/shipments/{shipmentId}/pod

GET    /api/cod/collections
POST   /api/cod/reconcile

GET    /api/returns
POST   /api/returns
POST   /api/returns/{returnId}/status

GET    /api/dashboard
GET    /api/notifications
GET    /api/metadata
GET    /api/demo/readiness
POST   /api/ai/chat
```

Thay đổi quan trọng ở bước này:

- Mỗi controller chỉ xử lý request/response.
- API được bảo vệ bằng `[Authorize]`.
- Một số endpoint yêu cầu permission cụ thể.
- API trả lỗi qua middleware theo dạng `ProblemDetails`.

### Bước 7: Thêm JWT Authentication

Hệ thống đăng nhập bằng endpoint:

```text
POST /api/auth/login
```

Khi đăng nhập thành công, API trả về `accessToken`. Token này chứa:

- User id.
- Email.
- Full name.
- Role.
- Tenant id.
- Tenant code.
- Danh sách permission.

Sau đó client gọi API bằng header:

```http
Authorization: Bearer <accessToken>
```

Thay đổi quan trọng:

- Thêm `JwtOptions`.
- Thêm `JwtTokenService`.
- Cấu hình `AddAuthentication`.
- Cấu hình `AddAuthorization`.
- Thêm permission policy trong `PermissionPolicies`.

### Bước 8: Thêm phân quyền theo permission

Hệ thống không chỉ kiểm tra đăng nhập mà còn kiểm tra quyền theo từng chức năng.

Ví dụ:

- Quản lý đơn hàng cần `orders.read` hoặc `orders.write`.
- Quản lý tồn kho cần `inventory.read` hoặc `inventory.write`.
- Đối soát COD cần `cod.reconcile`.
- Export báo cáo cần `reports.export`.
- Quản lý user cần `users.manage`.

Mục đích:

- Người dùng đăng nhập nhưng không có quyền sẽ không gọi được API không thuộc vai trò của mình.
- Role như `Driver`, `Sales`, `Warehouse`, `Accountant`, `TenantAdmin` có thể được phân quyền khác nhau.

### Bước 9: Thêm middleware

Các middleware đã thêm:

- `CorrelationIdMiddleware`
- `RequestLoggingMiddleware`
- `ExceptionHandlingMiddleware`

Vai trò:

- Gắn correlation id cho request để dễ truy vết lỗi.
- Ghi log request.
- Bắt exception và trả response lỗi thống nhất.

Ví dụ response lỗi:

```json
{
  "type": "about:blank",
  "title": "Invalid request",
  "status": 400,
  "detail": "Email hoặc mật khẩu không đúng.",
  "instance": "/api/auth/login",
  "correlationId": "..."
}
```

### Bước 10: Thêm SignalR hubs

API có các hub realtime demo:

```text
/hubs/orders
/hubs/delivery
/hubs/notifications
/hubs/dashboard
```

Mục đích:

- Mô phỏng cập nhật realtime cho đơn hàng.
- Mô phỏng cập nhật realtime cho giao hàng.
- Mô phỏng thông báo realtime.
- Mô phỏng dashboard realtime.

### Bước 11: Chuẩn bị dữ liệu demo

Dữ liệu demo được seed trong `InMemoryOmsRepository`.

Các dữ liệu có sẵn:

- 1 tenant demo.
- Nhiều người dùng theo các role khác nhau.
- 3 kho: Hà Nội, TP.HCM, Đà Nẵng.
- Nhiều khách hàng.
- Nhiều sản phẩm và SKU.
- Tồn kho theo từng kho.
- Nhiều đơn hàng ở các trạng thái khác nhau.
- Shipment, COD, notification và AI insight mẫu.

Tài khoản đăng nhập theo phân quyền:

| Email | Role | Mật khẩu |
| --- | --- | --- |
| superadmin@demo.vn | SuperAdmin | Demo@123 |
| admin@demo.vn | TenantAdmin | Demo@123 |
| manager@demo.vn | Manager | Demo@123 |
| sales@demo.vn | Sales | Demo@123 |
| warehouse@demo.vn | Warehouse | Demo@123 |
| inventory@demo.vn | InventoryManager | Demo@123 |
| dispatcher@demo.vn | Dispatcher | Demo@123 |
| driver1@demo.vn | Driver | Demo@123 |
| driver2@demo.vn | Driver | Demo@123 |
| accountant@demo.vn | Accountant | Demo@123 |

Tenant code:

```text
demo
```

### Bước 12: Chuẩn bị Postman collection

Để test API theo từng quyền, em chuẩn bị file:

```text
postman/QuanLyDonHangNoiBo.postman_collection.json
```

Cách dùng:

1. Mở Postman.
2. Import file collection.
3. Gọi request đăng nhập đúng role cần test.
4. Copy `accessToken`.
5. Gắn token vào header `Authorization`.
6. Test các nhóm API theo quyền của role đó.

## 5. Cách chạy dự án

### Bước 1: Kiểm tra .NET SDK

```bash
dotnet --version
```

Dự án đang dùng:

```text
net10.0
```

Vì vậy máy cần cài .NET SDK 10.

### Bước 2: Restore package

```bash
dotnet restore
```

### Bước 3: Build solution

```bash
dotnet build .\QuanLyDonHangNoiBo.sln
```

Hoặc:

```bash
dotnet build .\QuanLyDonHangNoiBo.sln --nologo
```

Kết quả mong muốn:

```text
Build succeeded.
0 Warning(s)
0 Error(s)
```

### Bước 4: Cấu hình connection string

File cấu hình development:

```text
QuanLyDonHangNoiBo.Api/appsettings.Development.json
```

Mặc định đang dùng SQL Server Express:

```json
{
  "UseSqlServer": true,
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS01;Database=QuanLyDonHangNoiBo;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
  }
}
```

Nếu máy dùng LocalDB, có thể đổi thành:

```json
{
  "UseSqlServer": true,
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=QuanLyDonHangNoiBoDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### Bước 5: Cài dotnet ef nếu chưa có

```bash
dotnet tool install --global dotnet-ef
```

Kiểm tra:

```bash
dotnet ef --version
```

### Bước 6: Tạo database bằng migration

```bash
dotnet ef database update --project .\QuanLyDonHangNoiBo.Infrastructure --startup-project .\QuanLyDonHangNoiBo.Api
```

Ý nghĩa:

- `--project`: project chứa migration và DbContext.
- `--startup-project`: project Web API chứa cấu hình appsettings.

### Bước 7: Chạy API

```bash
dotnet run --project .\QuanLyDonHangNoiBo.Api --launch-profile http
```

API chạy tại:

```text
http://localhost:5123
```

## 6. Các câu lệnh test đã dùng

### Test restore

```bash
dotnet restore
```

Mục đích:

- Kiểm tra project có tải được package hay không.
- Kiểm tra các project reference có hợp lệ không.

### Test build

```bash
dotnet build .\QuanLyDonHangNoiBo.sln --nologo
```

Kết quả build hiện tại:

```text
Build succeeded.
0 Warning(s)
0 Error(s)
```

### Test chạy API

```bash
dotnet run --project .\QuanLyDonHangNoiBo.Api --launch-profile http
```

Khi chạy thành công, terminal hiển thị API đang listen tại:

```text
http://localhost:5123
```

### Test đăng nhập theo phân quyền bằng curl

```bash
curl -X POST http://localhost:5123/api/auth/login ^
  -H "Content-Type: application/json" ^
  -d "{\"tenantCode\":\"demo\",\"email\":\"admin@demo.vn\",\"password\":\"Demo@123\",\"locale\":\"vi\"}"
```

Chọn email theo role cần test trong bảng tài khoản ở trên. Nếu dùng PowerShell, có thể test bằng:

```powershell
$body = @{
  tenantCode = "demo"
  email = "admin@demo.vn"
  password = "Demo@123"
  locale = "vi"
} | ConvertTo-Json

Invoke-RestMethod `
  -Method Post `
  -Uri "http://localhost:5123/api/auth/login" `
  -ContentType "application/json" `
  -Body $body
```

Kết quả mong muốn:

- Có `accessToken`.
- Có thông tin tenant.
- Có thông tin user.
- Có danh sách permission.

### Test API cần token bằng PowerShell

```powershell
$loginBody = @{
  tenantCode = "demo"
  email = "admin@demo.vn"
  password = "Demo@123"
  locale = "vi"
} | ConvertTo-Json

$login = Invoke-RestMethod `
  -Method Post `
  -Uri "http://localhost:5123/api/auth/login" `
  -ContentType "application/json" `
  -Body $loginBody

$headers = @{
  Authorization = "Bearer $($login.accessToken)"
}

Invoke-RestMethod `
  -Method Get `
  -Uri "http://localhost:5123/api/orders" `
  -Headers $headers
```

### Test dashboard

```powershell
Invoke-RestMethod `
  -Method Get `
  -Uri "http://localhost:5123/api/dashboard" `
  -Headers $headers
```

### Test tồn kho

```powershell
Invoke-RestMethod `
  -Method Get `
  -Uri "http://localhost:5123/api/inventory/stocks" `
  -Headers $headers
```

### Test danh sách giao hàng

```powershell
Invoke-RestMethod `
  -Method Get `
  -Uri "http://localhost:5123/api/delivery/shipments" `
  -Headers $headers
```

### Test demo readiness

```powershell
Invoke-RestMethod `
  -Method Get `
  -Uri "http://localhost:5123/api/demo/readiness" `
  -Headers $headers
```

## 7. Luồng test nghiệp vụ gợi ý

Sau khi đăng nhập bằng tài khoản có role phù hợp, có thể test theo thứ tự. Ví dụ `TenantAdmin`/`Manager` dùng để xem tổng quan, `Sales` dùng luồng đơn hàng, `Warehouse` dùng pick/pack, `Driver` dùng giao hàng, `Accountant` dùng COD.

### Luồng 1: Kiểm tra dữ liệu tổng quan

1. Gọi `GET /api/dashboard`.
2. Gọi `GET /api/notifications`.
3. Gọi `GET /api/metadata`.
4. Gọi `GET /api/demo/readiness`.

Mục đích:

- Kiểm tra API hoạt động.
- Kiểm tra dữ liệu seed đã có.
- Kiểm tra token có quyền đọc dashboard.

### Luồng 2: Quản lý đơn hàng

1. Gọi `GET /api/orders` để xem danh sách đơn.
2. Gọi `GET /api/orders/{orderId}` để xem chi tiết.
3. Gọi `POST /api/orders/{orderId}/confirm` để xác nhận đơn.
4. Gọi `POST /api/orders/{orderId}/status` để đổi trạng thái.
5. Gọi lại `GET /api/orders/{orderId}` để kiểm tra lịch sử trạng thái.

Mục đích:

- Kiểm tra luồng trạng thái đơn hàng.
- Kiểm tra lịch sử thay đổi trạng thái.
- Kiểm tra dữ liệu trả về theo DTO.

### Luồng 3: Quản lý tồn kho

1. Gọi `GET /api/inventory/stocks`.
2. Gọi `POST /api/inventory/stock-in`.
3. Gọi `POST /api/inventory/stock-out`.
4. Gọi `POST /api/inventory/adjustments`.
5. Gọi `GET /api/inventory/transactions`.

Mục đích:

- Kiểm tra số lượng tồn kho thay đổi.
- Kiểm tra có sinh lịch sử giao dịch kho.
- Kiểm tra nghiệp vụ nhập, xuất và điều chỉnh.

### Luồng 4: Pick-pack

1. Gọi `GET /api/picklists`.
2. Gọi `POST /api/picklists`.
3. Gọi `POST /api/picklists/{pickListId}/scan`.
4. Gọi `POST /api/packages`.
5. Gọi `GET /api/packages`.

Mục đích:

- Kiểm tra quy trình nhặt hàng.
- Kiểm tra scan SKU.
- Kiểm tra đóng gói sau khi pick.

### Luồng 5: Giao hàng và POD

1. Gọi `GET /api/delivery/shipments`.
2. Gọi `POST /api/delivery/shipments/{shipmentId}/assign`.
3. Gọi `POST /api/driver/shipments/{shipmentId}/status`.
4. Gọi `POST /api/delivery/shipments/{shipmentId}/pod`.
5. Gọi `GET /api/proof-of-deliveries`.

Mục đích:

- Kiểm tra phân công tài xế.
- Kiểm tra cập nhật trạng thái giao hàng.
- Kiểm tra upload bằng chứng giao hàng.

### Luồng 6: COD và hoàn trả

1. Gọi `GET /api/cod/collections`.
2. Gọi `POST /api/cod/reconcile`.
3. Gọi `GET /api/returns`.
4. Gọi `POST /api/returns`.
5. Gọi `POST /api/returns/{returnId}/status`.

Mục đích:

- Kiểm tra đối soát COD.
- Kiểm tra xử lý đơn hoàn trả.
- Kiểm tra trạng thái tài chính và vận hành.

## 8. Ví dụ body request

### Đăng nhập

```json
{
  "tenantCode": "demo",
  "email": "admin@demo.vn",
  "password": "Demo@123",
  "locale": "vi"
}
```

### Tạo khách hàng

```json
{
  "code": "CUS-NEW",
  "name": "Khách hàng mới",
  "phone": "0909000000",
  "email": "new.customer@example.vn",
  "address": "Quận 1, TP.HCM",
  "province": "TP.HCM",
  "segment": "Retail",
  "note": "Khách tạo từ API test"
}
```

### Điều chỉnh tồn kho

```json
{
  "warehouseId": "00000000-0000-0000-0000-000000000000",
  "skuId": "00000000-0000-0000-0000-000000000000",
  "quantity": 5,
  "reason": "Điều chỉnh tồn kho khi kiểm kê"
}
```

Lưu ý: Khi test thực tế, thay `warehouseId` và `skuId` bằng id lấy từ API danh sách kho và tồn kho.

## 9. Những thay đổi chính so với cấu trúc ban đầu

- Tách source code từ một Web API đơn giản thành solution nhiều project.
- Xóa cách gom entity/enum/service vào file lớn, thay bằng nhiều file nhỏ theo đúng trách nhiệm.
- Thêm Domain layer để chứa model nghiệp vụ.
- Thêm Application layer để chứa nghiệp vụ và DTO.
- Thêm Infrastructure layer để chứa repository, DbContext, migration và seed data.
- Thêm nhiều controller theo module thay vì một controller tổng hợp.
- Thêm JWT login và token generation.
- Thêm permission policy cho từng nhóm chức năng.
- Thêm middleware xử lý lỗi và logging.
- Thêm SignalR hub cho realtime demo.
- Thêm Postman collection để kiểm thử.
- Thêm README mô tả quá trình làm và cách chạy.

## 10. Ghi chú khi đưa lên GitHub

- Không commit secret thật lên GitHub.
- Nên đổi `Jwt:SigningKey` khi deploy hoặc demo công khai.
- Nếu máy khác không dùng `SQLEXPRESS01`, cần sửa connection string.
- Nên chạy `dotnet restore` và `dotnet build` sau khi clone repo.
- Nên import Postman collection để test theo từng role/permission.
- Thư mục `bin`, `obj`, `.vs` và các file local không cần đưa lên GitHub.

## 11. Kết quả hoàn thành

Sau khi hoàn thành, dự án có:

- Backend API chạy được bằng ASP.NET Core.
- Cấu trúc nhiều layer rõ ràng.
- Các module nghiệp vụ chính của hệ thống quản lý đơn hàng nội bộ.
- JWT authentication và authorization theo permission.
- Dữ liệu demo để test ngay.
- Migration SQL Server.
- Postman collection.
- README hướng dẫn quá trình làm, cách chạy và cách test.

Lệnh build kiểm tra cuối:

```bash
dotnet build .\QuanLyDonHangNoiBo.sln --nologo
```

Kết quả:

```text
Build succeeded.
0 Warning(s)
0 Error(s)
```
