using UnityEngine;

public class ComportamientoNPC : MonoBehaviour
{
    public Transform[] puntosDeControl;
    private float velocidadMaxima; // Velocidad máxima aleatoria del carro
    public float incrementoVelocidad = 0.5f; // Incremento de velocidad por segundo
    private float velocidadActual = 0f; // Velocidad actual del carro
    private int indicePunto = 0;
    private Vector3 direccionObjetivo;

    void Start()
    {
        // Comenzar desde el primer punto
        transform.position = puntosDeControl[0].position;
        CalcularDireccionObjetivo();

        // Generar la velocidad máxima aleatoria dentro del rango especificado
        velocidadMaxima = Random.Range(6f, 11f); // El límite superior es 11 para que incluya el 10
    }

    void Update()
    {
        // Aumentar gradualmente la velocidad hasta la velocidad máxima
        velocidadActual = Mathf.Min(velocidadActual + incrementoVelocidad * Time.deltaTime, velocidadMaxima);

        // Moverse hacia el siguiente punto de control con la velocidad actual
        transform.position = Vector3.MoveTowards(transform.position, puntosDeControl[indicePunto].position, velocidadActual * Time.deltaTime);
        
        // Si alcanza el punto de control, avanzar al siguiente punto y recalcular la dirección objetivo
        if (Vector3.Distance(transform.position, puntosDeControl[indicePunto].position) < 0.1f)
        {
            indicePunto = (indicePunto + 1) % puntosDeControl.Length;
            CalcularDireccionObjetivo();
        }

        // Girar hacia la dirección objetivo
        Vector3 direccionActual = puntosDeControl[indicePunto].position - transform.position;
        direccionActual.y = 0f; // Mantener la rotación en el plano horizontal
        Quaternion rotacion = Quaternion.LookRotation(direccionActual);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 360f * Time.deltaTime);
    }

    void CalcularDireccionObjetivo()
    {
        // Calcular la dirección hacia el siguiente punto de control
        Vector3 direccion = puntosDeControl[indicePunto].position - transform.position;
        direccion.y = 0f; // Mantener la dirección en el plano horizontal
        direccionObjetivo = direccion.normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el NPC colisiona con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Disminuir la velocidad del NPC
            velocidadActual *= 0.5f; // Por ejemplo, podrías reducir la velocidad a la mitad
        }
    }
}