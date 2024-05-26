# Documentación de la evidencia evaluativa de la unidad

## Enlace al video en YouTube
[Video Fuerzas Estanque Digital](https://youtu.be/LxH9CPGue8w)

## Explicación de la solución

En esta unidad debiamos incorporar fuerzas a nuestro estanque, ya sea de repulsión, atracción, entre otras. Debian ser minimo tres fuerzas.

Para solucionarlo, en mi estanque puse Espinas que hacen que los peces y los tiburones se alejen de ellas al tocarlas, tambien si la persona desea puede crear dos interacciones, Una es hacer que los peces se junten y creen hijitos (Que pueden ser comidos por los tiburones) esto apretando la tecla "A". Y la otra es crear una corriente que lleva todos los peces y los tiburones al lado izquierdo del estanque, esto apretando la tecla "C"

Aqui está el codigo de la corriente:
```
public void Corriente()
    {
        Vector3 vectorCorriente = direccionCorriente.transform.position - transform.position;
        float distancia = vectorCorriente.magnitude;
        Vector3 fuerzaCorriente = vectorCorriente.normalized * corriente * 400 / Mathf.Max(distancia, 1f);
        rb.AddForce(fuerzaCorriente);
    }
```

Y aqui el codigo de la atracción de los peces y como tienen hijos:
```
 public void Atraccion()
    {
        if (targetObject != null)
        {
            Vector3 attractionDirection = targetObject.transform.position - transform.position;
            float distance = attractionDirection.magnitude;

            Vector3 attractionForceVector = attractionDirection.normalized * attractionForce * 10 / Mathf.Max(distance, 1f);
            rb.AddForce(attractionForceVector);

            if (distance <= 2.2f)  
            { 
                Instantiate(hijo, transform.position + Vector3.up, Quaternion.identity);
            }
            Debug.Log(distance);
        } 
    }
```
