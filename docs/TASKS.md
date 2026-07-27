# BookMarket — تسک‌های اصلاح

پروژه BookMarket یک وب‌سایت فروش کتاب/بلاگ با ASP.NET Core 8 / Razor Pages / EF Core / SQL Server است.
این سند باگ‌ها را **به صورت تسک‌های مستقل** دسته‌بندی می‌کند؛ هر تسک را می‌توان در یک برنچ جدا انجام داد و در پایان آن پروژه باید همچنان کامپایل و اجرا شود.

> ⚠️ اکثر تغییرات این تسک‌ها **همینک در کد ریپو اعمال شده‌اند**. در هر تسک توضیح داده شده چه تغییرات داده شده و چه چیزهایی را باید خودت تکمیل کنی (مثلاً ساخت Migration جدید، اصلاح cshtml، یا تصمیم‌گیری درباره UI).

---

## 📋 مرور تسک‌ها

| # | تسک | حوزه | تخمین |
|---|-----|------|--------|
| 1 | پاک‌سازی فولدرهای تکراری/ناقص و نرمال‌سازی اسم‌گذاری | Infra / Cleanup | ۱ ساعت |
| 2 | رفع خطاهای کامپایل (namespace, using, csproj, duplicate DbContext) | Build | ۱ ساعت |
| 3 | ثبت صحیح سرویس‌ها در DI و یکپارچه‌سازی Blog DbContext | DI / Config | ۳۰ دقیقه |
| 4 | باگ‌های لایه داده (Repositoryها، null-check، IQueryable، SaveChanges، Delete/Restore) | Data / Logic | ۲ ساعت |
| 5 | هویت و مجوز (Auth/Role/Cookie/PasswordHash/SecurityFilter) | Security / Auth | ۲ ساعت |
| 6 | امن‌سازی آپلود فایل (Path Traversal / حجم / نوع فایل / حذف System.Drawing) | Security | ۱ ساعت |
| 7 | اصلاح Razor Pages (Login/Register/ChangePassword/Comment/Admin/CSRF/redirect) | Web / Logic | ۳ ساعت |
| 8 | اصلاح عملکرد کوئری‌ها (ToList قبل از Where، Includeها، Pagination) | Perf | ۱ ساعت |
| 9 | دسترسی صفحات (AllowAnonymous/Authorize conventions، AccessDenied) | Security / Web | ۱ ساعت |
| 10 | نرمال‌سازی دیتابیس (مپینگ‌ها، Migration جدید، Price به عدد) | Data / Schema | ۲ ساعت |
| 11 | بهبودهای پیشنهادی (Seed Admin، Validation، Logging، ابزار UI) | Features | به دلخواه |

---

## 🛠️ دستورالعمل کلی کار
1. برای هر Task یک برنچ جدید بساز: `git checkout -b fix/task-N-name`
2. تغییرات مربوط به همان تسک را اعمال کن (در این بررسی بخش عمده‌ای از تغییرات کد اعمال شده، تو باید آن‌ها را بازبینی کنی و اگر جایی تغییرات ناقص بود کامل کن).
3. با دستور زیر از کامپایل شدن مطمئن شو:
   ```bash
   dotnet restore
   dotnet build BookMarket.sln
   ```
4. Migration های لازم را بساز (به‌ویژه در Task 10):
   ```bash
   dotnet ef migrations add FixSchema_N --project BookM.Infrastructure.EFCore --startup-project BookMarket
   ```
   (برای هر DbContext باید جداگانه migration اضافه کنی).
5. تغییر را commit کن و PR بده.

---

## 🚧 قبل از همه: نصب پیش‌نیازها
- [.NET SDK 8](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB یا Express برای توسعه)
- EF Core tools: `dotnet tool install --global dotnet-ef`

---

## Task 1 — پاک‌سازی ساختار پروژه
**هدف:** حذف فولدرهای تکراری/ناقص/بلااستفاده تا ساختار ساده‌تر شود و کامپایل راحت‌تر.

### تغییرات اعمال‌شده در این بررسی
فولدرهای زیر **حذف شدند**:
- `AM.Infrastructure/` (کلاس تکراری AccountDbContext)
- `AM.Infrastructure.Configoration/`
- `BM.Infrastructure.EFCore/` (ناقص و تکراری)
- `BM.Infrastructure.Configoration/` (کلاس ناقص)
- `Blog.Infrastructure.EFCore/` (تکراری و ناقص)
- `BookM.Infrastructure.Configoration/` (خالی)
- `BookMInfrastructureConfigorationBootstraper/` (کلاس ناقص)
- `AccountM.Infrastructure.DbContext/` (خالی)
- `Book.Infrastructure.EFCore/BlogDbContext.cs` (تکراری، کامل‌ترش دوباره ساخته شد)

