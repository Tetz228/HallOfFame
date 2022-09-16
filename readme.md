Hall Of Fame (Компетенции сотрудников)
========================
Реализация back-end-части одностраничного web-приложения для просмотра и редактирования навыков персонала.

Требования:
------------------------
* [MSSQL](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads)

Важно:
-----------------------
Добавьте в файл **appsettings.json** конфигурацию подключения к MSSQL в формате:
> Server=myServerName,myPortNumber;Database=myDataBase;User=myUsername;Password=myPassword;

Например:
> "ConnectionStrings": {  
>  "DefaultConnection": "Server=myServerName,myPortNumber;Database=myDataBase;User=myUsername;Password=myPassword;"  
>}

Миграции:
-----------------------
Для приведения структуры БД к кодовой базе нужно применить миграцию:
>dotnet ef database update