# Técnicas 2D

01/11/24 Scroll del background con cámara y personajes fijos, desplazando el fondo hasta que sale fuera de cuadro para teletransportarlo al extremo opuesto
![Tecnicas1](https://github.com/user-attachments/assets/aafbcf15-1395-4872-9394-83da7cc62fd5)


01/11/24 Scroll con movimiento de cámara y personaje. El background está fijo hasta que la cámara lo deja atrás, desplazándose entonces al otro lado de la cámara
![Tecnicas2](https://github.com/user-attachments/assets/f2c7c2a9-bdd9-4e75-b22e-2ce6fee4ed75)


01/11/24 Scroll con offset de la textura. La cámara y el personaje están fijos, el input del jugador desplaza el offset de la textura del fondo, dando efecto de movimiento.
![Tecnicas3](https://github.com/user-attachments/assets/c3021985-6812-4e56-8330-ab2f71612110)


02/11/24 Efecto parallax moviendo las posiciones de los fondos.
![Tecnicas4](https://github.com/user-attachments/assets/3872d9a1-9fe3-4eff-a8c7-de690472236a)


06/11/24 Efecto parallax actualizando los offset de las texturas.
![Tecnicas5](https://github.com/user-attachments/assets/b335d2f5-6714-4fa1-93bc-2898670c032e)


05/11/24 Se añaden elementos recogibles a la escena, al recogerlos se desactivan o destruyen y aparecen nuevos, bien activando objetos desactivados previamente, o generando un pool de elementos recogibles nuevos.
![Tecnicas6](https://github.com/user-attachments/assets/df6f7216-0b6f-4eac-98b2-ddd2306b88c7)


06/11/24 En la entrega anterior, en el script que da movimiento al jugador, hay una variable Vector3 que podría haber sido cacheada fuera del update para no estarla creando cada vez. Y en general usar CompareTag() en lugar de operadores de comparación.
