Feature: Proceso de Checkout
  Como un usuario con productos en el carrito
  Quiero completar el formulario de compra
  Para finalizar mi pedido exitosamente

  Background:
    Given que el usuario está logueado y tiene productos en el carrito

  @Web
  Scenario Outline: Checkout exitoso con información válida
    When ingresa la información de envío con "<nombre>", "<apellido>" y "<zip>"
    And finaliza la compra
    Then se debe mostrar el mensaje de éxito "Thank you for your order!"

    Examples: 
      | nombre | apellido | zip   |
      | Juan   | Perez    | 12345 |

  @Web
  Scenario Outline: Validaciones de campos obligatorios en Checkout
    When ingresa la información de envío con "<nombre>", "<apellido>" y "<zip>"
    And intenta continuar con el siguiente paso
    Then se debe mostrar el mensaje de error "<mensaje_error>"
    And se toma una captura de error con nombre "<nombre_foto>"

    Examples: 
      | nombre | apellido | zip   | mensaje_error                   | nombre_foto    |
      |        | Prueba   | 12345 | Error: First Name is required   | errorfirtname  |
      | prueba |          | 12345 | Error: Last Name is required    | errorlastname  |
      | prueba | prueba   |       | Error: Postal Code is required  | errorzip       |