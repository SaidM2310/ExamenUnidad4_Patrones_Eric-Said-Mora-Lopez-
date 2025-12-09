## Descripción general

Este proyecto implementa un sistema **multijugador local** donde hasta **3 jugadores** pueden desplazarse por un lobby y entrar a salas para jugar Piedra, Papel o Tijera.  
El movimiento es controlado por teclado y cada sala soporta 2 jugadores.  
El sistema crea salas, administra jugadores y gestiona el flujo del juego.

Además, se expandió el proyecto para añadir:

- Partidas al mejor de 3 (2 de 3 rondas)  
- Patrones de diseño adicionales  
- Arquitectura basada en MVC  
- Estados internos de la sala  
- Fachada para simplificar la lógica del juego  
- Botones con imágenes / estilo visual mejorado  

---

## Arquitectura del Proyecto

El sistema está organizado bajo una estructura estilo **MVC adaptado a WinForms**:

- **Modelo**: Jugador, Servidor, Pool de Jugadores  
- **Vista**: Form1 (lobby), Formsala (sala de juego)  
- **Controlador**: ControladorJuego  

Se añadieron varios **patrones de diseño** para mejorar escalabilidad, claridad y extensibilidad.

---

## Patrones de Diseño Utilizados

### 1. Singleton
- **Clase:** `ServidorPartida.cs`  
- **Función:** Asegura que toda la aplicación use un solo servidor para administrar salas activas.

### 2. Object Pool
- **Clases:** `PoolJugadores.cs`, `Jugador.cs`  
- **Función:** Reutiliza un conjunto limitado de jugadores (máx. 3) sin crear ni destruir objetos repetidamente.

### 3. Fachada (Facade)
- **Clase:** `FachadaJuego.cs`  
- **Función:** Simplifica el control interno del juego:
  - reinicio de rondas  
  - conteo de victorias  
  - detección de ganador  
  - flujo de 2 de 3 rondas  
- El formulario no necesita conocer todos los detalles internos.

### 4. Estado
- **Clases:** `InterfazEstadoSala.cs`, `EstadoEsperando.cs`, `EstadoJugando.cs`, `EstadoFinalizado.cs`  
- **Función:** Permite que la sala cambie de comportamiento según su estado actual:
  - Esperando jugadores  
  - Jugando  
  - Finalizado  
- Cada estado controla lo que se puede o no hacer.

### 5. MVC (Modelo / Vista / Controlador)
- **Clases:**  
  - **Vistas:** `Form1.cs`, `Formsala.cs`  
  - **Modelos:** `Jugador`, `PoolJugadores`, `ServidorPartida`, `FachadaJuego`  
  - **Controlador:** `ControladorJuego.cs`  
- Se separó la lógica para mantener el proyecto mantenible y escalable.

---

## Cambios y Mejoras Realizadas

### 1. Reestructuración a MVC
- Se movió lógica del formulario a `ControladorJuego`.  
- Se organizaron modelos independientes para la lógica.

### 2. Implementación de la Fachada
- Se creó `FachadaJuego.cs` para controlar rondas, flujo y ganadores.  
- Se introdujo el sistema de **2 de 3 rondas**.

### 3. Sistema de estados en la sala
- Sala espera jugadores.  
- Cambia al estado "jugando" cuando hay dos.  
- Cambia a "finalizado" después de cada ronda.  
- Se reinicia automáticamente para la siguiente ronda.  
- Al terminar 2 de 3, termina la partida.

### 4. Mejora visual
- Los botones de Piedra / Papel / Tijera se reemplazaron o estilizaron con imágenes.  
- UI más clara y responsiva.

### 5. Correcciones en flujo de rondas
- Se arregló el problema donde el juego finalizaba antes de tiempo.  
- Ahora la sala reinicia correctamente para la segunda y tercera ronda.

### 6. Refactor completo de la lógica de juego
- Separación por responsabilidades.  
- Menos código en los formularios, más reutilizable y ordenado.

---

## Estructura Final de Clases

| Archivo               | Patrón      | Rol                                  |
|----------------------|------------|-------------------------------------|
| ServidorPartida.cs    | Singleton  | Administra todas las salas          |
| PoolJugadores.cs      | Object Pool| Administra jugadores disponibles/en uso |
| Jugador.cs            | Modelo     | Representa a cada jugador           |
| FachadaJuego.cs       | Facade     | Control de rondas y lógica del juego|
| ControladorJuego.cs   | MVC        | Coordina vista ↔ lógica             |
| InterfazEstadoSala.cs | Estado      | Contrato de estados                 |
| EstadoEsperando.cs    | Estado      | Sala esperando jugadores            |
| EstadoJugando.cs      | Estado      | Sala en juego                        |
| EstadoFinalizado.cs   | Estado      | Final de ronda/partida              |
| Form1.cs              | Vista      | Lobby                               |
| Formsala.cs           | Vista      | Sala del juego                       |

---

## Conclusión

Este proyecto evolucionó de un simple formulario con jugadores moviéndose, a un sistema bien estructurado con:

- patrones profesionales de diseño  
- arquitectura MVC  
- estado del juego controlado  
- rondas competitivas  
- lógica desacoplada  
- vistas limpias y fáciles de modificar  

