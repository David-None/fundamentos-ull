# Físicas 2D

22/10/2024 1.a.- Ningún objeto es físico: no hay movimiento ni colisiones.


22/10/2024 1.b.- El objeto con físicas cae por gravedad y puede ser empujado por otros objetos con collider.


22/10/2024 1.c.- Ambos objetos caen por gravedad e interactúan entre ellos.


22/10/2024 1.d.- Se observa que el objeto más pesado absorbe más inercia cuando interactúan entre si los dos objetos físicos.


23/10/2024 1.e.- El objeto que sólo es IsTrigger no se ve afectado por fuerzas, se queda estanco pero dispara eventos de trigger cuando otro objeto entra en su colisión.


23/10/2024 1.f.- Al tener físicas pero ser IsTrigger, el objeto se ve afectado por fuerzas como la gravedad pero pierde la capacidad de colisionar con otros objetos.


23/10/2024 1.g.- Al ser marcado como cinemático, el objeto se comporta de manera similar a un objeto estático mientras no se manipule, ejerciendo como barrera física colisionable.


23/10/2024 2.a.- El propio suelo usado durante toda la práctica sería una barrera infranqueable para objetos físicos.


23/10/2024 2.b.- Mediante un trigger se ejerce una fuerza con AddForce a todo objeto con Rigidbody que entre en él.


23/10/2024 2.c.- Con MovePosition obligamos a que un objeto se vea arrastrado por otro desde el Rigidbody.


23/10/2024 2.d.- Visto en 1.c. y 1.d.


23/10/2024 2.e.- Al excluir capas en los overrides del Rigidbody, dejan de interactuar entre sí los objetos, ignorando colisiones y eventos.


# Tilemaps

23/10/2024 - Se crean 3 tilemaps, uno de fondos, otro con collider para las plataformas, y un tercero con elementos decorativos.
Se realiza el control del personaje basado en físicas y con salto.
Se crea una plataforma móvil. Cuando el personaje colisiona con ella, se adhiere a ella transfiriendo el parent. Al salir de la colisión se desvincula el parent.
Se crean plataformas invisibles que sólo se hacen visibles al entrar en contacto con ellas.
Se añade un item coleccionable. 5 mejoran el salto, 10 ganan la partida.