فولدر/فایل‌های زیر **تغییر نام/رفع غلط املایی** شدند:
- `BookM.Infrastucure.Configoration/` → `BookM.Infrastructure.Configuration/`
- `BookMInfrastucureConfiguration.csproj` → `BookM.Infrastructure.Configuration.csproj`
- `BookMInfrastructureConfigurationBootstraper.cs` → `BookMInfrastructureConfigurationBootstrapper.cs`
- فایل‌هایی که اسمشان انتهایشان space داشت (`IBlogCategoryRepository .cs`, `BlogCategoryMapping .cs`, `BlogCategoryRepository .cs`) اصلاح شدند.
- فایل Migrations بلاگ از `Repository/Migrations/` به `Migrations/` منتقل شد.

### کارهایی که تو باید انجام دهی
- بعد از حذف‌ها، در Visual Studio روی Solution راست کلیک کن و گزینه **"Remove folders that are no longer in the filesystem"** (یا در Solution Explorer گزینه "Reload") بزن تا پروژه‌های حذف‌شده از sln پاک شوند.
- با دستور زیر پروژه‌های باقی‌مانده را verify کن:
  ```bash
  dotnet sln list
  ```
- خروجی باید فقط این‌ها را داشته باشد:
  `AccountM.Domain`, `AccountM.Application`, `AccountM.Application.Contracts`, `AccountM.Infrastructure.EFCore`, `AccountM.Infrastructure.Configuration`,
  `BookM.Domain`, `BookM.Application`, `BookM.Application.Contracts`, `BookM.Infrastructure.EFCore`, `Book.Infrastructure.EFCore`, `BookM.Infrastructure.Configuration`, `BookM.ClientQueries`, `BookM.ClientQueries.Configuration`,
  `Blog.Domain`, `BlogM.Application`, `BlogM.Application.Contracts`, `BlogM.Infrastructure.Configuration`,
  `CommentM.Domain`, `CommentM.Application`, `CommentM.Application.Contracts`, `CommentM.Infrastructure.EFCore`, `CommentM.Infrastructure.Configuration`,
  `Services`, `BookMarket`.

---

## Task 2 — رفع خطاهای کامپایل
**هدف:** پروژه بعد از این تسک باید بدون خطا `dotnet build` شود.

### تغییرات اعمال‌شده
- **namespace صحیح `FileUploader`** از `Services.Model` به `BookMarket` تغییر کرد.
- **using های بی‌ربط** مثل `DocumentFormat.OpenXml.Office2010.Excel`, `FLEXYGO.GoogleResourceTypes`, `CrystalDecisions.ReportAppServer`, `System.Net.Security`, `System.Data.Entity`, `Microsoft.EntityFrameworkCore.Internal`, `AM.Domain.Account.AD` (غلط) از تمام صفحات حذف شد.
- **ProjectReference های گم‌شده** در csproj ها اضافه شد:
  - `AccountM.Application.csproj` حالا به `Services` و `AccountM.Infrastructure.EFCore` رفرنس می‌دهد.
  - `Book.csproj` (وب) به `BookM.Infrastructure.EFCore`, `Book.Infrastructure.EFCore`, `BookM.Infrastructure.Configuration`, `BlogM.Infrastructure.Configuration` رفرنس می‌دهد.
  - `BookM.ClientQueries.csproj` به `BookM.Application`, `CommentM.Application`, `Services` رفرنس می‌دهد.
  - `CommentM.Application.csproj` به `CommentM.Infrastructure.EFCore` و `Services` رفرنس می‌دهد.
  - `Book.Infrastructure.EFCore.csproj` بازنویسی شد با رفرنس‌های درست به `BlogM.Application.Contracts` و `Services`.
- namespace بلاگ در `Book.Infrastructure.EFCore` اصلاح شد:
  - مپینگ‌ها از `BlogM.Infrastructure.EFCore.Mapping` به `Book.Infrastructure.EFCore.Mapping`
  - ریپازیتوری‌ها از `BlogM.Infrastructure.EFCore.Repository` به `Book.Infrastructure.EFCore.Repository`

