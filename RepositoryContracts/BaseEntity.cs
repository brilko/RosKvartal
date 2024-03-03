using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryContracts
{
    public class BaseEntity
    {
        public BaseEntity() 
        {
            Deleted = false;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public bool Deleted { get; set; }   
    }
}
