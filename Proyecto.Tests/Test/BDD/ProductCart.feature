Feature: Gestión del Carrito de Compras
  Como un usuario autenticado
  Quiero agregar y eliminar productos del carrito
  Para gestionar mi pedido antes de la compra

  Background:
    Given que el usuario está en la página de inventario con "standard_user" y "secret_sauce"

  @Web
  Scenario Outline: Agregar múltiples productos al carrito
    When el usuario agrega el Producto 1 y el Producto 2 al carrito
    Then el contador del carrito debería mostrar <cantidad_esperada>
    And se toma una captura de pantalla con el nombre "Conteo_Productos"

    Examples: 
      | cantidad_esperada |
      | 2                 |

  @Web
  Scenario: Eliminar un producto desde la vista del carrito
    Given que el usuario ha agregado el Producto 1 y el Producto 2 al carrito
    When navega a la página del carrito
    And elimina el Producto 2
    Then se toma una captura de pantalla con el nombre "Eliminar_Producto"