### کارهایی که تو باید انجام دهی
- `dotnet restore && dotnet build BookMarket.sln` را اجرا کن.
- اگر جایی خطای using/com reference دیدی، آن پکیج را از پروژه حذف کن (مثل `System.Drawing.Common`، `Flexygo`، `MailChimp.Net`, `MimeKit`, `RestSharp`, `SmsIrRestful` در `Services/Services.csproj` — اگر استفاده نمی‌شوند پاکشان کن).
- به‌ویژه `using Services.Application.Categoreis;` در صفحه `BookMarket/Pages/Accounts/login.cshtml.cs` باید حذف شود. (اگر کامپایلر خطا داد آن را حذف کن).

---

## Task 3 — ثبت سرویس‌ها در DI
**هدف:** هر DbContext یک‌بار ثبت شود و Bootstrapper های تکراری حذف شوند.

### تغییرات اعمال‌شده
- `BookMInfrastructureConfigurationBootstrapper` (در `BookM.Infrastructure.Configuration`) بازنویسی شد و حالا هم Book subsystem و هم Blog subsystem را ثبت می‌کند:
  - `IBookApplication`, `IBookRepository`, `IBookCategoryRepository`, `IBookCategoryApplication`, `IBookQueries`, `IBookCategoryQuery`, `BookDbContext`
  - `IPostApplication`, `IBlogRepository`, `IEventRepository`, `IEventApplication`, `IBlogCategoryApplication`, `IBlogCategoryRepository`, `IBlogCategoryQueries`, `IPostQueries`, `IEventQueries`, `BlogDbContext`
- `BlogMInfrastructureConfigurationBootstraper.Configure` به **no-op** تبدیل شد تا از دوبار ثبت‌شدن DbContext جلوگیری شود.
- `AccountMInfrastructureConfigurationBootstraper` اضافه شدن namespace های گم‌شده را پیدا کرد و رفع کرد.
- `CommentMInfrastructureConfigurationBootstraper` تغییر نداد، همان درست است.
- در `Program.cs`:
  - تکرار `AddRazorPages()` حذف شد.
  - CORS AllowAll (بدون استفاده) حذف شد.
  - ConnectionString چک می‌شود که null نباشد.
  - `IPasswordHasher` با `HashingOptions` و تعداد تکرار ۱۰۰٬۰۰۰ ثبت می‌شود (امن‌تر از ۱۰٬۰۰۰).
  - مسیر `LoginPath` از `/Account` به `/Accounts/login` و `AccessDeniedPath` به `/AccessDenied` اصلاح شد.

### کارهایی که تو باید انجام دهی
- پروژه را اجرا کن (`dotnet run --project BookMarket`) و مطمئن شو با خطای «Unable to resolve service ...» روبرو نمی‌شوی.
- صفحه `/Admin/...` را باز کن؛ باید به صفحه لاگین ریدایرکت شوی.

---

## Task 4 — اصلاح باگ‌های لایه داده
**هدف:** Repository ها امن‌تر و درست کار کنند.

### تغییرات اعمال‌شده
- `AccountRepository.Delete/Restore` از `First()` به `FirstOrDefault()` تغییر کرد و null-check اضافه شد.
- متد مرده `AccountRepository.login(password)` که پسورد را plain-text مقایسه می‌کرد حذف شد.
- متد `AccountRepository.ChangePassword(string password)` (کاملاً اشتباه بود، دنبال کاربر با همان هش پسورد می‌گشت) حذف شد.
- یک متد `GetbyId(int id)` به‌عنوان alias نگه داشته شد؛ اضافه بار `GetbyId(string phone)` هم به اینترفیس اضافه شد.
- `BookRepository` تمام متدهایش بازنویسی شد:
  - `GetBy(title)` به‌صورت IQueryable (قبل از ToList شرط می‌زند).
  - `GetAll` فقط کتاب‌های `IsAvailable=true` را برمی‌گرداند.
  - `GetById` با Include(Category).
  - `Delete` با null-check.
