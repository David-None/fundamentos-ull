# Físicas 2D

22/10/2024 1.a.- Ningún objeto es físico: no hay movimiento ni colisiones.
![Fisicas_Paso1a](https://github.com/user-attachments/assets/006eb14f-ac33-4653-9ed1-c64667574c11)


22/10/2024 1.b.- El objeto con físicas cae por gravedad y puede ser empujado por otros objetos con collider.
![Fisicas_Paso1b](https://github.com/user-attachments/assets/e68d24f5-dc93-4201-9758-58e4cc15db81)


22/10/2024 1.c.- Ambos objetos caen por gravedad e interactúan entre ellos.
![Fisicas_Paso1c](https://github.com/user-attachments/assets/b472e4da-b7cb-4a1d-b131-bb66010950a7)


22/10/2024 1.d.- Se observa que el objeto más pesado absorbe más inercia cuando interactúan entre si los dos objetos físicos.
![Fisicas_Paso1d](https://github.com/user-attachments/assets/446eaa32-e54a-4709-b86f-a266279812ee)


23/10/2024 1.e.- El objeto que sólo es IsTrigger no se ve afectado por fuerzas, se queda estanco pero dispara eventos de trigger cuando otro objeto entra en su colisión.
![Fisicas_Paso1e](https://github.com/user-attachments/assets/b9468f38-2686-4b38-9b01-70a58e7e5526)


23/10/2024 1.f.- Al tener físicas pero ser IsTrigger, el objeto se ve afectado por fuerzas como la gravedad pero pierde la capacidad de colisionar con otros objetos.
![Fisicas_Paso1f](https://github.com/user-attachments/assets/c879224d-c527-4f94-9994-5ce58afb1a7e)


23/10/2024 1.g.- Al ser marcado como cinemático, el objeto se comporta de manera similar a un objeto estático mientras no se manipule, ejerciendo como barrera física colisionable.
![Fisicas_Paso1g](https://github.com/user-attachments/assets/99a0596f-4cdf-44b1-8fa5-51f521b7f1c4)


23/10/2024 2.a.- El propio suelo usado durante toda la práctica sería una barrera infranqueable para objetos físicos.

23/10/2024 2.b.- Mediante un trigger se ejerce una fuerza con AddForce a todo objeto con Rigidbody que entre en él.
![Fisicas_Paso2b](https://github.com/user-attachments/assets/adebba0d-e48c-402f-80ef-ac1f6fd57871)


23/10/2024 2.c.- Con MovePosition obligamos a que un objeto se vea arrastrado por otro desde el Rigidbody.
![Fisicas_Paso2c](https://github.com/user-attachments/assets/1193ff40-0842-4267-88a6-e3d539a72a08)


23/10/2024 2.d.- Visto en 1.c. y 1.d.

23/10/2024 2.e.- Al excluir capas en los overrides del Rigidbody, dejan de interactuar entre sí los objetos, ignorando colisiones y eventos.
![Fisicas_Paso2e](https://github.com/user-attachments/assets/c4310ce1-4dec-4ae1-906c-aefbff69b206)


# Tilemaps

23/10/2024 - Se crean 3 tilemaps, uno de fondos, otro con collider para las plataformas, y un tercero con elementos decorativos.
Se realiza el control del personaje basado en físicas y con salto.
Se crea una plataforma móvil. Cuando el personaje colisiona con ella, se adhiere a ella transfiriendo el parent. Al salir de la colisión se desvincula el parent.
Se crean plataformas invisibles que sólo se hacen visibles al entrar en contacto con ellas.
Se añade un item coleccionable. 5 mejoran el salto, 10 ganan la partida.
![Tilemaps](https://github.com/user-attachments/assets/eb42da68-cc30-4d55-bcd2-f67260dea283)
