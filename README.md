# ArquiSoftPOC

## Caso de Estudio 

- Usted y su team han sido encargados de diseñar un sistema para MiFarma, inkafarma a nivel nacional en Peru. El sistema deberá ser escalable hasta 100,000 QPS no concurrentes.

## Entregables:

- Diagrama:
    - Diseño de Arquitectura de Software

- POC:

Implemente un POC donde se muestre el flujo completo de una Venta en base al
diagrama de arquitectura. Se entiende por Venta, la compra de un producto A con una
cantidad X. Esta venta debera actualizarse en un inventario ZZZ de un location YYY.
Para luego hacerse el pago correspondiente.

Entregables: un word con la calificacion y observaciones. Una observación clave es
cuanto se tuvo que agregar porque se omitio en el diagrama de arquitectura.

Entiendase por POC(Prueba de Concepto) la implementacion basica de la arquitectura.
No se requiere la funcionalidad terminada sino solo demostrar que la arquitectura si es
aplicable a nivel de implementación.

- Base de Datos
- API Swagger
- Code Coverage al 90%.
- Endpoint con Happy Path debe tener una P95 de 600ms.
- Availability del 95%

## Diagrama de Grupo: 

![DiagramaGrupoPOC](.\Imagenes\annotated-FlujoMifarma2B.jpg_page-0001.jpg).




Observaciones:

1. La arquitectura propuesta está completamente basada en AWS, lo que genera una
dependencia fuerte de esta plataforma. Esto puede restringir futuras decisiones
tecnológicas y dificultar la migración o integración con otros entornos.

2. No se contempla qué ocurre ante una posible falla en Lambda. La ausencia de
manejo de errores, reintentos o mecanismos como colas de mensajes en caso de
fallos, compromete la robustez del sistema frente a eventos inesperados.

3. Aunque se mencionan los componentes clave, el flujo de venta como tal no está
detallado. No se entiende con claridad cómo se conectan los distintos servicios
desde que se inicia la venta hasta que se actualiza el inventario y se concreta el
pago.

4. El manejo del inventario es poco claro. No se especifica cómo se gestionan
diferentes ubicaciones o cómo se sincroniza el stock entre almacenes, como sería el
caso de la locación YYY. Falta un enfoque operativo y técnico más concreto.
5. El proceso de autenticación se presenta de forma vaga. No hay segmentación por
tipos de usuario ni una descripción del control de accesos, lo que es esencial para
garantizar la seguridad y trazabilidad dentro del sistema.

6. Se menciona el monitoreo, no se indica qué métricas se están rastreando. En un
sistema de ventas, métricas como las transacciones realizadas, tiempos de
respuesta y disponibilidad del inventario son claves, y su omisión limita la capacidad
de control y mejora continua.

7. Manejo de stock caducado o no disponible: La arquitectura no parece detallar cómo
se manejará el stock de productos caducados o no disponibles. Es fundamental
contar con una integración eficiente de la base de datos para que los productos
caducados o agotados no aparezcan como disponibles para la venta, tanto en línea
como en las tiendas físicas.

8. Integraciones, no se especifica qué tecnologías o sistemas externos se integrarán.

9. No se proporciona información sobre cómo se planea escalar el sistema a medida
que crece el número de usuarios o transacciones.

10. No se menciona cómo los usuarios interactúan con el sistema.

11. Flujos de gestión de compra, sería útil que se detalle como se gestionan las compras
recurrentes o el reabastecimiento de inventario así como la interacción de los
proveedores.

12. La arquitectura presentada no especifica claramente si la base de datos será
relacional o no relacional, lo cual es fundamental para comprender cómo se
gestionarán los datos. En el caso de que se utilice una base de datos relacional, no
se detallan los parámetros que debería contener, ni los requisitos obligatorios de
cada tabla. En este sentido, consideramos que no sería óptimo centralizar toda la
información en una sola base de datos. Sería más adecuado distribuirla en múltiples
bases de datos especializadas para lograr un mejor control y organización,
especialmente en lo que respecta a la gestión de inventarios.Además, se menciona
el uso de S3, pero no se especifica claramente su propósito. Asumimos que está
vinculado al almacenamiento de imágenes de productos, pero sería beneficioso
aclarar su rol exacto dentro de la arquitectura para asegurar una correcta integración
y uso de los recursos.

LINK: https://github.com/NotRtro/POC1.git