- `BookCategoryRepository.Deleted` حالا null-check دارد و اگر دسته کتاب داشته باشد Exception می‌دهد (تا FK Violation نخوری).
- `PostRepository` (Blog) بازنویسی شد: IQueryable برای Search، حذف using های اضافی، `GetAll` فقط IsAvailable=true.
- `EventRepository` بازنویسی شد: null-check ها، SaveChanges بعد از بلوک شرط.
- `BlogCategoryRepository` بازنویسی شد: متد InvalidCast دار `GetPostsWithCategory()` حذف شد (از `GetPostWithCategories` استفاده می‌شد).
- `CommentRepository` کاملاً بازنویسی شد:
  - `ChangeStatus` اشکال «همیشه Failed برمی‌گرداند» رفع شد.
  - `CommentStatus` و `GetComment` پارامتر `int?` (nullable) می‌گیرند و `type` را هم فیلتر می‌کنند (قاطی نشدن کامنت کتاب/بلاگ/رویداد).
- `RoleRepository` `GetDetails` را `Role?` برمی‌گرداند، متدهای `create/list/updateby` به فرم استاندارد `Create/List/UpdateAsync` تغییر نام یافتند.
- `RepositoryBase<T>`:
  - متدهای `GetById` و `GetByLongId` اکنون `T?` برمی‌گردانند.
  - یک متد `SaveChangesAsync` اضافه شد.
- `Account.RoleId` در سازنده درست ست می‌شود (`RoleId = roleId` نه `1`).
- `Account.Edit` دیگر `CreationDate = DateTime.Now` نمی‌کند (باعث از بین رفتن تاریخ ثبت بود).
- `Book.Price` از `string` به `long` تغییر کرد.
- `BookCategoryRepository` (Infrastructure.EFCore) و `BookDbContext` رابطه با cascade-restrict تنظیم شد.
- `BlogDbContext` کامل ساخته شد و شامل `Posts`, `Events`, `BlogCategories` به‌همراه مپینگ‌هاست.
- مپینگ‌های بلاگ (`PostsMapping`, `BlogCategoryMapping`) قیود دقیق‌تر و cascade-restrict تنظیم شدند.
- `CommentRepository.Add` به `Add` اصلاح شد (قاعدتاً از RepositoryBase استفاده می‌شد).

### کارهایی که تو باید انجام دهی
- با `dotnet build` مطمئن شو خطای تغییر `Price` به long رفع شده (هر cshtml که قیمت را نمایش می‌دهد ممکن است به `Model.Price.ToString("N0")` نیاز داشته باشد — چون الان عدد است).
- در `BookRepository.GetById` اگر می‌خواهی کتاب‌های غیرفعال هم در پنل ادمین نمایش داده شوند، شرط `IsAvailable` را برای `GetById` حذف کن (الان با Include همه را می‌آورد).
- متد `BookCategoryApplication.Delete` اگر می‌خواهی hard-delete نکنی، بهتر است soft-delete پیاده‌سازی کنی.

---

## Task 5 — هویت و مجوز (Auth)
**هدف:** ورود/خروج درست کار کند، نقش ادمین درست شناسایی شود، و هش رمز امن‌تر باشد.

### تغییرات اعمال‌شده
- **`Roles.cs`** بازنویسی شد:
  - ثابت `Admin = "Admin"` و `User = "User"` (به‌جای "1"/"2") چون `[Authorize(Roles="Admin")]` با نام نقش کار می‌کند نه Id.
  - ثابت‌های `AdminId = 1`, `UserId = 2`.
  - متدهای `GetRoleNameById` و `GetRoleFriendlyName` اضافه شد.
- **`AuthHelper`** بازنویسی شد:
  - متدها `async` شدند (`SigninAsync`, `SignOutAsync`) و await می‌شوند.
  - هنگام Signin هم `ClaimTypes.Role` با **نام** نقش (Admin/User) و هم با **Id** عددی ثبت می‌شود تا هم `[Authorize(Roles="Admin")]` کار کند و هم `RoleId` در دسترس باشد.
  - `CurrentAccountInfo` در برابر null ایمن شد (پیدا نبودن کلیم NRE نمی‌دهد).
  - `IsAuthenticated` با null-check تکمیل شد.
  - ادعای Mobile به‌صورت شرطی اضافه می‌شود.
- **`AccountApplication.LoginAsync`** (قبلاً `login`):
  - خالی بودن شماره/رمز چک می‌شود.
  - وضعیت فعال بودن اکانت بررسی می‌شود.
  - نتیجه هش با `CryptographicOperations.FixedTimeEquals` (در PasswordHasher) به‌صورت timing-safe بررسی می‌شود.
  - در صورت needsUpgrade، هش جدید در دیتابیس ذخیره می‌شود.
  - async/await با AuthHelper.
