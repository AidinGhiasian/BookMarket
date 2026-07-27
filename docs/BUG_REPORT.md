# گزارش تحلیل و بررسی پروژه BookMarket

> پروژه: ASP.NET Core 8 / Razor Pages / EF Core / SQL Server — معماری Clean-ish با لایه‌های Domain, Application, Infrastructure, ClientQueries, Web
> تاریخ بررسی: ۲۰۲۶-۰۷-۲۷

---

## 🔴 وضعیت اولیه: پروژه در وضعیت فعلی **Build هم نمی‌شود**

قبل از پرداختن به باگ‌های منطقی، باید مشکلاتی که باعث می‌شوند پروژه کامپایل نشود را برطرف کرد. این‌ها «خطای ساخت» هستند، نه باگ رانتایمی.

---

## بخش ۱ — باگ‌های سخت (Build/Compilation Errors) و روش حل

### 🐛 B1. namespace اشتباه کلاس `FileUploader`
**فایل:** `BookMarket/FileUploader.cs`
```csharp
namespace Services.Model   // ❌
```
اما اینترفیسش توی `Services/Application/IFileUploader.cs` در فضای‌نام `Services.Application` تعریف شده:
```csharp
namespace Services.Application { public interface IFileUploader { ... } }
```
همچنین `Program.cs` هم از `using Services.Model;` استفاده می‌کند.

**نتیجه:** DI در زمان اجرا نمی‌تواند `IFileUploader` را رزولوشن کند و اگر حتی بشود، بقیه کلاس‌ها (مثل `BookApplication`, `PostApplication`, …) که `using Services.Application;` دارند `FileUploader` را نمی‌بینند.

**✅ راه‌حل:**
فایل `BookMarket/FileUploader.cs` را ویرایش کن:
```csharp
using Services.Application;   // ← این را اضافه کن
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BookMarket          // ← یا Services.Application. پیشنهاد من: BookMarket
{
    public class FileUploader : IFileUploader { ... }
}
```
و `Program.cs` را اصلاح کن:
```csharp
// using Services.Model;  <-- حذف کن
using BookMarket;          // چون FileUploader الان namespace پروژه اصلی است
```

---

### 🐛 B2. عدم وجود ProjectReference به پروژه‌های لازم

#### B2-1. `AccountM.Application/AccountM.Application.csproj`
این پروژه از `Services.Application` (`IPasswordHasher`, `IAuthHelper`, `IFileUploader`, `Roles`, `OperationResult`, …) استفاده می‌کند اما به `Services.csproj` رفرنس نداده:
```xml
<ItemGroup>
  <ProjectReference Include="..\AccountM.Application.Contracts\AccountM.Application.Contracts.csproj" />
  <ProjectReference Include="..\AccountM.Domain\AccountM.Domain.csproj" />
  <!-- ❌ Missing: ../Services/Services.csproj -->
  <!-- ❌ Missing: ../AccountM.Infrastructure.EFCore و Repository اینترفیس‌ها هم بگردند -->
</ItemGroup>
```

**✅ راه‌حل:** داخل `<ItemGroup>` اضافه کن:
```xml
<ProjectReference Include="..\Services\Services.csproj" />
<ProjectReference Include="..\AccountM.Infrastructure.EFCore\AccountM.Infrastructure.EFCore.csproj" />
```

#### B2-2. `Blog.Infrastructure.EFCore/Blog.Infrastructure.EFCore.csproj`
این پروژه **وجود دارد** اما به عنوان csproj هیچ‌جا استفاده نمی‌شود و خودش به `Blog.Domain` ارجاع نمی‌دهد. به احتمال زیاد یک تکه دورریز (leftover) است. می‌توانی آن و `AM.Infrastructure` و `BM.Infrastructure.EFCore` و `AM.Infrastructure.Configoration` و `Book.Infrastructure.EFCore/BlogDbContext.cs` خالی (که یک کلاس خالی با نام مشابه در `Book.Infrastructure.EFCore` قرار دارد) را پاک کن.

> ⚠️ نکته: سه تا DbContext برای بلاگ در سه پروژه مختلف داری:
> - `Blog.Infrastructure.EFCore/BlogDbContext.cs` (خالی/ناقص)
> - `BlogM.Infrastructure/BlogDBContext.cs` (فقط `Posts` دارد)
> - `Book.Infrastructure.EFCore/BlogDbContext.cs` (کامل‌ترین، شامل Posts/Events/BlogCategories + Mapping)

و چند Bootstrapper تکراری/ناقص:
- `BookM.Infrastructure.Configoration` (خالی)
- `BookMInfrastructureConfigorationBootstraper` (فایل ناقص دارد + اسم‌گذاری فاجعه)
- `BookM.Infrastucure.Configoration` (اشتباه املایی «Infrastucure»)
- `BM.Infrastructure.Configoration` (برای بلاگ استفاده می‌شده اما ناقص)
- `AccountM.Infrastructure.DbContext` (پروژه خالی)

**✅ راه‌حل:** پوشه‌های زیر **حذف** شوند (حاوی کدهای تکراری/ناقص/بلااستفاده هستند):
```
AM.Infrastructure/
AM.Infrastructure.Configoration/
BM.Infrastructure.EFCore/
BM.Infrastructure.Configoration/
Blog.Infrastructure.EFCore/
Book.Infrastructure.EFCore/BlogDbContext.cs  // با BlogM.Infrastructure تداخل دارد
BookM.Infrastructure.Configoration/
BookM.Infrastucure.Configoration/            // غلط املایی
BookMInfrastructureConfigorationBootstraper/
AccountM.Infrastructure.DbContext/
BlogM.Infrastructure/                         // اگر جایی استفاده نشده حذف شود
```
بعد در `BookMarket.sln` از روی این پروژه‌ها `dotnet sln remove` بزن. و هر `using` و `ProjectReference` که به این‌ها اشاره می‌کند را به پروژه نهایی درست اشاره بده:
- بوت‌استرپر نهایی Book: `BookM.Infrastucure.Configoration` (فقط اسمش را به `BookM.Infrastructure.Configuration` تغییر بده)
- بوت‌استرپر نهایی Blog: `BlogM.Infrastructure.Configuration` (ولی باید `BlogDbContext` نهایی — همانی که در `Book.Infrastructure.EFCore` است — را ثبت کند)

