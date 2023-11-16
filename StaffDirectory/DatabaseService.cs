using SQLite;
using SQLitePCL;

public class DatabaseService
{
    SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Employee>().Wait();
    }

    // Clear or truncate the SQLite database
    public void ClearDatabase()
    {
        try
        {
            _database.DropTableAsync<Employee>();
            _database.CreateTableAsync<Employee>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing database: {ex.Message}");
        }
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _database.FindAsync<Employee>(id);
    }


    #region C R U D Operations
    //C
    public async Task AddEmployeeAsync(Employee details)
    {
        await _database.InsertAsync(details);
    }

    //R
    public async Task<List<Employee>> GetEmployeeAsync()
    {
        return await _database.Table<Employee>().ToListAsync();
    }

    //U
    public async Task UpdateEmployeeAsync(Employee details)
    {
        await _database.UpdateAsync(details);
    }

    //D
    public async Task DeleteEmployeeAsync(Employee details)
    {
        await _database.DeleteAsync(details);
    }
    #endregion

}

