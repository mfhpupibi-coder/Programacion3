Mi Primer Proyecto en C# - Tarea 1
Descripción
Este repositorio contiene la configuración inicial de mi entorno de desarrollo profesional para la materia de Programación 3. Se configuró el ecosistema base utilizando la CLI de .NET y control de versiones.

Herramientas y Tecnologías
Editor de Código: Visual Studio Code
Framework: .NET SDK 8.0
Control de Versiones: Git y GitHub
 EcoSystem Connect - Proyecto Final

## Arquitectura de Software: Patrón N-Capas
Este proyecto implementa una arquitectura N-Capas (N-Tier Architecture) para garantizar la separación de responsabilidades, mantenibilidad y escalabilidad del sistema.

### Estructura del Proyecto:
* **EcoSystem.API (Presentación):** Capa exterior encargada de exponer los endpoints RESTful mediante controladores C# y gestionar las peticiones HTTP/respuestas JSON.
* **EcoSystem.Business (Lógica de Negocio):** El cerebro del sistema. Orquesta los flujos de trabajo y valida las reglas de negocio de forma agnóstica a la persistencia.
* **EcoSystem.Data (Acceso a Datos):** Cimientos del sistema encargados de la persistencia física e interacción con la base de datos mediante Entity Framework Core (Code-First).

* ## Hito 2: Base de Datos Relacional en la Nube ☁️

[cite_start]Como parte de la evolución del proyecto hacia una persistencia real, se ha desplegado e integrado un servidor relacional **PostgreSQL** en la nube utilizando la plataforma **Supabase** (alojado sobre infraestructura AWS)[cite: 230, 236, 361].

### 📊 Modelo Entidad-Relación (ER)
[cite_start]El diseño cuenta con restricciones avanzadas de integridad referencial, tipos de datos óptimos para transacciones comerciales (`DECIMAL(10,2)`) y reglas de validación en el motor (`CHECK`)[cite: 307, 335, 338, 580]:

* [cite_start]**Categorias:** Clasificación jerárquica de los elementos del ecosistema[cite: 243, 244].
* [cite_start]**Usuarios:** Registro de operadores con roles diferenciados (`Administrador`, `Estudiante`) y almacenamiento seguro de contraseñas mediante hash[cite: 259, 263, 287, 488].
* [cite_start]**Productos:** El catálogo de artículos ecológicos, el cual mantiene una relación **1:N (Uno a Muchos)** con la tabla Categorías[cite: 254, 265, 266].

> **Regla de Integridad:** Se implementó `ON DELETE CASCADE` en la llave foránea de Productos. [cite_start]Si una categoría es eliminada, todos sus productos asociados se remueven de forma automática para evitar registros huérfanos[cite: 266, 326, 332, 333].

### 🛠️ Estructura del Script de Persistencia
[cite_start]El script oficial se encuentra versionado siguiendo las buenas prácticas arquitectónicas (las tablas independientes se crean primero)[cite: 269, 518]:
* [cite_start]**Ruta:** `EcoSystem.Data/Database/script.sql` [cite: 520, 524, 525, 526]
* [cite_start]**Datos de Prueba (Seed Data):** Incluye la inserción automática de 2 categorías base, 1 usuario administrador inicial y 1 producto tecnológico para pruebas de conectividad y verificación de consultas con `JOIN`[cite: 460, 462, 468, 474, 505].
