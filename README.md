# 🎮 2D Pixel Game – Unity

Juego **2D Pixel Art de acción y disparos** desarrollado en **Unity con C#**, ambientado en un **mundo distópico post-apocalíptico** donde la tecnología ha reemplazado casi toda forma de vida.

Este proyecto forma parte de mi **portafolio como desarrollador de videojuegos y programador junior**.

---

## 🌌 Historia y temática

En un **mundo post-apocalíptico dominado por máquinas**, controlas a un **robot explorador armado con un blaster** cuya misión es sobrevivir y enfrentar a una **bruja intergaláctica robótica**, una entidad que controla fuerzas desconocidas y ha corrompido el planeta.

El juego se desarrolla en un entorno que **cambia visualmente entre una vista completamente 2D y una simulación de profundidad 3D en estilo 2.5D**, creando una experiencia visual dinámica.

El jugador deberá:

- Explorar zonas hostiles
- Sobrevivir a enemigos mecánicos
- Usar su blaster para defenderse
- Avanzar entre distintos niveles
- Descubrir el mundo destruido

---

## ✨ Características

- Movimiento fluido del jugador  
- Sistema de disparos con blaster  
- Enemigos con comportamiento básico  
- Sistema de vida  
- Animaciones pixel art  
- Sonido ambiental  
- Efectos visuales  
- Menú principal  
- Múltiples niveles  
- Fondo con Parallax  
- Estilo visual 2D con profundidad simulada (2.5D)

---

## 🛠 Tecnologías utilizadas

- Unity (URP)
- C#
- Unity Input System
- Animator Controller
- Prefabs
- Audio System

---

## ⚙️ Requisitos

Para ejecutar el proyecto necesitas:

- Unity Hub
- Unity **2022 o superior**
- Windows 10 / 11

---

## 🚀 Cómo ejecutar el juego

### 1. Clonar el repositorio

```
git clone https://github.com/JoakoMancilla/2D-Pixel-Game-Unity.git
```

### 2. Abrir en Unity Hub

1. Abrir Unity Hub  
2. Click en **Add Project**  
3. Seleccionar la carpeta descargada  
4. Abrir el proyecto

### 3. Ejecutar el juego

Abrir la escena:

```
Assets/Scenes/Menu.unity
```

Luego presionar **Play ▶ en Unity**.

---

## 🎮 Controles

| Tecla | Acción |
|------|--------|
| W A S D | Movimiento |
| Mouse | Apuntar |
| Click izquierdo | Disparar |

---

## 📁 Estructura del proyecto

```
Assets/
 ├── Animations
 ├── External Assets
 ├── Prefabs
 ├── Scenes
 ├── Scripts
 │    ├── Player
 │    ├── Enemy
 │    └── Systems
 └── Sounds
```

---

## 🧠 Scripts principales

### Player

**PlayerMovement.cs**  
Controla el movimiento del jugador

**PlayerShooting.cs**  
Sistema de disparos con blaster

**PlayerHealth.cs**  
Sistema de vida del jugador

---

### Enemy

**EnemyMovement.cs**  
Movimiento enemigo

**EnemyAttack.cs**  
Sistema de ataque enemigo

**EnemyHealth.cs**  
Sistema de vida enemigo

---

### Sistemas

**GameManager.cs**  
Control general del juego

**MenuManagement.cs**  
Sistema de menú

**Parallax.cs**  
Sistema de profundidad visual

---

## 🎯 Objetivo del proyecto

Este proyecto fue desarrollado para practicar y demostrar conocimientos en:

- Programación orientada a objetos
- Desarrollo en Unity
- Arquitectura básica de videojuegos
- Organización profesional de proyectos
- Diseño modular con prefabs
- Sistemas de gameplay en tiempo real

---

## 🔮 Mejoras futuras

- Más niveles
- Mejor IA enemiga
- Nuevos enemigos
- Nuevas armas
- Guardado de progreso
- Mejor interfaz
- Mejor iluminación

---

## 👨‍💻 Autor

**Joaquín Mancilla**

Estudiante de Ingeniería Informática  
Analista Programador (en formación)

GitHub:  
https://github.com/JoakoMancilla

---

## ⭐ Notas

Este proyecto **no incluye build ejecutable**.  
Debe ejecutarse desde Unity.
