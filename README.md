# LSW.BlockChain
ASP.Net Core 3.0+Blazor ServerSide+SignalR区块链项目演示

同时亦作为Blazor CRUD的参考
# How To
若想体验区块链校验的效果，可以这样做
1. 克隆代码
```bash
git clone https://github.com/lishewen/LSW.BlockChain.git 
```
2. 修改数据库连接，使用非InMemoryDatabase，如使用SQL Server
```csharp
services.AddDbContextPool<EFContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```
3. 下载`dotnet ef`工具，并执行数据迁移生成数据库
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add MyFirstMigration
dotnet ef database update
```
4. 运行网站并到Card List的Details处，随意添加几条销售记录，此时可以看到销售记录的`IsValid`为`True`
5. 直接到数据库中修(篡)改`CardSalesEntries`表中某条销售记录的金额`Price`
6. 回到网站上刷新查看销售记录，发现被修改的销售记录及其后面的记录`IsValid`为`False`，即数据被篡改，区块链的校验失败，后面的链条断掉了

以上即区块链校验的简单演示，只是给入门者了解其大概工作原理，当然不能直接用于生产

Enjoy!:)