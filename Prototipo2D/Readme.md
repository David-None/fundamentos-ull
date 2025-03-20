# Prototipo 2D: Roll'N'Rock
El prototipo consiste en un nivel de un juego de disparos 2D combinado con un juego de ritmo.
Movemos al personaje principal con las teclas WASD y apuntamos con el ratón. Disparamos con LMB, con RMB rodamos para esquivar o movermos más rápido, y con MMB hacemos zoom out para ver todo el nivel.

# Cinemachine y Background Roll
Usamos dos cámaras Cinemachine, una tiene un target doble (el personaje y la mira) confinada en un área que se desplaza junto con el personaje principal.
La otra cámara Cinemachine se encuentra fija enfocando la totalidad del nivel, y accedemos a ella presionando la rueda del ratón.
El fondo de pantalla consiste en 3 texturas transparentes que hacen "roll" a distintas velocidades y según el movimiento de la cámara principal.
Al hacer zoom out este fondo se escala en base al "weight" de la cámara, de manera que el fondo siempre cubre toda la pantalla y da efecto de que está ciertamente alejado.
![401712245-9343b3af-a83f-4510-8af2-c60b38fcffbc](https://github.com/user-attachments/assets/a7287658-eeb3-4eef-97d3-3f750faf2894)

# Movimiento y acciones
El juego se desarrolla en perspectiva cenital, por lo que Roll puede desplazarse libremente en los ejes X e Y mediante el input de las teclas WASD.
Por otro lado, manejamos con el ratón un punto de mira con forma de Clave de Fa que orienta la cámara y determina la dirección en la que lanzaremos corcheas, nuestros proyectiles.
Aparte, Roll puede rodar a mayor velocidad de la que camina clickando el botón derecho del ratón. La propia animación de rodar, al terminar, llama a un método que devuelve a Roll a su velocidad habitual.
Por último, con el botón izquerdo del ratón se llama al método de disparo, instanciando una corchea que se desplaza en la dirección del vector que une a Roll con la mira.
El diseño de Roll y sus animaciones son completamente originales para el desarrollo de este prototipo.
![401713159-f518dec7-133f-4fcd-85a0-49004e8c0c3f](https://github.com/user-attachments/assets/fd426984-acbb-4fe9-82d1-78afac4bf7cc)

# Proyectiles y colisiones
Tanto Roll como los enemigos disparan corcheas. Éstas cuentan con un Collider2D para reaccionar de distintas maneras a los respectivos Colliders de Roll, los enemigos y las paredes.
Las corcheas vienen cargadas con una variable float indicando el daño que hacen. Cuando nuestras corcheas impactan al enemigo se resta dicho daño de su salud. Igualmente las corcheas enemigas restan salud a Roll.
Al colisionar con los muros o con su objetivo, ambos tipos de corcheas son eliminadas de la aplicación.
![401713944-5f98c40b-9053-40aa-86d5-d6e0bc9493c4](https://github.com/user-attachments/assets/46736b89-175a-4e3e-95e8-34b13c08d768)

# Tilemaps
Existen dos capas de tilemaps, una simplemente para indicar visualmente el área de desplazamiento de los personajes, y la 2a, provista de Collider2D, para los muros, confinando el movimiento de Roll dentro del nivel.

# UI, juego de ritmo y pooling
La interfaz contiene un sprite que varía en función de la salud restante de Roll.
Los propios enemigos también tienen su barra de salud que se activa en cuanto reciben su primer punto de daño y luego también cambian visualmente a medida que pierden salud.
Existe también un indicador de puntuación que varía a medida que nuestras corcheas aciertan a los enemigos.
Pero el elemento más importante de la interfaz es el indicador de ritmo:
El "Gestor de Anillos" es un GameObject sin representación visual, con un Animator incorporado que va invocando métodos de un script (Comenzar la música, terminar el nivel, e invocar anillos) en sincronización con la música.
Cada vez que se invoca un anillo, se activa una instancia de un pool de anillos, y este comienza a desplazarse por la pantalla de derecha a izquierda.
Al llegar a cierto límite por la izquierda, el anillo se desactiva para volver a formar parte de la reserva del pool.
Cuando el anillo está próximo a la diana, activa y desactiva un conjunto de bools en los scripts del player, que determinan su nivel de "puntería" (buena y perfecta).
El nivel de puntería modifica la cantidad de daño con la que están cargadas lar corcheas que Roll dispara.
![401716244-fbfc1eb7-fbeb-42c4-a156-0aaede255745](https://github.com/user-attachments/assets/9658502b-1ac3-4a0a-b639-8852de6ba9a0)

# Enemigos
Los enemigos tienen dos estados básicos: patrulla y disparo. Cambian en función de la distancia a la que estén del jugador.
En modo patrulla se dedican a recorrer puntos recogidos en un array de Transforms. Al encontrarse a cierta distancia del punto objetivo, se cambia al siguiente punto del array y éste se reinicia al alcanzar el último punto.
En modo disparo los enemigos se detienen a disparar a Roll. Usando la dirección que los une con el jugador, instancian corcheas cada cierto tiempo X indicado por un cooldown.

# Menus
Existen dos escenas de menú, comparten el mismo script que añade funcionalidad a los botones, para comenzar la partida, abandonar el juego o volver al menú principal.
El logo del menú principal también es creación original para el prototipo.
![401716871-57e98a2a-50dc-4a97-9172-29e4e336a58d](https://github.com/user-attachments/assets/9b5786e0-bd8f-48c2-940d-6181950251fd)
