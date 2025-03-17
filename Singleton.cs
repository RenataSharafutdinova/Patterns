class DatabaseConnection
{
    private static DatabaseConnection instance;
    private DatabaseConnection()
    {
        Console.WriteLine("DatabaseConnection created.");
    }
    public static DatabaseConnection GetDatabase()
    {
        if (instance == null)
            instance = new DatabaseConnection();
        return instance;
    }
    
}
class Program
{
   static void Main(string[] args)
   {
       DatabaseConnection connection1 = DatabaseConnection.GetDatabase();
       DatabaseConnection connection2 = DatabaseConnection.GetDatabase();

       Console.WriteLine(connection1 == connection2);

       Console.WriteLine("Connection1 hash: " + connection1.GetHashCode());
       Console.WriteLine("Connection1 hash: " + connection2.GetHashCode());

   }
}
