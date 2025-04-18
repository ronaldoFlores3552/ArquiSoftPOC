# ArquiSoftPOC

## Caso de Estudio 

- Usted y su team han sido encargados de dise�ar un sistema para MiFarma, inkafarma a nivel nacional en Peru. El sistema deber� ser escalable hasta 100,000 QPS no concurrentes.

## Entregables:

- Diagrama:
    - Dise�o de Arquitectura de Software

- POC:

Implemente un POC donde se muestre el flujo completo de una Venta en base al
diagrama de arquitectura. Se entiende por Venta, la compra de un producto A con una
cantidad X. Esta venta debera actualizarse en un inventario ZZZ de un location YYY.
Para luego hacerse el pago correspondiente.

Entregables: un word con la calificacion y observaciones. Una observaci�n clave es
cuanto se tuvo que agregar porque se omitio en el diagrama de arquitectura.

Entiendase por POC(Prueba de Concepto) la implementacion basica de la arquitectura.
No se requiere la funcionalidad terminada sino solo demostrar que la arquitectura si es
aplicable a nivel de implementaci�n.

- Base de Datos
- API Swagger
- Code Coverage al 90%.
- Endpoint con Happy Path debe tener una P95 de 600ms.
- Availability del 95%

## Diagrama de Grupo: 

![DiagramaGrupoPOC](.\Imagenes\annotated-FlujoMifarma2B.jpg_page-0001.jpg).




Observaciones:

1. La arquitectura propuesta est� completamente basada en AWS, lo que genera una
dependencia fuerte de esta plataforma. Esto puede restringir futuras decisiones
tecnol�gicas y dificultar la migraci�n o integraci�n con otros entornos.

2. No se contempla qu� ocurre ante una posible falla en Lambda. La ausencia de
manejo de errores, reintentos o mecanismos como colas de mensajes en caso de
fallos, compromete la robustez del sistema frente a eventos inesperados.

3. Aunque se mencionan los componentes clave, el flujo de venta como tal no est�
detallado. No se entiende con claridad c�mo se conectan los distintos servicios
desde que se inicia la venta hasta que se actualiza el inventario y se concreta el
pago.

4. El manejo del inventario es poco claro. No se especifica c�mo se gestionan
diferentes ubicaciones o c�mo se sincroniza el stock entre almacenes, como ser�a el
caso de la locaci�n YYY. Falta un enfoque operativo y t�cnico m�s concreto.
5. El proceso de autenticaci�n se presenta de forma vaga. No hay segmentaci�n por
tipos de usuario ni una descripci�n del control de accesos, lo que es esencial para
garantizar la seguridad y trazabilidad dentro del sistema.

6. Se menciona el monitoreo, no se indica qu� m�tricas se est�n rastreando. En un
sistema de ventas, m�tricas como las transacciones realizadas, tiempos de
respuesta y disponibilidad del inventario son claves, y su omisi�n limita la capacidad
de control y mejora continua.

7. Manejo de stock caducado o no disponible: La arquitectura no parece detallar c�mo
se manejar� el stock de productos caducados o no disponibles. Es fundamental
contar con una integraci�n eficiente de la base de datos para que los productos
caducados o agotados no aparezcan como disponibles para la venta, tanto en l�nea
como en las tiendas f�sicas.

8. Integraciones, no se especifica qu� tecnolog�as o sistemas externos se integrar�n.

9. No se proporciona informaci�n sobre c�mo se planea escalar el sistema a medida
que crece el n�mero de usuarios o transacciones.

10. No se menciona c�mo los usuarios interact�an con el sistema.

11. Flujos de gesti�n de compra, ser�a �til que se detalle como se gestionan las compras
recurrentes o el reabastecimiento de inventario as� como la interacci�n de los
proveedores.

12. La arquitectura presentada no especifica claramente si la base de datos ser�
relacional o no relacional, lo cual es fundamental para comprender c�mo se
gestionar�n los datos. En el caso de que se utilice una base de datos relacional, no
se detallan los par�metros que deber�a contener, ni los requisitos obligatorios de
cada tabla. En este sentido, consideramos que no ser�a �ptimo centralizar toda la
informaci�n en una sola base de datos. Ser�a m�s adecuado distribuirla en m�ltiples
bases de datos especializadas para lograr un mejor control y organizaci�n,
especialmente en lo que respecta a la gesti�n de inventarios.Adem�s, se menciona
el uso de S3, pero no se especifica claramente su prop�sito. Asumimos que est�
vinculado al almacenamiento de im�genes de productos, pero ser�a beneficioso
aclarar su rol exacto dentro de la arquitectura para asegurar una correcta integraci�n
y uso de los recursos.

LINK: https://github.com/NotRtro/POC1.git
