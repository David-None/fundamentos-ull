# Sonido en Unity

6/11/24 AudioSource agregado a la esfera "OnAwakeLoop" con el clip de audio "BGM_02" conlas opciones 'Play On Awake' y 'Loop' activadas, de manera que la música se repita en bucle y se inicie junto con la escena.

6/11/24 Se agrega componente AudioSource a la esfera "Doppler" con el sonido "Dragon Spit Fire 1".
Al pulsar la tecla 'm' del teclado, se reproduce el audio a la vez que se desplaza la esfera delante de la cámara, provocando un efecto Doppler simulado.
·Incrementar al valor de 'Spread' provoca que el efecto de audio 3D se propague más o menos "apuntado" en un ángulo en el espacio.
·'Min Distance' y 'Max Distance' determinan el rango de atenuacion del sonido. Dentro de un radio 'Min Distance' el sonido se reproduce a máximo volumen; fuera de un radio 'Max Distance' el sonido se reproduce al mínimo volumen.
·Al cambiar a 'Linear Rollof' observamos que el sonido tarda más en atenuarse al alejarse la fuente del mismo.

10/11/24 Se crea un nuevo Mixer "SampleMixer", con dos grupos, uno para la musica ambiente, que se atenúa 20 dB por debajo para dejarla de fondo; y otro para el sonido que viaja con la esfera "Doppler".
A éste último se le agrega un efecto 'Echo' que se exagera elevando el Delay hasta 300 ms (menor que por defecto -> el sonido tarda menos tiempo en repetirse) y el 'Decay' hasta el 50% (el sonido se repite más veces).
También se baja el nivel de 'Drymix' para que el eco tenga más preponderancia que el sonido original.

10/11/24 Se añade otro AudioSource a la 3ª esfera, "Laser". Al presionar la tecla 'p', la esfera se mueve y reproduce su sonido en bucle.
La tecla 't'('s' está cogida para el movimiento del jugador) para el movimiento de la esferea y la reproduccion del sonido

10/11/24 Se equipa al cubo que recibe movimiento del jugador con otro AudioSource que se activa al entrar en colision con las esferas, con el volumen del sonido regulado según la fuerza del impacto generada en la colisión.

10/11/24 Se crea un hijo del cubo-player con componente AudioSource para reproducir sonido de pasos que se activa cuando el jugador se mueve y se detiene cuando cesa el movimiento.

12/11/24 Se actualiza la práctica de Tilemaps y Físicas 2D añadiendo sonidos para los saltos y aterrizajes, al recolectar objetos. Se implementa una nueva mecánica de recibir daño (con sonido incorporado) y de curarte al recolectar postres.
Nueva pantalla de Game Over al perser toda la salud. Tanto esta pantalla como la de superar el juego reproducen un sonido al activarse. Se agrega música de ambiente, y dos zonas de sonido ambiental dentro del mismo nivel.