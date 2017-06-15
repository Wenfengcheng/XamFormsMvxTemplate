using SQLite.Net.Attributes;

namespace $safeprojectname$.Model
{
    public class BaseModel
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
    }
}