#### B2-3. `BookMarket.csproj`
به `BookM.Infrastructure.EFCore` رفرنس نمی‌دهد ولی به `BookM.Application` وابسته است که به آن نیاز دارد؛ این را اضافه کن:
```xml
<ProjectReference Include="..\BookM.Infrastructure.EFCore\BookM.Infrastructure.EFCore.csproj" />
```

---

### 🐛 B3. متدهایی که امضایشان با اینترفیس سازگار نیست

#### B3-1. `IBookCategoryRepository` فقط `Deleted(int)` دارد، اما `BookCategoryApplication.cs` متدهای زیر را از ریپازیتوری می‌خواهد که موجود نیستند:
- `Add(T entity)`
- `GetById(int id)` (به جای `GetbyId`)
- `GetAll()`
- `SaveChanges()`

این‌ها در `RepositoryBase<T>` هستن ولی باید اینترفیس `IBookCategoryRepository` از `IRepositoryBase<BookCategories>` ارث‌بری کند (که **می‌کند** ✅). مشکل آنجاست که `RepositoryBase<T>` متدهای زیر را ندارد:
- `GetById(int id)` به‌صورت `GetById` نامیده شده (هست ✅)، اما در کدها `GetById` صدا زده می‌شود که اوکی‌ست.

#### B3-2. `BlogRepository` اینترفیسش را چک کن
فایل `BlogM.Infrastructure/BlogDBContext.cs` یک `DbSet<Posts>` دارد، اما `EventRepository` به `_blogdbcontext.Events` نیاز دارد که فقط در `Book.Infrastructure.EFCore/BlogDbContext` هست. این باعث می‌شود اگر از `BlogM.Infrastructure` استفاده کنی، `Events` موجود نباشد و خطای کامپایل بگیری.
✅ **راه‌حل:** بوت‌استرپر بلاگ (`BlogMInfrastructureConfigurationBootstraper.Configure`) باید از `Book.Infrastructure.EFCore.BlogDbContext` استفاده کند:
```csharp
// using BlogM.Infrastructure.EFCore;  // اشتباه
using Book.Infrastructure.EFCore;      // درست

services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
services.AddTransient<IBlogRepository, BlogRepository>();
services.AddTransient<IEventRepository, EventRepository>();
services.AddTransient<IBlogCategoryRepository, BlogCategoryRepository>();
```
و در فایل `Book.Infrastructure.EFCore/BlogM.Infrastructure.EFCore.csproj` مطمئن شو به `BlogM.Application.Contracts` رفرنس دارد (ندارد ❌ — باید اضافه شود، چون IBlogRepository/IEventRepository/IBlogCategoryRepository در بوت‌استرپر استفاده می‌شوند).

---

### 🐛 B4. namespace/اشتباهات Typo در using‌ها
- فایل `BookMarket/Pages/Accounts/login.cshtml.cs`:
  ```csharp
  using AM.Domain.Account.AD;   // ❌ Account در AccountM.Domain/Account.AD است نه AM.Domain
  ```
  درست:
  ```csharp
  using AccountM.Domain.Account.AD;
  using AccountM.Infrastructure.EFCore;   // اگر لازم بود
  ```
  در ضمن از `AccountM.Infrastructure.EFCore;` اصلاً در این صفحه استفاده نشده و از `BookM.ClientQueries.Model.Account.AccountViewModel` استفاده شده که درست است.

- فایل `CommentM.Infrastructure.EFCore/Repository/CommentRepository.cs`:
  ```csharp
  using Blog.Domain.BlogAD;
  using BookM.Domain.Book.AD;
  using CrystalDecisions.ReportAppServer;       // ❌ اضافی/موجود نیست
  using DocumentFormat.OpenXml.Office2010.Excel;
  using FLEXYGO.GoogleResourceTypes;            // ❌ اضافی
  using System.Net.Security;                    // ❌ اضافی
  ```
  این using‌های بی‌ربط را پاک کن.

- فایل‌های متعدد از `using DocumentFormat.OpenXml.Office2010.Excel;` و `using FLEXYGO.GoogleResourceTypes;` استفاده می‌کنند بدون اینکه به این پکیج‌ها رفرنس دهند. این‌ها احتمالاً به‌طور اتفاقی از زدن Alt+Enter اضافه شده‌اند. **پاکشان کن**.

---

### 🐛 B5. متد `BookApplication.Edit` بعد از ویرایش `SaveChanges` نمی‌کند!
**فایل:** `BookM.Application/BookApplication.cs` متد `Edit`:
```csharp
public void Edit(EditViewModel update)
{
    var upBooks = _bookRepository.GetById(update.Id);
    var PictureName = update.Picture;
    ...
    if (update.FileName != null) { ... }
    upBooks.Edit(PictureName, update.Picture, update.Writer, update.Publisher,
        update.CategoryId, update.status, npprice, update.shortdescription);
    // ❌ هیچ SaveChanges ای نیست!
}
```
**✅ راه‌حل:** در انتها اضافه کن:
```csharp
_bookRepository.SaveChanges();
```
همین مشکل در `EditViewModel.Picture` اشتباه به‌عنوان پارامتر دوم (`bookTitle`) به `Edit` پاس داده شده (به‌جای `update.BookTitle`):
```csharp
// ❌ الان:
upBooks.Edit(PictureName, update.Picture, update.Writer, ...)
// ✅ درست:
upBooks.Edit(PictureName, update.BookTitle, update.Writer, update.Publisher,
             update.CategoryId, update.status, npprice, update.shortdescription);
```

