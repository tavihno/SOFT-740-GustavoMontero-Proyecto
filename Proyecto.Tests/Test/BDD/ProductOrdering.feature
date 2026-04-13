Feature: Ordenamiento de Productos
  Como un usuario de SauceDemo
  Quiero ordenar los productos por diferentes criterios
  Para encontrar artículos más fácilmente

  Background:
    Given que el usuario está autenticado en la página de inventario

  @Web
  Scenario Outline: Ordenar productos por diferentes filtros
    When selecciona la opción de ordenamiento "<filtro>"
    Then el primer producto mostrado debe ser "<producto_esperado>"

    Examples: 
      | filtro              | producto_esperado                 |
      | Name (Z to A)       | Test.allTheThings() T-Shirt (Red) |
      | Name (A to Z)       | Sauce Labs Backpack               |
      | Price (low to high) | Sauce Labs Onesie                 |
      | Price (high to low) | Sauce Labs Fleece Jacket          |