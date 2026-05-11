# MisGastos

Sistema de gestión de gastos e ingresos personales desarrollado con ASP.NET Core MVC y SQL Server.

## Funcionalidades

- Dashboard con resumen de ingresos, gastos y balance
- Gráfica de gastos por categoría
- Agregar, editar y eliminar movimientos
- Categorías con íconos y colores personalizados
- Diseño responsive para móvil y escritorio

## Tecnologías utilizadas

- **ASP.NET Core MVC** — Framework web de Microsoft
- **C#** — Lenguaje de programación
- **Entity Framework Core** — ORM para acceso a base de datos
- **SQL Server** — Base de datos relacional
- **Bootstrap 5** — Diseño responsive
- **Chart.js** — Gráficas interactivas

## Cómo correr el proyecto

1. Clonar el repositorio:
```bash
git clone https://github.com/Ariadna26y/SistemaGastos.git
```

2. Abrir `SistemaGastos.sln` en Visual Studio 2022

3. Crear la base de datos en SQL Server:
```sql
CREATE DATABASE SistemaGastosDB;
```

4. Ejecutar el script de tablas que está en `/Database/setup.sql`

5. Actualizar la cadena de conexión en `appsettings.json` con tu servidor

6. Presionar **F5** para correr la app

## Screenshots

### Dashboard
![Dashboard](screenshots/dashboard.png)

### Mis Gastos
![Mis Gastos](screenshots/gastos.png)

## Desarrollado por

**Ariadna Alcocer** — [GitHub](https://github.com/Ariadna26y)
