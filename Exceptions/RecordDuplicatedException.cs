namespace Practico2024NET.Exceptions
{
    public class RecordDuplicatedException : Exception
    {
        public RecordDuplicatedException(String text) : base(text) { }
    }
}