---

### 🐛 B6. `CommentRepository.ChangeStatus` همیشه Failed برمی‌گرداند
**فایل:** `CommentM.Infrastructure.EFCore/Repository/CommentRepository.cs`
```csharp
if (comment != null)
{
    comment.ChangeStatus(status);
    result.IsSuccess();            // ← نتیجه در result ذخیره می‌شود ولی...
    _commentDbContext.SaveChanges();
}
return result.Failed(...);         // ← ❌ همیشه این خط اجرا می‌شود!
```
**✅ راه‌حل:**
```csharp
if (comment != null)
{
    comment.ChangeStatus(status);
    _commentDbContext.SaveChanges();
    return result.IsSuccess();
}
return result.Failed(ApplicationMessage.NotFound);
```

---

## بخش ۲ — باگ‌های منطقی (منطق/رفتار اشتباه)

### 🐛 L1. در سازنده `Account` مقدیر `roleId` نادیده گرفته می‌شود!
**فایل:** `AccountM.Domain/Account.AD/Account.cs`
```csharp
public Account(... , int roleId, string? picture)
{
    ...
    RoleId = 1;   // ❌! پارامتر roleId هیچ استفاده‌ای نمی‌شود
}
```
یعنی **همه کاربران هنگام ثبت‌نام با roleId=1 (ادمین)** ساخته می‌شوند، در حالی که در `AccountApplication.Create` درست `Roles.User` (یعنی "2") به سازنده پاس داده می‌شود.
**✅ راه‌حل:**
```csharp
RoleId = roleId;
IsAvalable = true;
```

---

### 🐛 L2. در `Account.Edit` تاریخ ایجاد (CreationDate) به DateTime.Now ریست می‌شود!
```csharp
public void Edit(...)
{
    ...
    CreationDate = DateTime.Now;   // ❌ اشتباه بزرگ! تاریخ ساخت عوض می‌شود
    ...
}
```
**✅ راه‌حل:** این خط را حذف کن. برای ویرایش یک فیلد `UpdatedDate` اضافه کن (در صورت نیاز).

---

### 🐛 L3. صفحه Login به نتیجه `Login` توجه نمی‌کند
**فایل:** `BookMarket/Pages/Accounts/login.cshtml.cs`
```csharp
public IActionResult OnPostLogin(string? phone, string? password)
{
    _accountQueries.Login(phone, password);  // ❌ نتیجه نادیده گرفته می‌شود
    return RedirectToPage("/index");         // حتی اگر پسورد اشتباه باشد به صفحه اصلی می‌رود!
}
```
همچنین `Register` هم بدون بررسی نتیجه ریدایرکت می‌کند.

**✅ راه‌حل:**
```csharp
public IActionResult OnPostLogin(string? phone, string? password)
{
    var result = _accountQueries.Login(phone, password);
    if (!result.Success)
    {
        TempData["Error"] = result.Message ?? ApplicationMessage.NotFound;
        return Page();
    }
    return RedirectToPage("/Index");
}

public IActionResult OnPostRegister(CreateViewModel model)
{
    model.BirthDate = DateTime.Now;  // ❌ جالب نیست. BirthDate واقعی باید از کاربر گرفته شود
    model.Addres = " ";
    model.Email = " ";
    var result = _accountQueries.Register(model);
    if (!result.Success)
    {
        TempData["Error"] = result.Message;
        return Page();
    }
    return RedirectToPage("/Index");
}
```
همین الگو در `ChangePassword`، `OnPost(CreateViewModel)`، `CreateBook`، `CreateBlog` و … تکرار شده — **هیچ‌کدام از فرم‌ها نتیجه عملیات را چک نمی‌کنند**.

---

### 🐛 L4. صفحه `ChangePassword` احراز هویت را چک نمی‌کند و Id را از کلیم می‌خواند ولی از HttpGet در دسترس است
**فایل:** `BookMarket/Pages/Accounts/ChangePassword.cshtml.cs`
- صفحه `[Authorize]` ندارد. کاربر مهمان (Unauthenticated) می‌تواند به آن دسترسی داشته باشد.
- `OnPost` خروجی `OperationResult` را نادیده می‌گیرد و کاربر را به جایی هدایت نمی‌کند.
- `_accountApplicaiton.ChangePassword(newPassword)` ممکن است در صورت `null` بودن اکانت، `NullReferenceException` بدهد.

**✅ راه‌حل:**
```csharp
[Authorize]
public class ChangePasswordModel : PageModel { ... }

public IActionResult OnPost(string password, string rePassword)
{
    if (!ModelState.IsValid) return Page();
    var newPassword = new PasswordViewModel
    {
        Id = _authHelper.CurrentAccountId(),
        Password = password,
        RePassword = rePassword,
    };
    var res = _accountApplicaiton.ChangePassword(newPassword);
    if (!res.Success)
    {
        TempData["Error"] = res.Message;
        return Page();
    }
    return RedirectToPage("/Dashboard");
}
```

---

### 🐛 L5. عملیات‌های Delete/Restore با `First` بدون null-check → `InvalidOperationException`
**فایل:** `AccountM.Infrastructure.EFCore/Repository/AccountRepository.cs`
```csharp
var DA = _accountdbcontext.Account.First(x => x.Id == id);  // ❌ اگر پیدا نشه Exception
if (DA != null) { ... }   // First هرگز null برنمی‌گرداند، Exception می‌دهد
```
**✅ راه‌حل:** از `FirstOrDefault` استفاده کن (در `Delete`, `Restore`, و همین‌طور در `RoleRepository.updateby`, `BlogRepository.Delete`, `EventRepository.Delete`, `BookRepository.Updateby` هم چک کن):
```csharp
var DA = _accountdbcontext.Account.FirstOrDefault(x => x.Id == id);
if (DA == null) return;  // یا مناسب با نوع خروجی result.Failed
DA.ChangeStatus(false);
_accountdbcontext.SaveChanges();
```