- **`PasswordHasher`**:
  - Iteration پیش‌فرض به ۱۰۰٬۰۰۰ افزایش یافت.
  - از `CryptographicOperations.FixedTimeEquals` برای مقایسه استفاده می‌کند (جلوگیری از timing attack).
  - مدیریت خطا (base64 نامعتبر) اضافه شد.
- **`SecurityPageFilter`** بعد از Redirect، درخواست را خاتمه می‌دهد (`context.Result = new RedirectToPageResult(...)`) تا handler اجرا نشود.
- **`OperationResult.Failed`** حالا `Message` را هم ذخیره می‌کند (قبلاً پیام خطا گم می‌شد).
- **`Account.cs`** سازنده از `RandomNumberGenerator` (به‌جای `Random`) برای تولید SecurityCode استفاده می‌کند.
- **Cookie** در Program.cs تنظیم شد: `HttpOnly = true`, `SecurePolicy = SameAsRequest`, `SameSite = Lax`.
- **`AccountRepository`** نام DbSet از `Account` (تکراری بود) سازگار با Migrationها ست شد.

### کارهایی که تو باید انجام دهی
- `ChangePassword` صفحه از `_accountApplicaiton.ChangePassword` نتیجه را چک می‌کند و ریدایرکت می‌کند (انجام شد).
- صفحه `Logout.cshtml` در Admin و Dashboard به OnPost async تبدیل شد.
- مطمئن شو در یک اکانت تستی با RoleId=1 می‌توانی به `/Admin` دسترسی داشته باشی. اگر هنوز در دیتابیس مدلی با Id=1 نداری، Task 11 (Seed Admin) را انجام بده.

---

## Task 6 — امن‌سازی آپلود فایل
**هدف:** آپلود آسیب‌پذیری Path Traversal، حجم، و نوع فایل نداشته باشد.

### تغییرات اعمال‌شده
**`FileUploader`** کامل بازنویسی شد:
- `AllowedImageExtensions = { .jpg, .jpeg, .png, .webp }`
- `MaxFileSizeBytes = 5 MB`
- `SanitizeFolder` از `Path.GetFileName` استفاده می‌کند تا پیمایش مسیر مثل `../../appsettings.json` ممکن نباشد.
- در `Delete` مسیر با `Path.GetFullPath` محاسبه و چک می‌شود که حتماً داخل `wwwroot/Pictures` بماند.
- فایل ریسایز شده با `Guid.NewGuid():N` نام‌گذاری می‌شود تا تضاد نام/آپلود روی فایل‌های موجود رخ ندهد.
- استفاده از `System.Drawing.Bitmap` (که روی لینوکس کار نمی‌کرد) کامل حذف شد؛ از `SixLabors.ImageSharp` برای Resize استفاده می‌شود.
- در زمان Resize از `ResizeMode.Max` استفاده می‌شود تا نسبت تصویر حفظ شود.

### کارهایی که تو باید انجام دهی
- مطمئن شو `System.Drawing.Common` از پکیج‌های Services.csproj حذف شده (چون دیگر استفاده نمی‌شود).
- یک تست دستی: سعی کن فایل `.exe` یا فایلی با نام `..\\..\\foo.jpg` آپلود کنی؛ باید خطا بدهد.
- اگر می‌خواهی آپلود غیرتصویر (PDF و ...) داشته باشی، `AllowedImageExtensions` را متناسب گسترش بده و Resize را برای آن‌ها bypass کن.

---

## Task 7 — اصلاح صفحات Razor
**هدف:** تمام فرم‌ها نتیجه OperationResult را چک کنند و تغییرات به GET انجام نشود.

### تغییرات اعمال‌شده
- **`login.cshtml.cs`** بازنویسی شد:
  - `OnPostLoginAsync` نتیجه `LoginAsync` را چک می‌کند، اگر ناموفق بود صفحه را با TempData["Error"] برمی‌گرداند.
  - `OnPostRegisterAsync` ModelState را چک می‌کند و try/catch دارد.
  - `[AllowAnonymous]` روی صفحه قرار گرفت.
- **`ChangePassword.cshtml.cs`** بازنویسی شد:
  - `[Authorize]` اضافه شد.
  - خالی بودن / یکسان نبودن رمز چک می‌شود.
  - نتیجه تغییر رمز بررسی و به Dashboard ریدایرکت می‌شود.
