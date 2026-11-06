# MyTextEditor

Editor de texto interactivo para terminal, desarrollado en C# con .NET.

El proyecto busca implementar las funcionalidades básicas de un bloc de notas directamente en la consola, priorizando el rendimiento, la eficiencia en la manipulación de archivos y el uso adecuado de estructuras de datos como listas y arreglos de bytes.

## Requisitos

- macOS, Linux o Windows.
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

## Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/TU-USUARIO/MyTextEditor.git
cd MyTextEditor
```

### 2. Compilar el proyecto

```bash
dotnet pack -c Release
```

### 3. Instalar como herramienta global

```bash
dotnet tool install --global --add-source ./bin/Release MyTextEditor
```

### 4. Configurar PATH

Si utilizas macOS o Linux y el comando no está disponible, agrega la ruta de herramientas globales de .NET a tu PATH.

**macOS / Linux (Zsh):**

```bash
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.zshrc
source ~/.zshrc
```

**macOS / Linux (Bash):**

```bash
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.bashrc
source ~/.bashrc
```

## Uso

Una vez instalado, puedes ejecutar el editor desde cualquier directorio de la terminal.

### Abrir un archivo existente

```bash
mytexteditor notas.txt
```

### Crear un archivo nuevo

```bash
mytexteditor -n notas.txt
```

### Consultar ayuda

```bash
mytexteditor --help
```

## Actualización

Para actualizar la herramienta después de descargar nuevos cambios:

```bash
dotnet pack -c Release
dotnet tool update --global --add-source ./bin/Release MyTextEditor
```

## Desinstalación

```bash
dotnet tool uninstall --global MyTextEditor
```

## Objetivos del proyecto

- Implementar operaciones básicas de edición de texto.
- Aprender y optimizar la manipulación de listas y arreglos de bytes.
- Mejorar el manejo de archivos y flujos de datos.
- Aplicar buenas prácticas de programación en C#.
- Analizar y optimizar el rendimiento de las operaciones.
- Desarrollar una herramienta CLI funcional y reutilizable.

## Tecnologías

- C#
- .NET 10
- System.IO
- System.Collections.Generic

---

**MyTextEditor** — Un proyecto de aprendizaje enfocado en rendimiento, manipulación de archivos y desarrollo de herramientas de consola.
