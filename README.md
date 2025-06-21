# JugadorAPI

API RESTful simple desarrollada con ASP.NET Core para la gestión de jugadores y sus habilidades.  
Este proyecto fue creado con fines educativos como parte de mi práctica con el stack .NET, aplicando principios de desarrollo backend y organización por capas.

---

## 🛠 Tecnologías utilizadas

- .NET 8
- ASP.NET Core
- C#
- Swagger / OpenAPI

---

## 📌 Funcionalidades

- Listar todos los jugadores
- Consultar un jugador por ID
- Agregar, modificar o eliminar jugadores
- Asignar habilidades a jugadores (con nivel de potencia)
- Validaciones con anotaciones `[Required]`, `[MaxLength]`
- Organización por capas (Controllers, Services, Models)

---

## 📂 Estructura del proyecto

- `/Controllers` – Lógica de rutas y endpoints (`Jugador`, `Habilidad`)
- `/Models` – Clases de datos (`Jugador`, `Habilidad`, `JugadorInsert`)
- `/Services` – Simulación de almacenamiento con `JugadorDataStore`
- `/Helpers` – Mensajes de error
- `Program.cs` – Configuración de middlewares y pipeline HTTP

---

## 💡 Notas

> Este proyecto utiliza almacenamiento en memoria y no requiere base de datos.  
> Ideal para practicar arquitectura limpia, controladores REST y estructura de APIs en .NET.

---

## 👨‍💻 Autor

**Nahuel Viera**  
[GitHub](https://github.com/Nahuevp)
