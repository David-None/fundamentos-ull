# Técnicas 2D

01/11/24 Scroll del background con cámara y personajes fijos, desplazando el fondo hasta que sale fuera de cuadro para teletransportarlo al extremo opuesto


01/11/24 Scroll con movimiento de cámara y personaje. El background está fijo hasta que la cámara lo deja atrás, desplazándose entonces al otro lado de la cámara


01/11/24 Scroll con offset de la textura. La cámara y el personaje están fijos, el input del jugador desplaza el offset de la textura del fondo, dando efecto de movimiento.


02/11/24 Efecto parallax moviendo las posiciones de los fondos.


06/11/24 Efecto parallax actualizando los offset de las texturas.


05/11/24 Se añaden elementos recogibles a la escena, al recogerlos se desactivan o destruyen y aparecen nuevos, bien activando objetos desactivados previamente, o generando un pool de elementos recogibles nuevos.


06/11/24 En la entrega anterior, en el script que da movimiento al jugador, hay una variable Vector3 que podría haber sido cacheada fuera del update para no estarla creando cada vez. Y en general usar CompareTag() en lugar de operadores de comparación.