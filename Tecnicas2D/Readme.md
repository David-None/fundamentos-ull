# Técnicas 2D

01/11/24 Scroll del background con cámara y personajes fijos, desplazando el fondo hasta que sale fuera de cuadro para teletransportarlo al extremo opuesto
![383578913-aafbcf15-1395-4872-9394-83da7cc62fd5](https://github.com/user-attachments/assets/956afa9a-9c54-4397-850f-b2dcaa32606b)


01/11/24 Scroll con movimiento de cámara y personaje. El background está fijo hasta que la cámara lo deja atrás, desplazándose entonces al otro lado de la cámara
![383578944-f2c7c2a9-bdd9-4e75-b22e-2ce6fee4ed75](https://github.com/user-attachments/assets/bfce701f-db92-47e1-b38f-598689897c07)


01/11/24 Scroll con offset de la textura. La cámara y el personaje están fijos, el input del jugador desplaza el offset de la textura del fondo, dando efecto de movimiento.
![383579151-c3021985-6812-4e56-8330-ab2f71612110](https://github.com/user-attachments/assets/eb62c18d-6c05-47a6-98fc-707ddec23346)


02/11/24 Efecto parallax moviendo las posiciones de los fondos.
![383579193-3872d9a1-9fe3-4eff-a8c7-de690472236a](https://github.com/user-attachments/assets/df8f6c86-1547-4eda-948f-0ace47e9ddc3)


06/11/24 Efecto parallax actualizando los offset de las texturas.
![383579228-b335d2f5-6714-4fa1-93bc-2898670c032e](https://github.com/user-attachments/assets/0905728f-f07b-4e49-942f-6e0eb9afce5f)


05/11/24 Se añaden elementos recogibles a la escena, al recogerlos se desactivan o destruyen y aparecen nuevos, bien activando objetos desactivados previamente, o generando un pool de elementos recogibles nuevos.
![383579823-df6f7216-0b6f-4eac-98b2-ddd2306b88c7](https://github.com/user-attachments/assets/7c80c268-3d70-48b3-849f-8134131f05fb)


06/11/24 En la entrega anterior, en el script que da movimiento al jugador, hay una variable Vector3 que podría haber sido cacheada fuera del update para no estarla creando cada vez. Y en general usar CompareTag() en lugar de operadores de comparación.