- **`Dashboard.cshtml.cs`** `[Authorize]` اضافه شد، `OnPostLogoutAsync` await می‌کند.
- **`BookDetails.cshtml.cs`**:
  - `[AllowAnonymous]`
  - قبل از استفاده از `Book.CategoryId` null بودن چک می‌شود.
  - هنگام ارسال کامنت `Type = Book (1)` ست می‌شود و نتیجه چک می‌گردد.
- **`BLogDetails.cshtml.cs`**:
  - کامنت‌ها با `Type = Blog (2)` ثبت می‌شوند.
  - null-check برای Post.
- **صفحات Admin**:
  - تمام صفحات Admin به‌جای `OnGetDelete` از `OnPostDelete` و مشابه استفاده می‌کنند تا CSRF محافظت شود (AntiForgeryToken به‌صورت پیش‌فرض در Razor Pages فعال است).
  - `Authorize(Roles="Admin")` به همه اضافه شد.
  - TempData برای success/error پیام تنظیم شد.
- **`Areas/Admin/Pages/Index.cshtml.cs`** (داشبورد ادمین):
  - به‌جای تغییر وضعیت در GET از OnPostApprove/OnPostReject استفاده می‌کند.
- **`Areas/Admin/Pages/Comment/Index.cshtml.cs`** و صفحات Account/Role/Book/Blog/Event/BlogCategory/Edit*/Create* همگی بازنویسی و POST-safe شدند.
- **`Pages/Book/Index.cshtml.cs`**, **`Pages/Blog/Index.cshtml.cs`**, **`Pages/Search/Index.cshtml.cs`**, **`Pages/Index.cshtml.cs`** همه `[AllowAnonymous]` گرفتند و null-check/ایمنی در مدل-binding اضافه شد.
- صفحه `AccessDenied.cshtml` + `AccessDenied.cshtml.cs` ساخته شد.
- `Logout.cshtml.cs` در پنل ادمین async شد.

### کارهایی که تو باید انجام دهی
- در فایل‌های `.cshtml` که از `asp-page-handler="Delete"` یا `asp-route-id` برای GET استفاده می‌کردند، باید به `<form method="post">` تغییر یابند. چون این تغییر محتاج بررسی همه viewهاست و در این تسک فایل‌های .cshtml تغییر نکردند. مثلاً در `AdminIndex.cshtml` جایی که لینک `<a asp-page-handler="Delete" ...>` دارید، به فرم زیر تغییر بده:
  ```html
  <form method="post" asp-page-handler="Delete" asp-route-id="@item.Id"
        onsubmit="return confirm('آیا مطمئن هستید؟');">
      <button type="submit" class="btn btn-danger btn-sm">حذف</button>
  </form>
  ```
- در `login.cshtml` و فرم‌های ثبت‌نام/ورود باید از `asp-for` استفاده کنی و متغیرهایی که در PageModel تعریف شده (`LoginPhone`, `LoginPassword`) را bind کنی. (در کد پشت‌صحنه به‌روش ساده‌تر با `asp-page-handler` کار می‌کند ولی `TempData["Error"]` را باید به‌صورت Alert در `_Layout` نمایش دهی.)

---

## Task 8 — بهبود عملکرد کوئری‌ها
**هدف:** از کشیدن تمام جدول به حافظه جلوگیری شود.

### تغییرات اعمال‌شده
- تمام متدهای Search/Filter (`BookRepository.GetBy(title)`, `BlogRepository.Search(title)`, `BookQueries.Search`, `PostQueries.Search`) به IQueryable بازنویسی شدند به‌طوری‌که فیلتر در SQL اعمال می‌شود.
- `GetAllBookWithCategory`, `GetAllBlogWithCategory` حالا به‌جای اینکه کل لیست را به حافظه بکشند، ابتدا Select می‌زنند.
- `CommentStatus`/`GetComment` هم شرط‌ها را در IQueryable می‌زنند.

### کارهایی که تو باید انجام دهی (اختیاری اما بسیار پیشنهادی)
- متد `GetAll()`ها در application ها را صفحه‌بندی (Pagination) کن، مثلاً با `Skip(page*size).Take(size)`.
- `BookQueries.Search` و `PostQueries.Search` فعلاً دوبار `Where` می‌زنند (یک‌بار در Repository یک‌بار در Queries)؛ بهتر است فیلتر را فقط در Repository انجام دهی.
- برای جستجو از `EF.Functions.Like` استفاده کن تا collation دیتابیس (case-insensitive) رعایت شود:
  ```csharp
  q = q.Where(x => EF.Functions.Like(x.BookTitle, $"%{title}%"));
  ```