---

### 🐛 L6. `SecurityPageFilter` در صورت نبود دسترسی به‌درستی درخواست را خاتمه نمی‌دهد
```csharp
if (!accountPermissions.Any(x => x == handlerPermission.Permission))
    context.HttpContext.Response.Redirect("/AccessDenied");
// ❌ بعد از Redirect کد ادامه پیدا می‌کند و handler هنوز اجرا می‌شود!
```
همچنین صفحه `/AccessDenied` در پروژه وجود ندارد.
**✅ راه‌حل:**
```csharp
if (!accountPermissions.Any(x => x == handlerPermission.Permission))
{
    context.Result = new RedirectToPageResult("/AccessDenied");
    // یا: context.Result = new ForbidResult();
    return;
}
```
یک صفحه `AccessDenied.cshtml` هم بساز.

---

### 🐛 L7. `AddRazorPages()` دوبار صدا زده شده
**فایل:** `Program.cs`
```csharp
builder.Services.AddRazorPages().AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(...)
...
builder.Services.AddRazorPages();  // ❌ فراخوانی مجدد
```
**✅ راه‌حل:** خط دوم را حذف کن.

---

### 🐛 L8. نقش‌ها با ClaimTypes.Role به‌صورت عدد ذخیره شده و با `RequireRole("Admin")` با مقدار "1" چک می‌شود ولی AuthHelper/Roles.GetRoleBy اشتباه تنظیم شده‌اند
**فایل:** `Services/Application/Roles.cs`
```csharp
public const string User  = "2";     // مقدار رشته
public const string Admin = "1";
public static string GetRoleBy(long id)
{
    switch (id)
    {
        case 2: return "مدیرسیستم";   // یعنی User=2 = مدیر؟!
        case 3: return "کاربر معمولی";
        default: return "";
    }
}
```
و در `AccountApplication.Create` موقع ساختن اکانت جدید `Convert.ToInt32(Roles.User)` یعنی 2 را به‌عنوان `roleId` داده، ولی در Account سازنده هم که به 1 ست می‌کند (باگ L1).

تناقضات:
- `Roles.Admin = "1"` ولی `GetRoleBy(1)` چیزی برنمی‌گرداند
- `Roles.User = "2"` ولی در دیتابیس roleId=1 ثبت می‌شود (به‌خاطر باگ L1)
- `RequireRole("Admin")` دنبال کلیمی با مقدار **"Admin"** می‌گردد، در حالی که کلیم ثبت شده `ClaimTypes.Role, account.RoleId.ToString()` یعنی "1"/"2" است → در نتیجه **هیچ‌کس ادمین شناخته نمی‌شود و Area/Admin برای همه 403 می‌دهد!**

**✅ راه‌حل:**
فایل Roles را اصلاح کن:
```csharp
public static class Roles
{
    public const string Admin = "Admin";
    public const string User  = "User";
    public static long AdminId = 1;
    public static long UserId  = 2;
}
```
هنگام `Signin`:
```csharp
new Claim(ClaimTypes.Role, account.RoleId == 1 ? Roles.Admin : Roles.User)
```
در `Account` سازنده `RoleId = roleId;` (باگ L1).
همه ارجاع‌های `Convert.ToInt32(Roles.User)` را به `Roles.UserId` تغییر بده.

---

### 🐛 L9. آپلود فایل آسیب‌پذیری Path Traversal و عدم اعتبارسنجی نوع فایل دارد
**فایل:** `BookMarket/FileUploader.cs`
```csharp
var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
```
- `file.FileName` می‌تواند شامل کاراکترهای `../` یا نام فایل مخرب مثل `../../appsettings.json` یا حاوی `;`/`<>` باشد.
- هیچ چک `file.Length` / whitelist extension (`.jpg,.png,.webp`) وجود ندارد.
- در `UploadNewSize` ابتدا `System.Drawing.Bitmap` را باز می‌کنی (`source_Bitmap`) ولی هیچ‌وقت `Dispose` نمی‌کنی و اصلاً ازش استفاده هم نمی‌کنی → memory leak روی لینوکس (System.Drawing.Common روی لینوکس کراس‌پلتفرم نیست، توصیه می‌شود فقط از ImageSharp استفاده کنی).
- سایز/حجم فایل چک نمی‌شود → می‌توانند فایل چندگیگابایتی آپلود کنند و سرور را down کنند.

**✅ راه‌حل (بازنویسی خلاصه):**
```csharp
static readonly string[] AllowedExt = { ".jpg", ".jpeg", ".png", ".webp" };
static readonly long MaxSizeBytes = 5 * 1024 * 1024; // 5MB

public string UploadNewSize(IFormFile file, string path, int width)
{
    if (file == null || file.Length == 0) return "";
    if (file.Length > MaxSizeBytes) throw new InvalidOperationException("حجم فایل زیاد است");

    var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
    if (!AllowedExt.Contains(ext)) throw new InvalidOperationException("نوع فایل مجاز نیست");

    // ⚠️ برای جلوگیری از Path Traversal
    var safeFolder = Path.GetFileName(path.TrimEnd('/', '\\')); // فقط نام آخرین پوشه
    var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "Pictures", safeFolder, width.ToString());
    Directory.CreateDirectory(directoryPath);

    var fileName = $"{DateTime.Now.ToFileName()}-{Guid.NewGuid():N}{ext}";
    var filePath = Path.Combine(directoryPath, fileName);

    using var image = Image.Load(file.OpenReadStream());
    image.Mutate(r => r.Resize(new ResizeOptions
    {
        Size = new Size(width, 0),
        Mode = ResizeMode.Max
    }));
    image.Save(filePath);

    return $"{safeFolder}/{width}/{fileName}";
}
```
متدهای `Delete` هم باید معکوس همین باشند و حتماً چک کنند که مسیر نهایی داخل `WebRootPath/Pictures` بماند:
```csharp
public void Delete(string pictureName)
{
    if (string.IsNullOrWhiteSpace(pictureName)) return;
    var fullPath = Path.GetFullPath(Path.Combine(_webHostEnvironment.WebRootPath, "Pictures", pictureName));
    var picturesRoot = Path.GetFullPath(Path.Combine(_webHostEnvironment.WebRootPath, "Pictures"));
    if (!fullPath.StartsWith(picturesRoot)) return; // جلوگیری از Path Traversal
    if (File.Exists(fullPath)) File.Delete(fullPath);
}
```

