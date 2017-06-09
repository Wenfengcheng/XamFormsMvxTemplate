using SQLite.Net.Attributes;

namespace MvxForms.Core.Model
{
    public class BaseModel
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
    }
}
