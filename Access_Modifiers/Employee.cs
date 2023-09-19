namespace Access_Modifiers
{
    public class Employee : Person
    {
        public void AccessProtectedMethod()
        {
            ProtectedMethod();
        }
        public void AccessPrivateProtectedMethod()
        {
            PrivateProtectedMethod();
        }
        public void AccessInternalMethod()
        {
            InternalMethod();
        }
    }
}
