## Entity Framework Core

*    [ ]  DbContext
## 
کلاس اصلی ارتباط بین برنامه و پایگاه‌داده در EF Core است. از طریق آن می‌توان داده‌ها را از دیتابیس خواند، ذخیره کرد یا تغییر داد. به نوعی مغز EF محسوب می‌شود که تمام عملیات داده‌ای از طریق آن انجام می‌گیرد.


*    [ ]  Entities And Configurations
## 
موجودیت یا Entities همان کلاس‌هایی هستند که نشان‌دهنده جدول‌های دیتابیس هستند. Configurations تنظیماتی‌اند که مشخص می‌کنند هر property از Entity چگونه در دیتابیس ذخیره شود (مثلاً طول رشته یا نوع ستون).

*    [ ] Navigation Property
## 
ویژگی‌هایی در Entity هستند که به موجودیت‌های دیگر اشاره می‌کنند. مثلاً اگر یک Student چند Course دارد، خاصیت Courses در کلاس Student یک navigation property است.
    
*    [ ] Configuration By Fluent API
## 
روشی برای تنظیم رفتار مدل‌ها در EF Core از طریق کد (نه attribute). در متد OnModelCreating از DbContext استفاده می‌شود تا نوع رابطه‌ها، کلیدها و سایر تنظیمات را دقیق کنترل کنیم.
    
*    [ ]  Entity Properties
## 
ویژگی‌های داخل کلاس‌های Entity هستند که مستقیماً به ستون‌های دیتابیس نگاشت می‌شوند. مثلاً Name, Age, یا Email در کلاس User.

*    [ ]  Keys
## 
کلید اصلی یا ترکیبی که رکوردها را در جدول یکتا می‌کند. EF از آن برای تشخیص موجودیت‌ها و به‌روزرسانی داده‌ها استفاده می‌کند.

*    [ ]  Default Values
##     
مقدار پیش‌فرضی است که اگر کاربر مقداری برای یک فیلد وارد نکند، به‌صورت خودکار تنظیم می‌شود (مثلاً Status = "Active").

*    [ ] Default Value
    
*    [ ] Computed Column
    
*    [ ] Value Code Generator
    
*   [ ] Concurrency Token
*   [ ] Shadow Properties
*   [ ] Relationship
*   [ ] Indexes
*   [ ] Inheritance
*   [ ] Sequence
*   [ ] Backing Field
*   [ ] Value Conversion
*   [ ] Value Comparer
*   [ ] Data Seeding
*   [ ] Table Splitting
*   [ ] Owned Entity Type
    
    ---
    
*   [ ] Migration
    
    ---
    
*   [ ] Where Did My Query Run
*   [ ] Tracking
*   [ ] Loading Related Data
*   [ ] Split Query
*   [ ] Raw SQL
*   [ ] DB Functions
*   [ ] Global Query Filter
*   [ ] Query Tag
*   [ ] Using Shadow Properties In Query
    
    ---
    
*   [ ] Saving Related Data
*   [ ] Transactions
*   [ ] Disconnected Entity
    
    ---
    
*   [ ] Attaching
*   [ ] Tracked Entities
*   [ ] Changes Detection
    
    ---
    
*   [ ] Logging
*   [ ] Events
*   [ ] Interceptors
    
    ---
    
*   [ ] Efficient Query And Command
*   [ ] Efficient Model