---

### 🐛 L10. ثبت‌نام رمز را بدون MinimumLength/تکرار می‌پذیرد، ایمیل/آدرس را با فضای خالی ذخیره می‌کند
**فایل:** `login.cshtml.cs`:
```csharp
model.BirthDate = DateTime.Now;   // یعنی تاریخ تولد همه زمان ثبت‌نام الان است
model.Addres = " ";
model.Email = " ";
```
این کار باعث خراب شدن داده‌ها می‌شود.
**✅ راه‌حل:**
- برای `Register` فقط `Name`, `Family`, `PhoneNumber`, `Password` را از کاربر بگیر، بقیه را در Dashboard/EditProfile ازش بگیر.
- `DataAnnotation` مثل `[Required]`, `[Phone]`, `[MinLength(6)]`, `[Compare(nameof(RePassword))]` روی `CreateViewModel` اضافه کن.
- قبل از ثبت چک کن که `PhoneNumber` تکراری نباشد (در غیر این صورت خطای EF درج شود). این متد در `AccountRepository` وجود ندارد.

---

### 🐛 L11. پرس‌وجوها با `.ToList()` قبل از Where → تمام جدول به حافظه می‌آید (Performance Bug)
**نمونه‌ها:**
- `BookRepository.GetBy(string title)`:
  ```csharp
  var Query = _bookdbcontext.Books.ToList();   // همه کتاب‌ها را از دیتابیس می‌کشد
  if (!string.IsNullOrWhiteSpace(title))
      Query = Query.Where(x => x.BookTitle.Contains(title)).ToList();
  ```
- `BlogRepository.Search(string title)` دقیقاً همین مشکل دارد.
- `BookQueries.GetAllBookWithCategory`: ابتدا `GetAll()` مواد به حافظه می‌آید بعد فیلتر می‌شود.
- `CommentRepository.GetComment` و `CommentStatus` هم بدون Include روی کل جدول می‌زنند.

**راه‌حل:** همه را به IQueryable در سمت SQL برگردان:
```csharp
public List<Books> GetBy(string title)
{
    IQueryable<Books> q = _bookdbcontext.Books.Include(b => b.Category);
    if (!string.IsNullOrWhiteSpace(title))
        q = q.Where(x => x.BookTitle.Contains(title));
    return q.ToList();
}
```
برای Contains بهتر است از `EF.Functions.Like` استفاده کنی، تا هم case-insensitive باشد و هم collation دیتابیس را رعایت کند.

---

### 🐛 L12. `CommentStatus` وقتی `ownerid=0` (int هیچ‌وقت null نیست!) همچنان روی آن فیلتر می‌زند
```csharp
if (status!=null)          // ❌ status int است و null نمی‌شود → همیشه true
{
    if (ownerid!=null)     // ❌ ownerid هم int است
    { ... return comments; }
}
return _commentDbContext.Comments.Where(x => x.IsStatus == status && x.OwnerId == ownerid).ToList();
//  در عمل هر دو if بلا استفاده‌اند
```
همین مشکل در `Pages/Admin/Comment/Index.cshtml.cs` هست: `public void OnGet(int isStatus)` ولی با `if(isStatus==null)` چک می‌شود.

**✅ راه‌حل:** پارامترها را `int?` (nullable) کن.

---

### 🐛 L13. متد `AccountRepository.ChangePassword` اساساً اشتباه نوشته شده
```csharp
public OperationResult ChangePassword(string password)
{
    var account = _accountdbcontext.Account.FirstOrDefault(y => y.Password == password);
    ...
}
```
یعنی پسورد **هش‌شده** را در دیتابیس پیدا می‌کند و دوباره همین را ست می‌کند! این متد به هیچ دردی نمی‌خورد و بلااستفاده مانده. در مقابل `AccountApplication.ChangePassword` درست از روی Id پیدا می‌کند.

**✅ راه‌حل:** این متد را از ریپازیتوری پاک کن. فقط یک متد برای Update/SaveChanges روی موجودیت کافی است.

---

### 🐛 L14. `BookCategoryEditViewModel` با `BookCategoryCreateViewModel.Property` ناسازگار
`BookCategoryEditViewModel.pictureName` با حرف کوچک نوشته شده، ولی در کدها به `Picture`, `PictureName` اشاره می‌شود → model-binding کار نمی‌کند و فایل/عکس جابجا نمی‌شود.
**✅ راه‌حل:** نام خاصیت را به `PictureName` با حرف P بزرگ تغییر بده.
همچنین `BookCategoryCreateViewModel` اصلاً فیلد `PictureName` یا `Slug` ندارد، در حالی که مدل دامنه `BookCategories` هم Slug نمی‌گیرد (بین باگ دسته‌بندی وبلاگ که Slug الزامی دارد و کتاب که ندارد، خلط شده).

---

### 🐛 L15. `BookCategoryRepository.Deleted` با `Find(id)` بدون چک کردن null حذف می‌کند
```csharp
var cat = _dbContext.BookCategories.Find(id);
_dbContext.BookCategories.Remove(cat);   // اگر cat=null باشد Exception
```
همچنین حذف دسته‌بندی، کتاب‌های زیرش را یتیم می‌کند (FK رفتار پیش‌فرض در EF Core برای required FK، cascade delete نیست اگر صریح نگفته باشی؛ برای ایمنی باید یا `IsDeleted` (soft-delete) پیاده‌سازی کنی یا از حذف سخت خودداری کنی).

