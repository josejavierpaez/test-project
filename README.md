# Necesitamos  tu ayuda.



Tenemos  una necesidad de poder  registrar, actualizar, eliminar (soft-delete)  

las configuraciones de  un  GSM Gateway.

El GSM Gateway es un equipo que te permite interactuar con SIMs de diferentes proveedores de servicios de telecomunicaciones. 

Habilitando funciones como Llamadas, envió de SMS, recepción de SMS. En orden de esto, debes de registrar los datos tanto del equipo como de los sims que se insertan en el mediante los **Puertos** disponibles en el equipo.

 Cada puerto recibe un SIM de un **Proveedor** o **Carrier,** estos SIMS pueden ser del mismo proveedor o de diferentes proveedores.

Cada **Proveedor o Carrier** tiene un código único internacional,
Compañías de telecomunicaciones Dominicana y sus códigos.:

| **códigos** |**Compañías**       |
| ------ |--------------------------- |
| 01 |Altice Dominicana               |
| 02 |Claro                  |
| 04 |Trilogy Viva Dominicana |



El GSM Gateway se conecta vía un puerto UDP a la red, configurando una **IP, Usuario y Contraseña** para poder acceder al equipo por la red local.



Tenga en cuenta que nuestro equipo front-end  va a consumir ese back-end via REST si usted no tiene 

bien definido los endpoint  no sabremos cuales endpoints consumir, favor de  agregarle  un mecanismo 

que permita  conocer esos endpoints y que retornan, para ello, se le recomienda Swagger.



Esperamos su PR, 
team labcode.





  



  
