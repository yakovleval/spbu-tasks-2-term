using task2;

internal class Program
{
    private static int ReadInteger()
    {
        bool success;
        int value;
        do
        {
            success = int.TryParse(Console.ReadLine(), out value);
            if (!success)
                Console.WriteLine("incorrect input");
        } while (!success);
        return value;
    }

    private static void Main(string[] args)
    {
        UniqueList list = new();


        while (true)
        {
            Console.WriteLine("""
        Enter the option:
        0 - exit
        1 - add element to unique list
        2 - remove element from the list
        3 - replace element in the list
        """);
            int option = ReadInteger();
            switch (option)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("Enter integer value to add:");
                    int value = ReadInteger();
                    try
                    {
                        list.Add(value);
                        Console.WriteLine("ok");
                    }
                    catch (AdditionOfExistentElementException)
                    {
                        Console.WriteLine("Element is already present in the list");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter integer value to remove:");
                    value = ReadInteger();
                    try
                    {
                        list.Remove(value);
                        Console.WriteLine("ok");
                    }
                    catch (DeletingNonExistingElementException)
                    {
                        Console.WriteLine("Element is not present in the list");
                    }
                    break;
                case 3:
                    if (list.Size == 0)
                    {
                        Console.WriteLine("can't replace element (list is empty)");
                        break;
                    }
                    Console.WriteLine($"enter the position from 0 to {list.Size - 1} to replace:");
                    int position = ReadInteger();
                    Console.WriteLine("enter the value to replace it with:");
                    value = ReadInteger();
                    bool success = list.Replace(value, position);
                    Console.WriteLine(success ? "ok" : "incorrect position");
                    break;
                default:
                    Console.WriteLine("unknown option");
                    break;
            }
        }
    }
}
