[![GitHub license](https://img.shields.io/github/license/talhakoylu/ReCapProject?style=for-the-badge)](https://github.com/talhakoylu/ReCapProject/blob/master/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/talhakoylu/ReCapProject?style=for-the-badge)](https://github.com/talhakoylu/ReCapProject/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/talhakoylu/ReCapProject?style=for-the-badge)](https://github.com/talhakoylu/ReCapProject/network)
<a href="https://www.linkedin.com/in/talhakoylu/">
    <img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white" />
</a>
<a href="https://www.twitter.com/talhakoylu/">
    <img src="https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white" />
</a>

<p align="center"><img src="https://i.imgur.com/S7YH4eA.png" width = 500px ></p>

# ReCap Project
A car rental project developed with C# and .Net Core Framework. In development phase, N-Layered Architecture model was followed.
You can perform basic CRUD operations with this program. Also, this program has JWT Bearer system. 
CRUD operaitons will work if the user has right claims. For caching, all of the listing and query processes (except add, update, delete) are 
saved on local storage for an hour.

## Used Technologies and Their Versions
[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net-web-api](https://img.shields.io/badge/ASP.NET%20Web%20API-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework-Core](https://img.shields.io/badge/EntityFramework%20Core-v3.1.1-informational?style=for-the-badge&logo=nuget)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac-v6.1-informational?style=for-the-badge&logo=nuget)](https://autofac.org/)
[![Fluent-Validation](https://img.shields.io/badge/FluentValidation-v9.5.1-informational?style=for-the-badge&logo=nuget&labelColor=orange)](https://fluentvalidation.net/)

## Layers
### Business Layer
Business layer is contain business and logic rules. And also contains service and manager classes.

<details>
  <summary>Business Layer File Structure</summary>      
    <br> 
    
        Business
          |-- Abstract
          |   |-- IAuthService.cs
          |   |-- IBrandService.cs
          |   |-- ICarImageService.cs
          |   |-- ICarService.cs
          |   |-- IColorService.cs
          |   |-- ICustomerService.cs
          |   |-- IPaymentService.cs
          |   |-- IRentalService.cs
          |   |-- IUserService.cs
          |-- Business.csproj
          |-- BusinessAspects
          |   |-- Autofac
          |   |   |-- SecuredOperation.cs
          |-- Concrete
          |   |-- AuthManager.cs
          |   |-- BrandManager.cs
          |   |-- CarImageManager.cs
          |   |-- CarManager.cs
          |   |-- ColorManager.cs
          |   |-- CustomerManager.cs
          |   |-- PaymentManager.cs
          |   |-- RentalManager.cs
          |   |-- UserManager.cs
          |-- Constants
          |   |-- Messages.cs
          |-- DependencyResolvers
          |   |-- Autofac
          |   |   |-- AutofacBusinessModule.cs
          |-- ValidationRules
          |   |-- FluentValidation
          |   |   |-- BrandValidator.cs
          |   |   |-- CarImageValidator.cs
          |   |   |-- CarValidator.cs
          |   |   |-- ColorValidator.cs
          |   |   |-- CustomerValidator.cs
          |   |   |-- RentalValidator.cs
          |   |   |-- UserValidator.cs
</details>

### ConsoleUI Layer
Before building the WebAPI layer, this layer used for service tests.

<details>
  <summary>ConsoleUI Layer File Structure</summary>      
  <br>
  
        ConsoleUI
           |   |-- ConsoleUI.csproj
           |   |-- Program.cs
</details>

### Core Layer
The most important layer of the project is Core Layer. Core layer contain general rules and functions. That's why, Core doesn't have any dependency to another layer. Core layer is the heart of the project. Aspects (validation, cache, performance etc.), Cross Cutting Conserns (Cache, Validation), general entities and bases, Extensions, Utilities (Security, Result structure, IoC etc.) are located in this layer.

<details>
  <summary>Core Layer File Structure</summary>      
  <br>
  
        Core
           |   |-- Aspects
           |   |   |-- Autofac
           |   |   |   |-- Caching
           |   |   |   |   |-- CacheAspect.cs
           |   |   |   |   |-- CacheRemoveAspects.cs
           |   |   |   |-- Performance
           |   |   |   |   |-- PerformanceAspect.cs
           |   |   |   |-- Transaction
           |   |   |   |   |-- TransactionScopeAspect.cs
           |   |   |   |-- Validation
           |   |   |   |   |-- ValidationAspect.cs
           |   |-- Core.csproj
           |   |-- CrossCuttingConcerns
           |   |   |-- Caching
           |   |   |   |-- ICacheManager.cs
           |   |   |   |-- Microsoft
           |   |   |   |   |-- MemoryCacheManager.cs
           |   |   |-- Validation
           |   |   |   |-- FluentValidation
           |   |   |   |   |-- ValidationTool.cs
           |   |-- DataAccess
           |   |   |-- EntityFramework
           |   |   |   |-- EfEntityRepositoryBase.cs
           |   |   |-- IEntityRepository.cs
           |   |-- DependencyResolvers
           |   |   |-- CoreModule.cs
           |   |-- Entities
           |   |   |-- Concrete
           |   |   |   |-- OperationClaim.cs
           |   |   |   |-- OperationClaimDto.cs
           |   |   |   |-- User.cs
           |   |   |   |-- UserOperationClaim.cs
           |   |   |-- IDto.cs
           |   |   |-- IEntity.cs
           |   |-- Extensions
           |   |   |-- ClaimExtensions.cs
           |   |   |-- ClaimsPrincipalExtensions.cs
           |   |   |-- ErrorDetails.cs
           |   |   |-- ExceptionMiddleware.cs
           |   |   |-- ExceptionMiddlewareExtensions.cs
           |   |   |-- ServiceCollectionExtensions.cs
           |   |-- Utilities
           |   |   |-- Business
           |   |   |   |-- BusinessRules.cs
           |   |   |-- Helpers
           |   |   |   |-- FileHelper.cs
           |   |   |-- Interceptors
           |   |   |   |-- AspectInterceptorSelector.cs
           |   |   |   |-- MethodInterception.cs
           |   |   |   |-- MethodInterceptionBaseAttribute.cs
           |   |   |-- IoC
           |   |   |   |-- ICoreModule.cs
           |   |   |   |-- ServiceTool.cs
           |   |   |-- Results
           |   |   |   |-- DataResult.cs
           |   |   |   |-- ErrorDataResult.cs
           |   |   |   |-- ErrorResult.cs
           |   |   |   |-- IDataResult.cs
           |   |   |   |-- IResult.cs
           |   |   |   |-- Result.cs
           |   |   |   |-- SuccessDataResult.cs
           |   |   |   |-- SuccessResult.cs
           |   |   |-- Security
           |   |   |   |-- Encryption
           |   |   |   |   |-- SecurityKeyHelper.cs
           |   |   |   |   |-- SigningCredentialsHelper.cs
           |   |   |   |-- Hashing
           |   |   |   |   |-- HashingHelper.cs
           |   |   |   |-- JWT
           |   |   |   |   |-- AccessToken.cs
           |   |   |   |   |-- ITokenHelper.cs
           |   |   |   |   |-- JwtHelper.cs
           |   |   |   |   |-- TokenOptions.cs


</details>

### DataAccess Layer
EntityFramework configurations were located in this layer. DataAccessLayer classes also located in this layer. Every process in DataAccess layers are responsible for the database connectivity.
<details>
  <summary>DataAccess Layer File Structure</summary>      
  <br>
  
         DataAccess
           |   |-- Abstract
           |   |   |-- IBrandDal.cs
           |   |   |-- ICarDal.cs
           |   |   |-- ICarImageDal.cs
           |   |   |-- IColorDal.cs
           |   |   |-- ICustomerDal.cs
           |   |   |-- IPaymentDal.cs
           |   |   |-- IRentalDal.cs
           |   |   |-- IUserDal.cs
           |   |-- Concrete
           |   |   |-- EntityFramework
           |   |   |   |-- Context
           |   |   |   |   |-- ReCapProjectContext.cs
           |   |   |   |-- EfBrandDal.cs
           |   |   |   |-- EfCarDal.cs
           |   |   |   |-- EfCarImageDal.cs
           |   |   |   |-- EfColorDal.cs
           |   |   |   |-- EfCustomerDal.cs
           |   |   |   |-- EfPaymentDal.cs
           |   |   |   |-- EfRentalDal.cs
           |   |   |   |-- EfUserDal.cs
           |   |   |-- InMemory
           |   |   |   |-- InMemoryBrandDal.cs
           |   |   |   |-- InMemoryCarDal.cs
           |   |   |   |-- InMemoryColorDal.cs
           |   |-- DataAccess.csproj

</details>

### Entities Layer
Created objects for database tables are in this layer.

<details>
  <summary>Entities Layer File Structure</summary>      
  <br>
  
         Entities
           |   |-- Concrete
           |   |   |-- Brand.cs
           |   |   |-- Car.cs
           |   |   |-- CarImage.cs
           |   |   |-- Color.cs
           |   |   |-- Customer.cs
           |   |   |-- Payment.cs
           |   |   |-- Rental.cs
           |   |-- DTOs
           |   |   |-- CarDetailDto.cs
           |   |   |-- CustomerDetailDto.cs
           |   |   |-- PaymentDto.cs
           |   |   |-- RentalDetailDto.cs
           |   |   |-- UserForLoginDto.cs
           |   |   |-- UserForRegisterDto.cs
           |   |-- Entities.csproj
</details>

### WebAPI Layer
Our project became online with the WebAPI layer. Wrote controllers for every business services. In this way, we can control the project on the web. WebAPI layer contains API configurations and controllers and also uploaded images were stored in wwwroot/uploads/images folder.

<details>
  <summary>ConsoleUI Layer File Structure</summary>      
  <br>
  
         WebAPI
           |   |-- Controllers
           |   |   |-- AuthController.cs
           |   |   |-- BrandsController.cs
           |   |   |-- CarImagesController.cs
           |   |   |-- CarsController.cs
           |   |   |-- ColorsController.cs
           |   |   |-- CustomersController.cs
           |   |   |-- PaymentsController.cs
           |   |   |-- RentalsController.cs
           |   |   |-- UsersController.cs
           |   |-- Program.cs
           |   |-- Properties
           |   |   |-- launchSettings.json
           |   |-- Startup.cs
           |   |-- WebAPI.csproj
           |   |-- appsettings.Development.json
           |   |-- appsettings.json
           |   |-- wwwroot
           |   |   |-- uploads
           |   |   |   |-- images
</details>

## Database Tables
You can see and examine the tables below.
And also you can add the tables which ones required for the project, via following SQL script file.
<b>SQL Script File:</b> <a href="https://github.com/talhakoylu/ReCapProject/blob/master/recap.sql">recap.sql</a>
<table>
<tbody>
    </br>
  <tr>
    <td>
        <table>
            <thead>
              <tr>
                <th class="tg-baqh" colspan="4"><span style="font-weight:bold">Brands</span></th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td class="tg-0lax">✔</td>
                <td class="tg-0pky">BrandId</td>
                <td class="tg-0pky">Int</td>
                <td class="tg-0lax">❌</td>
              </tr>
              <tr>
                <td class="tg-0lax"></td>
                <td class="tg-0pky">BrandName</td>
                <td class="tg-0pky">varchar(50)</td>
                <td class="tg-0lax">❌</td>
              </tr>
            </tbody>
         </table>
    </td>
    <td>
       <table>
        <thead>
          <tr>
            <th class="tg-baqh" colspan="4"><span style="font-weight:bold">CarImages</span></th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td class="tg-1wig">Primary Key</td>
            <td class="tg-fymr">Name</td>
            <td class="tg-fymr">Data Type</td>
            <td class="tg-1wig">Allow Nulls</td>
          </tr>
          <tr>
            <td class="tg-0lax">✔</td>
            <td class="tg-0pky">Id</td>
            <td class="tg-0pky">Int</td>
            <td class="tg-0lax">❌</td>
          </tr>
          <tr>
            <td class="tg-0lax"></td>
            <td class="tg-0pky">CarId</td>
            <td class="tg-0pky">Int</td>
            <td class="tg-0lax">❌</td>
          </tr>
          <tr>
            <td class="tg-0lax"></td>
            <td class="tg-0lax">ImagePath</td>
            <td class="tg-0lax">varchar(MAX)</td>
            <td class="tg-0lax">✅</td>
          </tr>
          <tr>
            <td class="tg-0lax"></td>
            <td class="tg-0lax">Date</td>
            <td class="tg-0lax">datetime</td>
            <td class="tg-0lax">❌</td>
          </tr>
        </tbody>
       </table>
    </td>
  </tr>
  <tr>
    <td>
        <table>
            <thead>
              <tr>
                <th class="tg-baqh" colspan="4"><span style="font-weight:bold">Cars</span></th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td class="tg-1wig">Primary Key</td>
                <td class="tg-fymr">Name</td>
                <td class="tg-fymr">Data Type</td>
                <td class="tg-1wig">Allow Nulls</td>
              </tr>
              <tr>
                <td class="tg-0lax">✔</td>
                <td class="tg-0pky">CarId</td>
                <td class="tg-0pky">int</td>
                <td class="tg-0lax">❌</td>
              </tr>
              <tr>
                <td class="tg-0lax"></td>
                <td class="tg-0pky">BrandId</td>
                <td class="tg-0pky">int</td>
                <td class="tg-0lax">❌</td>
              </tr>
              <tr>
                <td class="tg-0lax"></td>
                <td class="tg-0lax">ColorId</td>
                <td class="tg-0lax">int</td>
                <td class="tg-0lax">❌</td>
              </tr>
              <tr>
                <td class="tg-0lax"></td>
                <td class="tg-0lax">ModelYear</td>
                <td class="tg-0lax">int</td>
                <td class="tg-0lax">❌</td>
              </tr>
              <tr>
                <td class="tg-0lax"></td>
                <td class="tg-0lax">DailyPrice</td>
                <td class="tg-0lax">decimal(18,0)</td>
                <td class="tg-0lax">❌</td>
              </tr>
              <tr>
                <td class="tg-0lax"></td>
                <td class="tg-0lax">Description</td>
                <td class="tg-0lax">nvarchar(250)</td>
                <td class="tg-0lax">❌</td>
              </tr>
            </tbody>
         </table>
    </td>
    <td>
    <table>
        <thead>
          <tr>
            <th colspan="4">Colors</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Primary Key</td>
            <td>Name</td>
            <td>Data Type</td>
            <td>Allow Nulls</td>
          </tr>
          <tr>
            <td>✔</td>
            <td>ColorId</td>
            <td>int</td>
            <td>❌</td>
          </tr>
          <tr>
            <td></td>
            <td>ColorName</td>
            <td>varchar(50)</td>
            <td>❌</td>
          </tr>
        </tbody>
     </table>
    </td>
  </tr>
  <tr>
    <td>
        <table>
            <thead>
              <tr>
                <th colspan="4">Customers</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td>This table doesn't<br>contains any primay<br>key</td>
                <td>UserId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>CompanyName</td>
                <td>nvarchar(150)</td>
                <td>❌</td>
              </tr>
            </tbody>
        </table>
    </td>
    <td>
        <table>
            <thead>
              <tr>
                <th colspan="4">OperationsClaims</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td>✔</td>
                <td>Id</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>Name</td>
                <td>varchar(150)</td>
                <td>❌</td>
              </tr>
            </tbody>
         </table>
    </td>
  </tr>
  <tr>
    <td>
        <table>
            <thead>
              <tr>
                <th colspan="4">Payments</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td>✔</td>
                <td>Id</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>UserId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>CarId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>ProcessDate</td>
                <td>date</td>
                <td>✅</td>
              </tr>
              <tr>
                <td></td>
                <td>TotalAmount</td>
                <td>money</td>
                <td>✅</td>
              </tr>
            </tbody>
        </table>
    </td>
    <td>
        <table>
            <thead>
              <tr>
                <th colspan="4">Rentals</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td>✔</td>
                <td>Id</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>CarId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>CustomerId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>RentDate</td>
                <td>datetime</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>ReturnDate</td>
                <td>datetime</td>
                <td>✅</td>
              </tr>
            </tbody>
        </table>
    </td>
  </tr>
  <tr>
    <td>
        <table>
            <thead>
              <tr>
                <th colspan="4">UserOperationClaims</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td>✔</td>
                <td>Id</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>UserId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>OperationClaimId</td>
                <td>int</td>
                <td>❌</td>
              </tr>
            </tbody>
         </table>
    </td>
    <td>
        <table>
            <thead>
              <tr>
                <th colspan="4">Users</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Primary Key</td>
                <td>Name</td>
                <td>Data Type</td>
                <td>Allow Nulls</td>
              </tr>
              <tr>
                <td>✔</td>
                <td>Id</td>
                <td>int</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>FirstName</td>
                <td>varchar(50)</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>LastName</td>
                <td>varchar(50)</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>Email</td>
                <td>varchar(150)</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>PasswordHash</td>
                <td>varbinary(500)</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>PasswordSalt</td>
                <td>varbinary(500)</td>
                <td>❌</td>
              </tr>
              <tr>
                <td></td>
                <td>Status</td>
                <td>bit</td>
                <td>❌</td>
              </tr>
            </tbody>
         </table>
    </td>
  </tr>
</tbody>
</table>

## Important Notes About Project
- Do not forget to change your API Key from <a href="https://github.com/talhakoylu/ReCapProject/blob/master/ReCapProject/WebAPI/appsettings.json">appsetting.json</a> which one is in the WebAPI layer.

## Distribution
This project licenced and distributed under MIT Licence. Please read the <a href="https://github.com/talhakoylu/ReCapProject/blob/master/LICENSE">LICENCE</a> file for more information.

## Author
Ahmet Talha KÖYLÜ - <a href="https://github.com/talhakoylu/">Github</a> - <a href="https://linkedin.com/in/talhakoylu">LinkedIn</a>
