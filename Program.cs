MyFile file;
List<string> lines;


int cursorX = 0;
int cursorY = 0;

var flag = true;

// Args
// Definir ruta

if (args.Length == 1 && args[0] != "-n")
{
    // Abrir archivo existente
    string ruta = args[0];

    file = new MyFile(ruta);
    lines = file.ReadAllLines();
}
else if (args.Length == 2 && args[0] == "-n")
{
    // Crear archivo nuevo
    string fileName = args[1];

    file = new MyFile(fileName, true);
    lines = new List<string>() {""};
    
}
else
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  HanText <pathOfFile>");
    Console.WriteLine("  HanText -n <pathOfFile>");

    return;
}



// Logica de escritura
while (flag)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    switch (key.Key)
    {
        
        case ConsoleKey.UpArrow:
            if (cursorY > 0)
                cursorY--;
                cursorX = lines[cursorY].Length;

            break;

        case ConsoleKey.DownArrow:
            if (cursorY < lines.Count - 1)
                cursorY++;
                cursorX = lines[cursorY].Length;
            break;

        case ConsoleKey.LeftArrow:
            if (cursorX > 0)
                cursorX--;
            break;

        case ConsoleKey.RightArrow:
            if (cursorX < lines[cursorY].Length)
                cursorX++;
            break;

        // Delete character
        case ConsoleKey.Backspace:
            if (cursorY > 0 && cursorX == 0)
            {
                cursorX = lines[cursorY - 1].Length;

                lines[cursorY - 1] += lines[cursorY];

                lines.RemoveAt(cursorY);

                cursorY--;
            }
            else if (cursorX > 0)
            {
                lines[cursorY] = lines[cursorY].Remove(cursorX - 1, 1);
                cursorX--;
            }

            break;
        
        // 
        case ConsoleKey.Enter:
            // position now of lines
            string currentLine = lines[cursorY];
            string left = currentLine.Substring(0, cursorX);
            string right = currentLine.Substring(cursorX);

            // Tenemos que divir el arreglo de string.
            // Donde la primera parte tendrá el "puntero" final para el enter
            // Mientras que la otra parte crea una nueva linea con el texto de la derecha.

            
            lines.Remove(currentLine);
            lines.Insert(cursorY++ , left);
            lines.Insert(cursorY--, right);

            cursorY++;
            cursorX = 0;

            break;

        case ConsoleKey.Escape:
            lines[cursorY] = lines[cursorY].Substring(0, cursorX) + " ";
            cursorX++;
            return;

        case ConsoleKey.Tab:

            break;
        // Combinación de teclas
        // Control + S
        case ConsoleKey.S when (key.Modifiers & ConsoleModifiers.Control) != 0:
            file.SaveAllLines(lines.ToArray());
            break;

        // Control + X
        case ConsoleKey.X when (key.Modifiers & ConsoleModifiers.Control) != 0:
            flag = false;
            break;


        default:
            lines[cursorY] = lines[cursorY].Insert(cursorX, key.KeyChar.ToString());
            cursorX++;
            break;
    }

    Console.Clear();

    for (int i = 0; i < lines.Count; i++)
    {
        Console.WriteLine(lines[i]);
    }

    DrawHelp(cursorX, cursorY);

    Console.SetCursorPosition(cursorX, cursorY);
}

static void DrawHelp(int x , int y)
{
    int bottom = Console.WindowHeight - 2;

    Console.SetCursorPosition(15, bottom);
    Console.Write("^S Save");

    Console.SetCursorPosition(30, bottom);
    Console.Write("^X Exit");

    Console.SetCursorPosition(45, bottom);
    Console.Write($"X: {x} | Y: {y}");
}
