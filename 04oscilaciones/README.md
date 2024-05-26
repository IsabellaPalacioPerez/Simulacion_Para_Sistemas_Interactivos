# Documentación de la evidencia evaluativa de la unidad

## Enlace al video en YouTube
[Video Oscilaciones Estanque Digital](https://youtu.be/PrGbt0UQJDI)


## Explicación de la solución

El problema que debo resolver es crear una simulación interactiva de un ecosistema virtual donde diferentes especies interactúan y se comportan utilizando conceptos de oscilaciones, movimiento armónico simple, péndulos y fuerzas de resortes. Para eso debo explorar cómo estas interacciones afectan el comportamiento y la dinámica del ecosistema, lo que implica un enfoque en la narrativa y la experiencia del usuario.

Para lograrlo empecé el proyecto de cero. Incie implementando un Skybox para que todo se viera debajo del mar. Luego agregue peces, donde su comportamiento sería ir hacia las plantas y moverse al redebor de ellas, simulando que las comen. Aquí estaria el movimiento armónico simple.
Este sería el código de su movimiento:
```C#
    private void SeleccionComida()
    {
        int valor = Random.Range(1, 4);
        if (valor == 1) comida = "alga";
        if (valor == 2) comida = "alga1";
        if (valor == 3) comida = "alga2";
        if (valor == 3) comida = "alga3";
    }
    private void movimientoAgular()
    {
        // Buscar objetos con el tag "pezbebe"
        GameObject[] comidas = GameObject.FindGameObjectsWithTag(comida);
        if (comidas.Length > 0)
        {
            // Encontrar el objeto más cercano
            float minDistance = Mathf.Infinity;
            foreach (GameObject comida in comidas)
            {
                float distanciaPC = Vector3.Distance(posicionPez.position, comida.transform.position);
                if (distanciaPC < minDistance)
                {
                    minDistance = distanciaPC;
                    posicionComida = comida.transform;
                }
            }
            // Movimiento Angular y Comer
            float distancia = Vector3.Distance(posicionPez.position, posicionComida.position);
            if (distancia >= 1f)
            {
                Vector3 direccionMov = posicionComida.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direccionMov);
                rb.MovePosition(transform.position + direccionMov.normalized * 30f * Time.deltaTime);
                comiendo = false;
            }
            if (distancia <= 1f)
            {
                Vector3 direccionMov = posicionComida.position - transform.position;

                if (!comiendo)
                {
                    comiendo = true;
                }

                if (comiendo)
                {
                    // Rotación alrededor de la comida
                    Quaternion targetRotation = Quaternion.LookRotation(direccionMov);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 30f * Time.deltaTime);
                    Vector3 dondeRotar = posicionComida.position;
                    transform.RotateAround(dondeRotar, axis, 30f * Time.deltaTime);
                }
            }
        }
    }
```

Luego de esos peces, cree los "Peces Papá y Mamá". Estos a diferencia de los anteriores, se moveran aleatoriamente en un area predeterminda, y si la persona deja presionada la tecla "H", los peces se acercarán y tendrán hijos. Aquí se soluciona la parte de la intección entre las especies del ecosistema virtual.
El código de atracción es el siguiente:
```C#
public void Atraccion()
    {
        if (padre2 != null)
        {
            Vector3 attractionDirection = padre2.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(attractionDirection);
            posicionPez.Rotate(new Vector3(0, 180, 0));

            float distanciaAtraccion = Vector3.Distance(posicionPez.position, padre2.transform.position);
            if (distanciaAtraccion <= 2.2f)
            {
                GameObject[] enemigos = GameObject.FindGameObjectsWithTag("pezbebe");
                int cantidadEnemigos = enemigos.Length;
                if (cantidadEnemigos < 50)
                {
                    GameObject nuevoHijo = Instantiate(hijo, transform.position, Quaternion.identity);
                }                           
            }           
        }
    }
```

Luego creé al tiburon, este también nadará aleatoriamente por el lugar, pero si un pez bebé entra a su rango, el irá hacia él y se lo comerá. Aquí también se soluciona la parte de la intección entre las especies.
El código de comer el pez bebé es el siguiente:
```C#
private void Cazar()
    {
        // Buscar objetos con el tag "pezbebe"
        GameObject[] pezbebes = GameObject.FindGameObjectsWithTag(presaT);

        if (pezbebes.Length > 1)
        {
            // Encontrar el objeto más cercano
            float minDistance = Mathf.Infinity;
            foreach (GameObject pezbebe in pezbebes)
            {
                float distanciaTP = Vector3.Distance(posicionTiburon.position, pezbebe.transform.position);
                if (distanciaTP < minDistance)
                {
                    minDistance = distanciaTP;
                    posicionPresa = pezbebe.transform;
                }
            }

            // Lógica de Caza
            float distancia = Vector3.Distance(posicionTiburon.position, posicionPresa.position);
            if (distancia <= 30f)
            {
                Vector3 direccionMov = posicionPresa.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direccionMov);
                transform.Rotate(new Vector3 (0, -180, 0));
                rb.MovePosition(transform.position + direccionMov.normalized * 50f * Time.deltaTime);
                if (distancia <= 6f) rb.MovePosition(transform.position + direccionMov.normalized * 80f * Time.deltaTime);
            }
            
            if (distancia <= 2)
            {
                Destroy(posicionPresa.gameObject);
            }
        }
        else
        {
            rb.MovePosition(transform.position - transform.forward * 50f * Time.deltaTime);
            InvokeRepeating("Rotar", 0, Random.Range(3f, 10f));
        }
    }
```

También en el ecosistema, se encuentran las algas. Algunas de ella tienen movimiento de oscilaciones, de manera senoidal.
El código de su movimiento es el siguiente:
```C#
public class Marea : MonoBehaviour
{
    public float amplitud = 0.50f; 
    public float velocidad = 1.0f; 
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {        
        float desplazamientoHorizontal = amplitud * Mathf.Sin(velocidad * Time.time);               
        Vector3 nuevaPosicion = posicionInicial + new Vector3(desplazamientoHorizontal, 0, 0);
        transform.position = nuevaPosicion;
    }
}
```

En el ecosistema cada cierto tiempo cae comida de la superficie, esta rebota al caer y la marea se las lleva lejos, mientras estas se disuelven en el agua y desaparecen. Aquí se cumple el movimiento de resorte y ondas.
El código para que la comida aparezca aleatoriamente es el siguiente:
```C#
public class ComidaSpawn : MonoBehaviour
{
    public GameObject comida;
    private float nextSpawnTime; 

    private void Start()
    {        
        nextSpawnTime = Time.time + Random.Range(1f,5f);
    }
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(comida, RandomSpawnPosition(), Quaternion.identity);
            nextSpawnTime = Time.time + Random.Range(1f, 5f);
        }
    }
    Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(-50f, 40f);  
        float y = 150f;  
        float z = Random.Range(20f, 30f);  
        return new Vector3(x, y, z);
    }
}
```
