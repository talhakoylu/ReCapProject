[![GitHub license](https://img.shields.io/github/license/talhakoylu/ReCapProject?style=for-the-badge)](https://github.com/talhakoylu/ReCapProject/blob/master/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/talhakoylu/ReCapProject?style=for-the-badge)](https://github.com/talhakoylu/ReCapProject/stargazers)
<a href="https://www.linkedin.com/in/talhakoylu/">
    <img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white" />
</a>
<a href="https://www.twitter.com/talhakoylu/">
    <img src="https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white" />
</a>

# ReCap Project
A car rental project developed with C# and .Net Core Framework. In development phase, N-Layered Architecture model was followed.
You can perform basic CRUD operations with this program. Also, this program has JWT Bearer system. 
CRUD operaitons will work if the user has right claims. For caching, all of the listing and query processes (except add, update, delete) are 
saved on local storage for an hour.

## Used Technologies and Their Versions
[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net-web-api](https://img.shields.io/badge/ASP.NET%20Web%20API-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework-Core](https://img.shields.io/badge/Entity%20Framework%20Core%20v3.1.1-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac%20v6.1-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://autofac.org/)
[![Fluent-Validation](https://img.shields.io/badge/Fluent%20Validation%20v9.5.1-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://fluentvalidation.net/)

## Database Tables
#### Brands
<table>
<thead>
  <tr>
    <th class="tg-baqh" colspan="4"><span style="font-weight:bold">Brands</span></th>
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

#### Car Images
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

#### Cars
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