- ایندکس مناسب روی ستون‌های `BookTitle`, `Title`, `PhoneNumber` در Migration ایجاد کن.

---

## Task 9 — تنظیمات دسترسی صفحات
**هدف:** به‌صورت سراسری `/` نیاز به ورود دارد، و فقط صفحات عمومی AllowAnonymous باشند.

### تغییرات اعمال‌شده
در `Program.cs` با `AddRazorPagesOptions` تنظیم شد:
```csharp
options.Conventions.AuthorizeFolder("/");
options.Conventions.AllowAnonymousToPage("/Index");
options.Conventions.AllowAnonymousToPage("/About");
options.Conventions.AllowAnonymousToPage("/Privacy");
options.Conventions.AllowAnonymousToPage("/Error");
options.Conventions.AllowAnonymousToPage("/AccessDenied");
options.Conventions.AllowAnonymousToPage("/Book/Index");
options.Conventions.AllowAnonymousToPage("/Book/BookDetails");
options.Conventions.AllowAnonymousToPage("/Blog/Index");
options.Conventions.AllowAnonymousToPage("/Blog/BLogDetails");
options.Conventions.AllowAnonymousToPage("/Accounts/login");
options.Conventions.AllowAnonymousToPage("/Search/Index");
options.Conventions.AllowAnonymousToPage("/Product");
options.Conventions.AllowAnonymousToPage("/Cart");
options.Conventions.AllowAnonymousToPage("/WishList");
options.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");
```

### کارهایی که تو باید انجام دهی
- بسته به نیاز سایتت اگر صفحه‌دیگری عمومی است (مثلاً `/Event/Index` اگر ساختی)، `AllowAnonymousToPage` کن.
- برای صفحات اکانت کاربران مثل `/Accounts/ChangePassword`, `/Dashboard` نیازی به تنظیم اضافی نیست چون زیر پوشه `/` هستند و پیش‌فرض نیاز به ورود دارند.

---

## Task 10 — Migration دیتابیس و اصلاح Schema
**هدف:** تغییرات مپینگ و Price به long در دیتابیس اعمال شود.

### تغییرات اعمال‌شده
- `Book.Price` به `long` تغییر کرد.
- فیلدهای `Picture` در `BlogCategory`, `Posts`, `BookCategories` به `IsRequired(false)` تغییر کرد (تصویر اختیاری).
- طول `ShortDescription` به ۱۰۰۰ و `Description` در پست به MaxLength افزایش یافت.
- FK ها برای Blog cascade restrict شد.

### کارهایی که تو باید انجام دهی
1. مطمئن شو دیتابیس‌های محلی در connection string در دسترس هستند:
   ```json
   "ConnectionStrings": {
     "DbBookMarket": "Server=(localdb)\\mssqllocaldb;Database=BookMarket;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
   }
   ```
2. برای هر DbContext migration بساز:
   ```bash
   dotnet ef migrations add Fix_PriceTypeAndNullability --project BookM.Infrastructure.EFCore --startup-project BookMarket --context BookDbContext
   dotnet ef migrations add Fix_BlogNullability        --project Book.Infrastructure.EFCore  --startup-project BookMarket --context BlogDbContext
   dotnet ef migrations add Fix_AccountNullability     --project AccountM.Infrastructure.EFCore --startup-project BookMarket --context AccountDbContext
   ```
   (برای CommentDbContext اگر تغییری داری همین کار را انجام بده).
3. Migrationها را اعمال کن:
   ```bash
   dotnet ef database update --project BookM.Infrastructure.EFCore --startup-project BookMarket --context BookDbContext
   dotnet ef database update --project Book.Infrastructure.EFCore --startup-project BookMarket --context BlogDbContext
   dotnet ef database update --project AccountM.Infrastructure.EFCore --startup-project BookMarket --context AccountDbContext
   dotnet ef database update --project CommentM.Infrastructure.EFCore --startup-project BookMarket --context CommentDbContext
   ```
   ⚠️ چون Price از nvarchar به bigint تغییر می‌کند، در Migration داده‌های قبلی ممکن است Convert fail شوند. اگر قیمت‌ها صرفاً عددی بوده باشند EF به‌صورت خودکار `ALTER COLUMN` می‌سازد. اگر داده نامعتبر داری، قبل از migration دستی پاک‌سازی کن.
