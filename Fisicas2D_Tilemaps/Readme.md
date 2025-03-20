# Físicas 2D

22/10/2024 1.a.- Ningún objeto es físico: no hay movimiento ni colisiones.
![379276399-006eb14f-ac33-4653-9ed1-c64667574c11](https://github.com/user-attachments/assets/e3777f7a-b576-4c1b-b4ca-6a66032f4195)


22/10/2024 1.b.- El objeto con físicas cae por gravedad y puede ser empujado por otros objetos con collider.
![379276432-e68d24f5-dc93-4201-9758-58e4cc15db81](https://github.com/user-attachments/assets/f80a8538-2678-4005-933c-daccd19b4075)


22/10/2024 1.c.- Ambos objetos caen por gravedad e interactúan entre ellos.
![379276446-b472e4da-b7cb-4a1d-b131-bb66010950a7](https://github.com/user-attachments/assets/6145df7d-68cf-4dc7-8f95-ba92a32d9b29)


22/10/2024 1.d.- Se observa que el objeto más pesado absorbe más inercia cuando interactúan entre si los dos objetos físicos.
![379276463-446eaa32-e54a-4709-b86f-a266279812ee](https://github.com/user-attachments/assets/76b0d96e-7bee-4eee-949e-ca3bb6d49b02)


23/10/2024 1.e.- El objeto que sólo es IsTrigger no se ve afectado por fuerzas, se queda estanco pero dispara eventos de trigger cuando otro objeto entra en su colisión.
![379276477-b9468f38-2686-4b38-9b01-70a58e7e5526](https://github.com/user-attachments/assets/eb2d8567-4e07-4138-a874-1cbc50dc232d)


23/10/2024 1.f.- Al tener físicas pero ser IsTrigger, el objeto se ve afectado por fuerzas como la gravedad pero pierde la capacidad de colisionar con otros objetos.
![379276500-c879224d-c527-4f94-9994-5ce58afb1a7e](https://github.com/user-attachments/assets/1d19019b-2404-4f6b-b1a9-c697e008c0c4)


23/10/2024 1.g.- Al ser marcado como cinemático, el objeto se comporta de manera similar a un objeto estático mientras no se manipule, ejerciendo como barrera física colisionable.
![379276512-99a0596f-4cdf-44b1-8fa5-51f521b7f1c4](https://github.com/user-attachments/assets/73783fe5-56d8-45a4-b671-56648c790ef3)


23/10/2024 2.a.- El propio suelo usado durante toda la práctica sería una barrera infranqueable para objetos físicos.

23/10/2024 2.b.- Mediante un trigger se ejerce una fuerza con AddForce a todo objeto con Rigidbody que entre en él.
![379276551-adebba0d-e48c-402f-80ef-ac1f6fd57871](https://github.com/user-attachments/assets/14e267c1-020c-415f-bd89-a4d274a48382)


23/10/2024 2.c.- Con MovePosition obligamos a que un objeto se vea arrastrado por otro desde el Rigidbody.
![379276572-1193ff40-0842-4267-88a6-e3d539a72a08](https://github.com/user-attachments/assets/912030db-f196-4cad-b3e7-3011a7a53ea9)


23/10/2024 2.d.- Visto en 1.c. y 1.d.

23/10/2024 2.e.- Al excluir capas en los overrides del Rigidbody, dejan de interactuar entre sí los objetos, ignorando colisiones y eventos.
![379276588-c4310ce1-4dec-4ae1-906c-aefbff69b206](https://github.com/user-attachments/assets/744e746b-7825-4423-ae7a-4f9f3e0b8759)


# Tilemaps

23/10/2024 - Se crean 3 tilemaps, uno de fondos, otro con collider para las plataformas, y un tercero con elementos decorativos.
Se realiza el control del personaje basado en físicas y con salto.
Se crea una plataforma móvil. Cuando el personaje colisiona con ella, se adhiere a ella transfiriendo el parent. Al salir de la colisión se desvincula el parent.
Se crean plataformas invisibles que sólo se hacen visibles al entrar en contacto con ellas.
Se añade un item coleccionable. 5 mejoran el salto, 10 ganan la partida.
![379278327-eb42da68-cc30-4d55-bcd2-f67260dea283](https://github.com/user-attachments/assets/8b5db8cb-b0e8-4022-880c-3d4f8300c0ca)
