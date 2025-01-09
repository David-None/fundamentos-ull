# Prototipo 2D: Roll'N'Rock
El prototipo consiste en un nivel de un juego de disparos 2D combinado con un juego de ritmo.
Movemos al personaje principal con las teclas WASD y apuntamos con el ratón. Disparamos con LMB, con RMB rodamos para esquivar o movermos más rápido, y con MMB hacemos zoom out para ver todo el nivel.

# Cinemachine y Background Roll
Usamos dos cámaras Cinemachine, una tiene un target doble (el personaje y la mira) confinada en un área que se desplaza junto con el personaje principal.
La otra cámara Cinemachine se encuentra fija enfocando la totalidad del nivel, y accedemos a ella presionando la rueda del ratón.
El fondo de pantalla consiste en 3 texturas transparentes que hacen "roll" a distintas velocidades y según el movimiento de la cámara principal.
Al hacer zoom out este fondo se escala en base al "weight" de la cámara, de manera que el fondo siempre cubre toda la pantalla y da efecto de que está ciertamente alejado.

# Movimiento y acciones
El juego se desarrolla en perspectiva cenital, por lo que Roll puede desplazarse libremente en los ejes X e Y mediante el input de las teclas WASD.
Por otro lado, manejamos con el ratón un punto de mira con forma de Clave de Fa que orienta la cámara y determina la dirección en la que lanzaremos corcheas, nuestros proyectiles.
Aparte, Roll puede rodar a mayor velocidad de la que camina clickando el botón derecho del ratón. La propia animación de rodar, al terminar, llama a un método que devuelve a Roll a su velocidad habitual.
Por último, con el botón izquerdo del ratón se llama al método de disparo, instanciando una corchea que se desplaza en la dirección del vector que une a Roll con la mira.
El diseño de Roll y sus animaciones son completamente originales para el desarrollo de este prototipo.

# Proyectiles y colisiones
Tanto Roll como los enemigos disparan corcheas. Éstas cuentan con un Collider2D para reaccionar de distintas maneras a los respectivos Colliders de Roll, los enemigos y las paredes.
Las corcheas vienen cargadas con una variable float indicando el daño que hacen. Cuando nuestras corcheas impactan al enemigo se resta dicho daño de su salud. Igualmente las corcheas enemigas restan salud a Roll.
Al colisionar con los muros o con su objetivo, ambos tipos de corcheas son eliminadas de la aplicación.

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

# Enemigos
Los enemigos tienen dos estados básicos: patrulla y disparo. Cambian en función de la distancia a la que estén del jugador.
En modo patrulla se dedican a recorrer puntos recogidos en un array de Transforms. Al encontrarse a cierta distancia del punto objetivo, se cambia al siguiente punto del array y éste se reinicia al alcanzar el último punto.
En modo disparo los enemigos se detienen a disparar a Roll. Usando la dirección que los une con el jugador, instancian corcheas cada cierto tiempo X indicado por un cooldown.
