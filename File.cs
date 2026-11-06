using System.Collections.Generic;

internal class MyFile
{
    private string rutaArchivo = "";

    public MyFile(string ruta, bool create = false)
    {
        this.rutaArchivo = _validationPath(ruta, create);
    }

    public List<Byte> FileToByteArray()
    {
        using FileStream fs = new FileStream(this.rutaArchivo,
                                       FileMode.Open,
                                       FileAccess.Read);
                                       
        using BinaryReader br = new BinaryReader(fs);

        return br.ReadBytes((int)fs.Length).ToList();
    }

    // To save for original path    
    public bool SaveToFile(List<Byte> data)
    {
        File.WriteAllBytes(rutaArchivo, data.ToArray());
        return true;
    }

    // Save for an alternative route
    public bool SaveAs(string newPath)
    {
        string fullPath = _validationPath(newPath, true);

        byte[] data = File.ReadAllBytes(rutaArchivo);

        File.WriteAllBytes(fullPath, data);

        rutaArchivo = fullPath;

        return true;
    }

    public bool SaveAllLines(string[] data)
    {
        File.WriteAllLines(rutaArchivo, data);
        return true;
    }

    public List<string> ReadAllLines()
    {
        return File.ReadAllLines(this.rutaArchivo).ToList();
    }

    private string _validationPath(string ruta, bool create = false)
    {
        if (string.IsNullOrWhiteSpace(ruta))
            throw new ArgumentException("La ruta no puede estar vacía.");

        string fullPath = Path.IsPathRooted(ruta)
            ? Path.GetFullPath(ruta)
            : Path.GetFullPath(ruta, Directory.GetCurrentDirectory());

        if (!create && !File.Exists(fullPath))
            throw new FileNotFoundException("El archivo no existe.", fullPath);

        if (create && !Directory.Exists(Path.GetDirectoryName(fullPath)))
            throw new DirectoryNotFoundException("El directorio no existe.");

        return fullPath;
    }

}