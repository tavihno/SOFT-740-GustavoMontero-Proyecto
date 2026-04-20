# Proyecto.Tests

Repositorio de pruebas automatizadas (Selenium + NUnit) para `https://www.saucedemo.com/`.

## Requisitos

- .NET SDK 10 (instale desde https://dotnet.microsoft.com/)
- PowerShell 7+ (`pwsh`) o `powershell.exe` en Windows
- Google Chrome instalado (el paquete `Selenium.WebDriver.ChromeDriver` está incluido, pero la versión de Chrome debe ser compatible)
- Visual Studio 2022/2026 o VS Code (opcional)

## Estructura relevante

- `Proyecto.Tests.csproj` — proyecto de pruebas
- `Test/WEB/Features/` — archivos Gherkin (`.feature`)
- `Test/WEB/Reqnroll/` — runner ligero, atributos y definiciones de pasos (step definitions)
- `Test/WEB/Test*Feature.cs` — tests NUnit que ejecutan las features vía `Runner.RunFeature(...)`
- `Pages/` — page objects
- `Utilities/Configuración/TestBase.cs` — hooks `Setup()` y `TearDown()` para inicializar/cerrar navegador
- `scripts/run-tests-and-generate-report.ps1` — script para ejecutar tests y generar reportes de cobertura
- `.github/workflows/test-and-report.yml` — workflow de CI que ejecuta tests y genera reportes

## Instalación (local)

1. Clonar el repositorio:

   ```powershell
   git clone https://github.com/tavihno/SOFT-740-GustavoMontero-Proyecto.git
   cd SOFT-740-GustavoMontero-Proyecto/Proyecto.Tests
   ```

2. Restaurar paquetes:

   ```powershell
   dotnet restore Proyecto.Tests.csproj
   ```

## Ejecutar pruebas

- Ejecutar todas las pruebas con `dotnet test`:

  ```powershell
  dotnet test Proyecto.Tests.csproj
  ```

- Ejecutar una prueba/un conjunto concreto (por ejemplo la feature de Checkout) usando la clase que expone el runner:

  ```powershell
  dotnet test --filter FullyQualifiedName~TestCheckoutFeature
  ```

  O ejecutar desde Visual Studio Test Explorer buscando `TestCheckoutFeature`.

## Ejecutar features Gherkin (Reqnroll)

Se provee un runner ligero que mapea los pasos Gherkin a métodos con atributos en `Test/WEB/Reqnroll/*Steps.cs`.
Para ejecutar una feature específica desde NUnit se han creado tests en `Test/WEB/*Feature.cs`. Ejecutar con:

```powershell
dotnet test --filter FullyQualifiedName~TestCheckoutFeature
```

ó ejecutar todos los tests `RunFeaturesAsTests`:

```powershell
dotnet test --filter FullyQualifiedName~RunFeaturesAsTests
```

## Generación de reportes de ejecución y cobertura

Se incluye un script PowerShell `scripts/run-tests-and-generate-report.ps1` que:
- Ejecuta `dotnet test` y genera archivo TRX
- Recopila cobertura con `coverlet.collector` (XPlat)
- Genera un informe HTML con `reportgenerator`

Ejecutar localmente:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File .\scripts\run-tests-and-generate-report.ps1 -Project 'Proyecto.Tests\Proyecto.Tests.csproj' -ResultsDir 'TestResults'
```

Salida esperada:
- `TestResults/` con `*.trx` y cobertura (si está disponible)
- `TestResults/Report/index.htm` con informe HTML

El flujo CI ya está configurado en `.github/workflows/test-and-report.yml` y sube el reporte como artifact.

## Ajustes comunes

- Headless (ejecución en CI): Modificar `Utilities/Configuración/TestBase.cs` y descomentar/agregar la opción `--headless=new` en `ChromeOptions`.
- Timeout/esperas: `TestBase` define `ImplicitWait`; para condiciones explícitas use `WebDriverWait`.
- ChromeDriver mismatch: Si las pruebas fallan por versión de Chrome, actualizar paquete `Selenium.WebDriver.ChromeDriver` o instalar la versión compatible de Chrome.

## Debug y Troubleshooting

- Ver fallos: abrir el archivo TRX o ver salida en Test Explorer.
- Capturas: los tests usan `ScreenshotHelper.TakeScreenshot(Driver, "name.png")` para guardar screenshots en la carpeta por defecto (ajustar helper si necesita ruta distinta).
- Si no se genera cobertura: confirmar que `coverlet.collector` está en `csproj` y que las pruebas se están ejecutando con `dotnet test` (el script ya lo hace).

## Notas finales

- Los archivos Gherkin están en `Test/WEB/Features/`. Las step definitions están en `Test/WEB/Reqnroll/` y usan atributos personalizados `Given/When/Then` y hooks `BeforeScenario` / `AfterScenario` que llaman a `TestBase.Setup()` / `TestBase.TearDown()`.
- Si desea integración completa con `SpecFlow` o publicar el informe HTML en GitHub Pages, puedo añadir esos pasos.

---
Generado automáticamente. Para cambios específicos en el README indique qué desea agregar o aclarar.