---

### 🐛 L16. `AuthHelper.Signin` / `SignOut` await نمی‌شوند
```csharp
_contextAccessor.HttpContext.SignInAsync(...);  // Task برمی‌گرداند، آویت نمی‌شود
_contextAccessor.HttpContext.SignOutAsync(...);
```
در این حالت ممکن است عملیات وسط کار رها شود و SignOut واقعاً روی ریسپانس اعمال نشود.
**✅ راه‌حل:** متدها را `async` کن:
```csharp
public async Task SigninAsync(AuthViewModel account)
{
    ...
    await _contextAccessor.HttpContext.SignInAsync(...);
}
public async Task SignOutAsync()
{
    await _contextAccessor.HttpContext.SignOutAsync(...);
}
```
و در callerها `await` کن. یا اگر می‌خوای sync بمونه: `.GetAwaiter().GetResult()` — ولی توصیه می‌شود async باشد.

---

### 🐛 L17. هیچ `[ValidateAntiForgeryToken]` غیرفعال نشده و همه Razor Pages به‌صورت پیش‌فرض آن را دارند — این خوب است. ✅
اما صفحه‌های Admin که با `OnGetDelete`, `OnGetRestore`, `OnGetChangeStatus` عملیات تغییردهنده انجام می‌دهند **باید POST باشند**؛ با GET داده تغییر دادن هم ضد CSRF ضعیف است هم کش مرورگر/CDN می‌تواند لینک حذف را پری‌فچ کند و تصادفی حذف شود.

**✅ راه‌حل:** این handlerها را به `OnPostDelete`, `OnPostRestore`, `OnPostChangeStatus` تغییر بده و در cshtml از `<form method="post">` یا `<button asp-page-handler="Delete" asp-route-id="...">` استفاده کن.

---

### 🐛 L18. CORS به روی همه چیز AllowAll گذاشته شده و UseCors فراموش شده
```csharp
options.AddPolicy("AllowAll",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
```
ولی در pipeline هیچ‌کجا `app.UseCors("AllowAll");` صدا زده نشده. اگر API نیستی اصلاً نیازی به CORS نیست.
**✅ راه‌حل:** این قسمت را از Program.cs حذف کن. برای Razor Pages نیاز به CORS نداری.

---

### 🐛 L19. PasswordHasher از 10,000 تکرار استفاده می‌کند؛ با .NET 8 بهتر است از `PasswordHasher<TUser>` خود ASP.NET Core Identity استفاده کن
این هش امن است (PBKDF2-HMAC-SHA256, salt تصادفی)، اما در متد `Check` مقایسه با `SequenceEqual` **Timing-Safe نیست** و در معرض timing-attack قرار دارد.
**✅ راه‌حل:** یا از `CryptographicOperations.FixedTimeEquals` استفاده کن:
```csharp
var verified = CryptographicOperations.FixedTimeEquals(keyToCheck, key);
```
یا بهتر است برای کاهش ریسک، از `Microsoft.AspNetCore.Identity.PasswordHasher<TUser>` یا `BCrypt.Net-Next` استفاده کنی.

همچنین `Password` هنگام ورود در `AccountRepository.login` (متد اضافی) **plain-text** مقایسه می‌کند! مطمئن شو هیچ‌جا از آن استفاده نمی‌شود؛ توصیه می‌کنم این متد را کامل حذف کنی.

---

### 🐛 L20. فایل‌های مربوط به BookCategory/Book به‌صورت `string Price` تعریف شده‌اند
`Book.Price` رشته است در حالی که باید `decimal` یا `long` باشد. در غیر این‌صورت:
- نمی‌توانی جمع/مقایسه قیمت بکنی
- ورودی‌های غیرعدد باعث ناسازگاری می‌شوند
- جستجو/مرتب‌سازی قیمت به‌صورت lexicographical انجام می‌شود

**✅ راه‌حل:** `Price` را `public long Price { get; private set; }` (یا `decimal`) تعریف کن و در ViewModel ها هم نوع را تغییر بده؛ هرجا قیمت را نمایش می‌دهی از `ToMoney()` کمکی استفاده کن.

---

### 🐛 L21. `AuthHelper.CurrentAccountInfo` روی کلیم‌ها به‌صورت غیرایمن عمل می‌کند
```csharp
result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
```
اگر کلیمی پیدا نشود، `FirstOrDefault` null برمی‌گرداند و `.Value` روی null → `NullReferenceException`.
**✅ راه‌ححل:** از متد کمکی استفاده کن:
```csharp
static string? FindClaim(IEnumerable<Claim> claims, string type)
    => claims.FirstOrDefault(c => c.Type == type)?.Value;

var idStr = FindClaim(claims, "AccountId");
if (idStr == null || !long.TryParse(idStr, out var id)) return new AuthViewModel();
result.Id = id;
...
```

---

### 🐛 L22. فیلتر امنیتی فقط روی Handlerها اعمال می‌شود نه روی کل صفحات
`SecurityPageFilter` از `[NeedsPermission]` روی Handlerها استفاده می‌کند. اگر فراموش کنی روی یک handler بگذاری، به‌صورت پیش‌فرض دسترسی آزاد می‌شود. بهتر است یک `[AllowAnonymous]` به‌عنوان استثنا و به‌صورت پیش‌فرض همه نیاز به احراز هویت داشته باشند.

