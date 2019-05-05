# Proyecto de Sistemas Operativos

## Ejecutar como aplicación web

Instalar PostgreSQL 10, NET Core SDK 2.2 y NodeJS 10.x

Dirigirse a la carpeta ProyectoSO.EntityFrameworkCore para ejecutar la migración de base de datos

```
    cd ./aspnet-core/ProyectoSO.EntityFrameworkCore
    dotnet ef database update
```

Levantar la API del backend

```
    cd ./aspnet-core/ProyectoSO.Web.Host
    dotnet run
```

Levantar front-end
 
```
    cd ./reactjs
    npm install
    npm start
```

Iniciar sesión con usuario "admin" y contraseña "123qwe"