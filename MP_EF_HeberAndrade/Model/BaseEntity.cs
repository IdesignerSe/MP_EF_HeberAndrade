namespace MP_EF_HeberAndrade
{
                    

    public abstract class BaseEntity
    {
        protected BaseEntity(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