**✅ راه‌حل:** یک AuthorizeFilter سراسری اضافه کن:
```csharp
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");
    options.Conventions.AuthorizeFolder("/"); // همه‌چیز نیاز به ورود دارد مگر صریح AllowAnonymous
    options.Conventions.AllowAnonymousToPage("/Index");
    options.Conventions.AllowAnonymousToPage("/Book/Index");
    options.Conventions.AllowAnonymousToPage("/Book/BookDetails");
    options.Conventions.AllowAnonymousToPage("/Blog/Index");
    options.Conventions.AllowAnonymousToPage("/Blog/BLogDetails");
    options.Conventions.AllowAnonymousToPage("/Accounts/login");
    options.Conventions.AllowAnonymousToPage("/Privacy");
    options.Conventions.AllowAnonymousToPage("/Error");
    options.Conventions.AllowAnonymousToPage("/About");
    options.Conventions.AllowAnonymousToPage("/Search/Index");
})
.AddMvcOptions(o => o.Filters.Add<SecurityPageFilter>());
```

---

### 🐛 L23. صفحه لاگین LoginPath اشتباه تنظیم شده
```csharp
o.LoginPath = new PathString("/Account");
```
در حالی که صفحه لاگین تو در `/Accounts/login` است.
**✅ راه‌حل:**
```csharp
o.LoginPath  = new PathString("/Accounts/login");
o.LogoutPath = new PathString("/Accounts/Logout"); // یا /Dashboard?handler=Logout
o.AccessDeniedPath = new PathString("/AccessDenied");
```

---

### 🐛 L24. `Comment.Create` در BlogDetails مقدار OwnerId را از فرم می‌خواند ولی در BookDetails از `Id=Id` ست می‌کند
در `BLogDetails.cshtml.cs`:
```csharp
public IActionResult OnPost(CreateViewModel command)
{
    var resault = _commentApplication.Create(command);
    return RedirectToPage("./BlogDetails", new { id = command.OwnerId });
}
```
و در `Comments` سازنده `Type` را هیچ‌وقت ست نمی‌کند (همیشه 0 باقی می‌ماند) در حالی که در مدل برایش توضیح داده شده 1=Book, 2=Blog, 3=Event. همین باعث می‌شود فیلتر کامنت‌ها بین کتاب/بلاگ/رویداد قاطی شود.

**✅ راه‌حل:** یک فیلد `CommentType` به `CreateViewModel` اضافه کن (یا از route بگیر) و در سازنده:
```csharp
public Comments(string name, string message, int ownerId, int type)
{
    FullName = name;
    Message = message;
    OwnerId = ownerId;
    Type = type;
    CommentDatetime = DateTime.Now;
    IsStatus = 1;
}
```
و در BookDetails با type=1 و در BlogDetails با type=2 صدا بزن؛ در نمایش کامنت‌ها هم باید Type را فیلتر کنی (در حال حاضر صرفاً `OwnerId` را فیلتر می‌کنی — یعنی یک کامنت که در پست 5 ثبت شده زیر کتاب 5 هم نمایش داده می‌شود).

---

### 🐛 L25. ایندکس دسته‌بندی بلاگ `GetPostsWithCategory` باعث Cast Exception می‌شود
**فایل:** `BlogCategoryRepository.GetPostsWithCategory`:
```csharp
public BlogCategory GetPostsWithCategory()
{
    return (BlogCategory)_context.BlogCategories.Include(x => x.Posts); // ❌ کل DbSet را به یک انتیتی کست می‌کند → InvalidCastException
}
```
معلوم نیست هدف چه بوده. احتمالاً می‌خواسته `FirstOrDefault()` یا همه را برگرداند. بر اساس استفاده در `BlogCategoryQueries.GetPostsWithCategory` به‌نظر می‌رسد باید برای همه دسته‌ها آمار برگرداند. در هر صورت تابع در حال حاضر Exception می‌زند.

**✅ راه‌حل:** یا این متد را حذف کن یا به
```csharp
public List<BlogCategory> GetPostWithCategories()
{
    return _context.BlogCategories.Include(x => x.Posts)
        .Where(x => x.IsAvailable).ToList();
}
```
تغییر بده (همان `GetPostWithCategories` موجود است، پس `GetPostsWithCategory` باید حذف شود).

---

### 🐛 L26. `EditViewModel` در `BookApplication.Getdetail` اگر کتاب null باشد NRE می‌دهد
```csharp
public EditViewModel Getdetail(int id)
{
    var book = _bookRepository.GetById(id);
    return new EditViewModel
    {
        Id = book.Id, // اگر book=null → NullReferenceException
        ...
    };
}
```
در تمام `Getdetail`/`GetdetailInfo`/`GetById` سراسر اپلیکیشن این مشکل وجود دارد.
**✅ راه‌حل:**
```csharp
var book = _bookRepository.GetById(id);
if (book == null) return null;
return new EditViewModel { ... };
```
و در PageModel ها:
```csharp
Book = _bookApplication.Getdetail(id);
if (Book == null) return RedirectToPage("/NotFound");
```

---

### 🐛 L27. `OperationResult.Failed` اصلاً Message را ذخیره نمی‌کند!
```csharp
public OperationResult Failed(string message)
{
    Failure = true;
    return this;   // ❌ this.Message = message; فراموش شده
}
```
بنابراین هر پیام خطی که از Application برگردانده می‌شود از بین می‌رود.
**✅ راه‌حل:**
```csharp
public OperationResult Failed(string message)
{
    Failure = true;
    Success = false;
    Message = message;
    return this;
}
```
همچنین در `IsSuccess` هم `Message = message;` قرار بده تا پیام‌های موفق هم ذخیره شود.

---

### 🐛 L28. به‌جای Guid از Random برای SecurityCode استفاده می‌شود
```csharp
var random = new Random();
Scuritycode = random.Next(100000, 999999).ToString();
```
- `Random` از نظر رمزنگاری امن نیست
- در حلقه‌های کوتاه دو نمونه پشت سر هم یک عدد تولید می‌کند چون seed آن از ساعت سیستم است
- فیلد `Scuritycode` هیچ‌جای اپلیکیشن استفاده نمی‌شود (مرده‌کد). اگر قرار است برای فعال‌سازی موبایل باشد باید از `RandomNumberGenerator` استفاده شود و انقضا داشته باشد.

