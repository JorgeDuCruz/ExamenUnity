# Apartado A:

Una vez la bola se mueve, le creo un tag personalizado al cubo y en el script de la bola uso la siguiente función para detectar la colisión:
```
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
            {
                Debug.Log("Toco al cubo");
        }    
    }
```

También se puede hacer de otras maneras, como por ejemplo:

Recojer la posición del cubo y compararlo la posición del player entre otros métodos, pero es complicarse de manera innecesaria.