# Documentación de la evidencia evaluativa de la unidad

## Enlace al video en YouTube
[Video Estanque Digital](https://youtu.be/n1MZVtjKk5o)

## Explicación de la solución

Narrativa de la explicación:

1. Describir el problema. Por ejemplo en la unidad 1: generar un mapa de elevación manteniendo las variaciones de las alturas con cambios suaves.
2. Para solucionar este problema seleccioné el concepto matemático llamado ruido perlin.
3. Porque ....
4. Y aquí se ve la parte del código donde se aplica:

```csharp
class myCodeClass{
  public myCodeClass(){

  }

}

```


Para la solución de esta evalución, me vi los videos del 10 al 16 del curso the nature of code 2. Tambien le pregunte a chat GPT como podia mover un objeto a partir de la aceleración y que me mostrara ejemplos.
Empecé por crear un ambiente, o el estanque digital a partir de cubos con y sin texturas, para delimitar el espacio donde se moverian las criaturas.

<img src="https://github.com/jfUPB/evaluaciones-2023-20-IsabellaPalacioPerez/blob/main/02vectores/Estanque%20digital.png" alt="Estanque Digital" width="600" height="300">

Luego agregué la primera criatura, que simula ser un pez nadando. Le puse un materíal para que tuviera un color amarillo y un tamaño de 2x2x2. Luego le implementé un codigo que crea un rigidbody para que el objeto se pueda mover en el espacio. Tambien implenta un método, "CambiarDireccion", que genera una dirección y una fuerza aleatoria para aplicar al objeto, este es el que hace que la criatura se mueva. Dentro de este tiene una variable aleatoria de velocidad que está ajusta a los valores necesarios para que el pez se mueva de un manera moderada. Tambien está el metodo "OnCollisionEnter", que hace que cuando la criatura se choque contra la pared cambie de dirección. Y en el metodo "Start" inplemente un Invoke para que cada cierto tiempo se llamara la función de "CambiarDireccion".

<img src="https://github.com/jfUPB/evaluaciones-2023-20-IsabellaPalacioPerez/blob/main/02vectores/Criatura1.png" alt="Criatura 1" width="150" height="100">

Luego agregué la criatura 2, que simula ser una mosca, a esta le puse un color negro y un tamaño de 1x1x1. El codigo es el mismo de la Criatura 1, solo le modifique los valores en el Inkove y en el speed.

<img src="https://github.com/jfUPB/evaluaciones-2023-20-IsabellaPalacioPerez/blob/main/02vectores/Criatura2.png" alt="Criatura 2" width="150" height="112">

Por ultimo, la criatura 3, simula ser un tiburon asechando y cazando. Le puse un color rojo y un tamaño de 4x4x4. Este tiene un metodo llamado "FixedUpdate", en el que se hace la caminata aleatoria, hace que la criatura se mueva por el espacio a una velocidad aleatoria definada por un rango. Luego está la función "Levy", aquí se implementa el vuelo de Levy, lo que hace es que la criatura cambie de dirección y se mueva a con una aceleración mayor. Este metodo es llamado en el "Start" cada cierto tiempo por un Invoke.

<img src="https://github.com/jfUPB/evaluaciones-2023-20-IsabellaPalacioPerez/blob/main/02vectores/Criatura3.png" alt="Criatura 3" width="150" height="112">