---

### 🐛 L29. HSTS در Development فعال نمی‌شود (خوب است) ولی در Production درصورتی‌که HTTPS واقعاً ستاپ نشده ممکن است loop بدهد. این مورد بحرانی نیست ولی `app.UseHsts()` بهتر است حذف شود اگر پشت reverse-proxy هستی و HTTPS را آنجا ترمینیت می‌کنی.
**پیشنهاد:** برای استقرار پشت Nginx/Cloudflare، `UseHttpsRedirection` را نیز از pipeline بردار یا در `appsettings.Production.json` غیرفعال کن.

---

## بخش ۳ — پیشنهادهای بهبود

1. **ساختار پروژه را تمیز کن**
   - پوشه‌های تکراری/ناقص را حذف کن (لیستش در B2-2 بالا داده شد).
   - غلط‌های املایی «Configoration»، «Infrastucure»، «Scuritycode»، «Categoreis»، «Addres»، «IsAvalable»، «resault»، «picturename»، «contectionstring» را درست کن (بعد از اصلاح، همه refactorها را با ابزار rename ویژوال استودیو بزن).
   - برای هر Bounded Context فقط *یک* پروژه Infrastructure.EFCore و *یک* Bootstrapper با نام استاندارد (`XxxInfrastructureConfigurationBootstrapper`) داشته باش.

2. **یک پروژه DbContext مشترک**
   - در حال حاضر 4 تا DbContext جدا (Account/Book/Blog/Comment) داری که همگی به همان یک DB اشاره می‌کنند. برای شروع اشکالی ندارد ولی باعث می‌شود Include بین موجودیت‌ها از contextهای مختلف کار نکند (مثل کتاب به کامنت). پیشنهاد می‌کنم در بلندمدت به یک DbContext مهاجرت کنی یا از Bounded Context درست استفاده کنی (هر context کانکشن‌استرینگ جدا با پسوند جدول مثلاً `BookMarket_Accounts` داشته باشد).

3. **از AutoMapper یا حداقل یک متد Map ثابت استفاده کن**
   - در حال حاضر `Map(...)` ده‌ها بار تکرار شده و فراموش می‌شود.

4. **Validation سمت سرور**
   - از `DataAnnotations` یا FluentValidation استفاده کن.
   - `PhoneNumber` باید با regex بررسی شود `^09\d{9}$`.
   - `Price` باید عدد مثبت باشد.
   - `Title` و `Name` نباید خالی و بیشتر از طول مشخص باشند.

5. **لاگینگ و مدیریت خطا**
   - یک `ExceptionHandlerMiddleware` یا صفحه Error واقعی بساز. در حال حاضر `Error.cshtml` صفحه جنریک است و exception details را در Development نشان می‌دهد ولی در Production درست کار می‌کند.
   - برای درخواست‌های ناموفق لاگ بزن.

6. **Pagination**
   - تمام GetAllها بدون صفحه‌بندی هستند → با رشد اطلاعات سایت قطعاً Down می‌کند.

7. **Seed داده اولیه**
   - یک کاربر ادمین پیش‌فرض باید در Migration اولیه ساخته شود؛ در حال حاضر هیچ seed نداری و با توجه به باگ Role (L8) عملاً نمی‌توانی به Admin وارد شوی.

8. **از TagHelperهای ASP استفاده کن**
   - در HTML ها به‌جای `name="phone"` از `asp-for="Phone"` استفاده کن تا validation خودکار و model-binding درست انجام شود.

9. **کد تکراری/مرده (dead code)** را پاک کن:
   - `AM.Infrastructure` کل
   - `BookM.Infrastructure.Configoration/Class1.cs`
   - `AccountMInfrastructureConfiguration/Permisions` فقط برای Account تعریف شده؛ بقیه ماژول‌ها PermissionExposer ندارند
   - متدهایی که هیچ‌جا استفاده نمی‌شوند (`Delete(string password)`, `ToWeekEnglishToFarsi` که در Tools دوبار از `i<10` حلقه بی‌هدف تکرار می‌کند)

10. **وابستگی به `System.Drawing.Common`**:
    - روی لینوکس درست کار نمی‌کند. چون در `FileUploader` از ImageSharp استفاده می‌کنی، System.Drawing را حذف کن و خط `new System.Drawing.Bitmap(...)` را از UploadNewSize پاک کن.

---

## گام به گام توصیه برای شروع اصلاح
1. ابتدا همه پوشه‌های تکراری/ناقص را حذف کن (B2-2).
2. غلط‌های namespace و reference در B1, B2-1, B2-3, B4 را اصلاح کن تا پروژه کامپایل شود.
3. باگ‌های قطعی که دیتا خراب می‌کنند را حل کن: L1 (RoleId), L2 (CreationDate), L27 (Failed message), B5 (SaveChanges Edit), B6 (ChangeStatus).
4. احراز هویت/مجوز را درست کن: L8 (نقش)، L23 (LoginPath)، L22 (Authorize conventions)، L6 (AccessDenied).
5. آپلود امن (L9) و حذف GETهای تغییردهنده (L17).
6. پرس‌وجوها را به IQueryable بازنویسی کن (L11).
7. مدل‌ها را تمیز کن (L20 Price=number, اعتبارسنجی).
8. AuthHelper و Signin را async/null-safe کن (L16, L21).
9. بقیه بهبودها را به تدریج اعمال کن.

---

> اگر می‌خواهی هر کدام از این باگ‌ها را با هم گام‌به‌گام اصلاح کنیم (کد دقیق قبل/بعد ببینی و در انتهای کار پروژه بیلد و اجرا شود)، بگو که با کدام بخش شروع کنیم. پیشنهاد من اول **B1 + B2** است تا پروژه از حالت کامپایل‌نشدن خارج شود.
