namespace HospitalModelLibrary
{
    public class CannotFindEntityException : Exception
    {
        private readonly string _message;
        public CannotFindEntityException()
        {
            _message = "Cannot find the entity";
        }
        public CannotFindEntityException(string message)
        {
            _message = message;
        }
        public override string Message => _message;
    }
}
