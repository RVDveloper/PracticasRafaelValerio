#Proyecto Game C# Storm Suvirve
##Rafael V.C. 2 DAW
## Descripción General

Este proyecto es un juego de supervivencia basado en turnos ambientado en la catastrofe de La Dana en Valencia Spain donde el jugador enfrenta amenazas como inundaciones, huracanes y saqueadores. El objetivo es avanzar niveles, derrotar enemigos y sobrevivir a eventos catastróficos. 
El juego está diseñado en C sharp con mecánicas de combate, habilidades especiales y eventos dinámicos.

---
## Estructura del Proyecto

### Clases Principales

1. **Juego**: Maneja la lógica principal del juego.  
   Métodos clave:
   - **`Iniciar()`**: Arranca el juego, administra turnos y niveles.
   - **`GenerarEnemigo(int nivel)`**: Crea enemigos dinámicamente según el nivel actual.
   - **`GenerarAyuda()`**: Proporciona bonificaciones al jugador en niveles específicos.
   - **`MostrarResumen()`**: Muestra el progreso del jugador al final del juego.
   - **`OrdenarHighScores()`**: Ordena y administra las puntuaciones más altas.

2. **Personaje**: Representa al jugador con propiedades como `Nombre`, `Vida`, `Nivel` y `Skill`.  
   Métodos clave:
   - **`UsarHabilidad(Enemigo enemigo, Random rnd)`**: Ejecuta un ataque especial dependiendo de la habilidad del personaje.
   - **`Special(Enemigo enemigo, Random rnd)`**: Habilidad única que varía según la subclase.
   - **`RecibirAtaque(int ataque)`**: Reduce puntos de vida del personaje basado en el daño recibido.
   - **`TirarDados(Random rnd)`**: Realiza una tirada de dados para determinar los resultados de ciertas acciones.
   - **`AumentarPotenciaHabilidad(int incremento)`**: Mejora los puntos de habilidad del personaje.

   Subclases de Personaje y habilidades únicas:
   - **CiudadanoValenciano**: Fuerte en rescates y habilidades defensivas.
   - **ReporteroHonesto**: Realiza ataques basados en la verdad.
   - **MedicoDeEmergencias**: Especializado en curación y soporte.
   - **VoluntarioComunidad**: Potencia habilidades defensivas y curativas.
   - **VoluntarioDePatrullaCiudadana**: Enfocado en ofensiva directa.

3. **Enemigo**: Representa amenazas como huracanes o saqueadores.  
   Métodos clave:
   - **`UsarHabilidad(Personaje jugador, Random rnd)`**: Realiza un ataque especial dinámico contra el jugador.
   - **`RecibirAtaque(int ataque)`**: Reduce puntos de vida del enemigo basado en el daño recibido.
   - **`TirarDados(Random rnd)`**: Realiza una tirada de dados para determinar los resultados de ciertas acciones.

   Subclases de Enemigo y habilidades únicas:
   - **DANA**: Representa una inundación masiva con ataques devastadores.
   - **Huracan**: Daño ambiental con vientos huracanados.
   - **Mazoff**: Jefe final que interrumpe la estrategia del jugador.
   - **PerroSanchez**: Jefe final con habilidades de ineficiencia que afectan al jugador.
   - **ReporteroMentiroso**: Engaña al jugador con habilidades disruptivas.
   - **Saqueador**: Roba recursos durante el combate.
   - **Tormenta**: Reduce la precisión del jugador con ataques de rayos.

---

## Mecánicas del Juego

### Turnos y Niveles
- **`Iniciar()`** administra turnos y niveles.
- Cada turno, el jugador puede:
  - Usar habilidades (**`UsarHabilidad`**, **`Special`**).
  - Defenderse (**`Defender`**).
  - Intentar huir.

### Habilidades Especiales
- **Personaje**:
  - Cada subclase tiene un **`Special`** único que puede cambiar el curso del combate.
  - **`TirarDados`** determina la efectividad de los ataques y defensas.
- **Enemigo**:
  - Los enemigos tienen habilidades únicas en **`UsarHabilidad`**, basadas en tiradas de dados y condiciones específicas.

### Eventos Dinámicos
- **`GenerarAyuda()`** proporciona bonificaciones en momentos clave.
- Enemigos generados por **`GenerarEnemigo(int nivel)`** aumentan su dificultad progresivamente.

### Puntuaciones
- **`MostrarResumen()`** guarda los logros del jugador al final del juego.
- Las puntuaciones más altas se administran mediante **`OrdenarHighScores()`**.

---

## Instrucciones de Uso

1. Ejecuta el programa y selecciona una opción del menú principal:
   - Iniciar el juego (**`Iniciar()`**).
   - Ver puntuaciones más altas (**`MostrarHighScores()`**).
   - Salir.

2. Selecciona un personaje y enfréntate a los niveles del juego.

3. Usa habilidades y estrategias para sobrevivir a las amenazas enemigas.

4. Completa todos los niveles para ganar y registrar tu puntuación.

---
**¡Disfruta del desafío y demuestra tus habilidades de supervivencia en mi Juego Storm suvirve!**
