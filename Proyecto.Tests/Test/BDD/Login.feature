Feature: Login de Usuarios
  Como un cliente de SauceDemo
  Quiero acceder al sistema con mis credenciales
  Para poder gestionar mis compras

  @Web
  Scenario Outline: Login con diferentes credenciales
    Given que el usuario navega a la pagina de login
    When ingresa el usuario "<usuario>" y la contraseña "<password>"
    And hace clic en el boton de login
    Then se debe validar el resultado para el usuario "<usuario>"

    Examples: 
      | usuario         | password     |
      | standard_user   | secret_sauce |
      | locked_out_user | secret_sauce |
      | invalid_user    | wrong_pass   |

 