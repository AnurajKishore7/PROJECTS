namespace HospitalModelLibrary
{
    public class EmptyCollectionException : Exception
    {
        private readonly string _message;
        public EmptyCollectionException()
        {
            _message = "The collection is empty";
        }
        public EmptyCollectionException(string message)
        {
            _message = message;
        }
        public override string Message => _message;

    }
}