4. اگر می‌خواهی Price به decimal (برای ریال با دقت بیشتر) تغییر یابد، بهتر است `long` را به `decimal(18,0)` تغییر دهی.

---

## Task 11 (اختیاری) — Seed Admin و بهبودها
### 11-1. Seed داده اولیه
یک کاربر ادمین پیش‌فرض با استفاده از `IHostedService` یا در `Program.cs` با scopeFactory بساز:
```csharp
using (var scope = app.Services.CreateScope())
{
    var accCtx = scope.ServiceProvider.GetRequiredService<AccountDbContext>();
    accCtx.Database.EnsureCreated();
    if (!accCtx.Accounts.Any(a => a.RoleId == 1))
    {
        var role = new Role("Admin", new List<Permission>(), "مدیر سیستم");
        accCtx.Roles.Add(role);
        accCtx.SaveChanges();
        // هش رمز 123456 با IPasswordHasher
        var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var admin = new Account("ادمین", "اصلی", "09120000000", "", DateTime.Now, "", hasher.Hash("Admin@123"), 1, null);
        accCtx.Accounts.Add(admin);
        accCtx.SaveChanges();
    }
}
```
این را **بعد از `Build()` و قبل از `app.Run()`** در Program.cs قرار بده.

### 11-2. Validation
از DataAnnotations یا `FluentValidation` روی ViewModel ها استفاده کن:
- `PhoneNumber`: اجباری، با الگو `09[0-9]{9}`
- `Password`: حداقل ۶ کاراکتر
- `Price`: عدد مثبت
- `Title`/`Name`: غیرخالی و کمتر از ۲۰۰ کاراکتر

### 11-3. نمایش پیغام‌ها
یک Partials `_Alerts.cshtml` بساز و در `_Layout` آن را render کن تا `TempData["Error"]` و `TempData["Success"]` به‌صورت SweetAlert2 یا Bootstrap Alert نمایش داده شوند.

### 11-4. Logging
در `Program.cs` لاگ‌گیری را در Production با Serilog یا حداقل `app.UseDeveloperExceptionPage()` در Development بهبود بده.

### 11-5. جلوگیری از CSRF برای GET حذف
همان‌طور که در Task 7 گفته شد، تمام لینک‌های «حذف/تایید/رد» را به form با method="post" تبدیل کن.

### 11-6. حذف پکیج‌های بلااستفاده
- `System.Drawing.Common` (دیگر استفاده نمی‌شود، با ImageSharp جایگزین شد)
- `MailChimp.Net`, `MimeKit`, `RestSharp`, `SmsIrRestful`, `Flexygo` — اگر ازشان استفاده نمی‌کنی از `Services.csproj` حذف کن.
- `Microsoft.AspNetCore.Http.Features (5.0.17)` و `Microsoft.AspNetCore.Authentication.Cookies (2.2.0)` و `Microsoft.AspNetCore.Mvc.Abstractions (2.2.0)` نسخه‌هایشان با NET 8 هم‌خوان نیستند؛ به نسخه 8 به‌روز کن یا حذف (چون NET8 به‌صورت پیش‌فرض این‌ها را دارد).

---

## ✅ لیست چک‌نهایی
- [ ] `dotnet build BookMarket.sln` بدون خطا اجرا می‌شود.
- [ ] Migrationها اعمال شده‌اند.
- [ ] با کاربر ادمین می‌توانم به `/Admin` بروم.
- [ ] کاربر می‌تواند ثبت‌نام کند (با RoleId=2).
- [ تغییر رمز کاربر کار می‌کند.
- [ ] کتاب جدید آپلود می‌شود و عکس در `wwwroot/Pictures/Book/720/` ذخیره می‌شود.
- [ ] جستجوی کتاب/بلاگ بدون کندی کار می‌کند.
- [ ] کامنت‌ها در سایت نمایش داده می‌شوند و فقط کامنت‌های Approved در صفحه ظاهر می‌شوند.
- [ ] عملیات حذف از طریق لینک GET (با باز کردن مستقیم URL) قابل انجام نیست.
- [ ] آپلود فایل غیرتصویری پسوند `exe/...` بلوکه می‌شود.
- [ ] دسترسی به `/Admin` برای کاربر غیرادمین به `/AccessDenied` می‌رود.

---

> اگر در انجام هر تسک به مشکلی برخوردی یا خواستی بقیه بخش‌های View/HTML را هم به‌صورت اصولی اصلاح کنیم، بگو که ادامه بدهیم.
